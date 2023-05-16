package testattributes

import (
	"fmt"
	"strings"
)

type TestDep interface {
	Name() string
	GenConfig() string
	RefValue(field ...string) string
	Deps() []TestDep
}

type AllDeps struct {
	Items        []TestDep
	basicSnap    []TestDep
	CompleteSnap []TestDep
}

func (a *AllDeps) Add(item TestDep) {
	for _, dep := range a.Items {
		if dep.Name() == item.Name() {
			return
		}
	}
	a.Items = append(a.Items, item)
}

func (a *AllDeps) collectAll() []TestDep {
	var res []TestDep
	var collect func(t TestDep)
	collect = func(t TestDep) {
		res = append(res, t)
		for _, dep := range t.Deps() {
			collect(dep)
		}
	}
	for _, item := range a.Items {
		collect(item)
	}
	var dedup []TestDep
	for idx := len(res) - 1; idx >= 0; idx-- {
		var isDup bool
		for _, item := range dedup {
			if item.Name() == res[idx].Name() {
				isDup = true
				break
			}
		}
		if !isDup {
			dedup = append(dedup, res[idx])
		}
	}
	return dedup
}

// GenTemplateConfig use basic dependency as template
func (a *AllDeps) GenTemplateConfig() string {
	var bs strings.Builder
	bs.WriteString(`
provider "azurerm" {
  features {}
}

locals {
  random_integer   = %[1]d
  primary_location = %[2]q
}

`)

	allDeps := a.collectAll()
	a.basicSnap = allDeps
	for _, item := range allDeps {
		bs.WriteString(item.GenConfig())
		bs.WriteString("\n\n")
	}
	str := bs.String()
	return strings.Replace(str, `"`, "'", -1)
}

func (a *AllDeps) GenConfig() string {
	var bs strings.Builder

	allDeps := a.collectAll()
	// remove templated dependencies
	var dedup []TestDep
	for _, item := range allDeps {
		var skip = false
		for _, temp := range a.basicSnap {
			if item.Name() == temp.Name() {
				skip = true
				break
			}
		}
		if !skip {
			for _, existing := range dedup {
				if item.Name() == existing.Name() {
					skip = true
					break
				}
			}
		}
		if !skip {
			dedup = append(dedup, item)
		}
	}
	for _, item := range dedup {
		bs.WriteString(item.GenConfig())
		bs.WriteString("\n\n")
	}
	str := bs.String()
	return strings.Replace(str, `"`, "'", -1)
}

var _, _ TestDep = DepResource{}, DepDataSource{}

type DepResource struct {
	name    string
	label   string
	Content string
	deps    []TestDep // this resource dependent on others
}

func NewDepResource(name, content string, deps ...TestDep) DepResource {
	return DepResource{
		name:    name,
		label:   "test", // default label as 'test'
		Content: content,
		deps:    deps,
	}
}

func (d DepResource) content() string {
	return fmt.Sprintf(`"%s" "%s" {
%s
}`, d.name, d.label, d.Content)
}

func (d DepResource) GenConfig() string {
	return fmt.Sprintf(`resource %s`, d.content())
}

func (d DepResource) Deps() []TestDep {
	return d.deps
}

func (d DepResource) Name() string {
	return d.name + "." + d.label
}

func (d DepResource) RefValue(field ...string) string {
	key := "id"
	if len(field) > 0 {
		key = field[0]
	}
	return fmt.Sprintf("%s.%s.%s", d.name, d.label, key)
}

type DepDataSource struct {
	DepResource
}

func NewDepDateSource(name, content string, deps ...TestDep) DepDataSource {
	return DepDataSource{
		DepResource: NewDepResource(name, content, deps...),
	}
}

func (d DepDataSource) RefValue(field ...string) string {
	key := "id"
	if len(field) > 0 {
		key = field[0]
	}
	return fmt.Sprintf("data.%s.%s.%s", d.name, d.label, key)
}

func (d DepDataSource) GenConfig() string {
	return fmt.Sprintf(`data %s`, d.content())
}

var (
	edgeZoneDep TestDep = NewDepDateSource("azurerm_extended_locations",
		`location = azurerm_resource_group.test.location`,
		resourceGroupDep,
	)

	clientConfigDep = DepResource{
		name:  "azurerm_client_config",
		label: "current",
	}

	resourceGroupDep = NewDepResource(
		"azurerm_resource_group",
		`name     = "acctestrg-${local.random_integer}"
		location = local.primary_location`,
	)

	publicIPDep = NewDepResource(
		"azurerm_public_ip",
		`name                = "acctest-${local.random_integer}"
		location            = azurerm_resource_group.test.location
		resource_group_name = azurerm_resource_group.test.name
		allocation_method   = "Dynamic"`,
		resourceGroupDep,
	)

	userAssignedIdentity = NewDepResource(
		"azurerm_user_assigned_identity",
		`name                = "acctest-${local.random_integer}"
  resource_group_name = azurerm_resource_group.test.name
  location            = azurerm_resource_group.test.location`,
		resourceGroupDep,
	)

	virtualNetworkDep = NewDepResource(
		"azurerm_virtual_network",
		`name                = "acctest-${local.random_integer}"
  resource_group_name = azurerm_resource_group.test.name
  location            = azurerm_resource_group.test.location
  address_space       = ["10.0.0.0/16"]`,
		resourceGroupDep,
	)

	subNetDep = NewDepResource(
		"azurerm_subnet",
		`name                 = "internal"
  resource_group_name  = azurerm_resource_group.test.name
  virtual_network_name = azurerm_virtual_network.test.name
  address_prefixes     = ["10.0.2.0/24"]`,
		resourceGroupDep, virtualNetworkDep,
	)

	keyVaultDep = newKeyVaultDep(
		`
  name                       = "acctestkv-${local.random_str}"
  location                   = azurerm_resource_group.test.location
  resource_group_name        = azurerm_resource_group.test.name
  tenant_id                  = data.azurerm_client_config.current.tenant_id
  sku_name                   = "standard"
  purge_protection_enabled   = true
  soft_delete_retention_days = 7

  access_policy {
    tenant_id = data.azurerm_client_config.current.tenant_id
    object_id = data.azurerm_client_config.current.object_id

    key_permissions = [
      "Create",
      "Delete",
      "Get",
      "Purge",
      "Recover",
      "Update",
      "SetRotationPolicy",
      "GetRotationPolicy",
      "Rotate",
    ]

    secret_permissions = [
      "Delete",
      "Get",
      "Set",
    ]
  }

  tags = {
    environment = "Production"
  }
`,
	)

	keyVaultKeyDep = newKeyVaultKeyDep(
		`name         = "key-${local.random_str}"
  key_vault_id = azurerm_key_vault.test.id
  key_type     = "RSA"
  key_size     = 2048

  key_opts = [
    "decrypt",
    "encrypt",
    "sign",
    "unwrapKey",
    "verify",
    "wrapKey",
  ]`)
)

func newKeyVaultDep(content string) DepResource {
	return NewDepResource("azurerm_key_vault", content, clientConfigDep, resourceGroupDep)
}

func newKeyVaultKeyDep(content string, dep ...TestDep) DepResource {
	if len(dep) == 0 {
	}
	dep = []TestDep{keyVaultDep}

	return NewDepResource(
		"azurerm_key_vault_key",
		content,
		dep...)
}
