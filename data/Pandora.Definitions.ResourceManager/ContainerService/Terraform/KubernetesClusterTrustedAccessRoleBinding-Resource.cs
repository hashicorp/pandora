using System;
using Pandora.Definitions.Helpers;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.ContainerService.Terraform;

public class KubernetesClusterTrustedAccessRoleBindingResource : TerraformResourceDefinition
{
    public string DisplayName => "Kubernetes Cluster Trusted Access Role Binding";
    public ResourceID ResourceId => new v2023_04_02_preview.TrustedAccess.TrustedAccessRoleBindingId();
    public string ResourceLabel => "kubernetes_cluster_trusted_access_role_binding";
    public string ResourceCategory => "Container";
    public string ResourceDescription => @"Manages a Kubernetes Cluster Trusted Access Role Binding
~> **Note:** This Resource is in **Preview** to use this you must be opted into the Preview. You can do this by running `az feature register --namespace Microsoft.ContainerService --name TrustedAccessPreview` and then `az provider register -n Microsoft.ContainerService`
";
    public string ResourceExampleUsage => @"resource 'azurerm_application_insights' 'example' {
  name                = 'example'
  location            = azurerm_resource_group.example.location
  resource_group_name = azurerm_resource_group.example.name
  application_type    = 'example-value'
}
data 'azurerm_client_config' 'test' {}
resource 'azurerm_key_vault' 'example' {
  name                       = 'example'
  location                   = azurerm_resource_group.example.location
  resource_group_name        = azurerm_resource_group.example.name
  tenant_id                  = data.azurerm_client_config.example.tenant_id
  sku_name                   = 'example-value'
  soft_delete_retention_days = 'example-value'
}
resource 'azurerm_key_vault_access_policy' 'example' {
  key_vault_id = azurerm_key_vault.example.id
  tenant_id    = data.azurerm_client_config.example.tenant_id
  object_id    = data.azurerm_client_config.example.object_id
  key_permissions = 'example-value'
}
resource 'azurerm_kubernetes_cluster' 'example' {
  name                = 'example'
  location            = azurerm_resource_group.example.location
  resource_group_name = azurerm_resource_group.example.name
  dns_prefix          = 'acctestaksexample'
  default_node_pool {
    name       = 'example-value'
    node_count = 'example-value'
    vm_size    = 'example-value'
  }
  identity {
    type = 'example-value'
  }
}
resource 'azurerm_machine_learning_workspace' 'example' {
  name                    = 'example'
  location                = azurerm_resource_group.example.location
  resource_group_name     = azurerm_resource_group.example.name
  key_vault_id            = azurerm_key_vault.example.id
  storage_account_id      = azurerm_storage_account.example.id
  application_insights_id = azurerm_application_insights.example.id
  identity {
    type = 'example-value'
  }
}
resource 'azurerm_resource_group' 'example' {
  name     = 'example-resources'
  location = 'West Europe'
}
resource 'azurerm_storage_account' 'example' {
  name                     = 'example'
  location                 = azurerm_resource_group.example.location
  resource_group_name      = azurerm_resource_group.example.name
  account_tier             = 'example-value'
  account_replication_type = 'example-value'
}
resource 'azurerm_kubernetes_cluster_trusted_access_role_binding' 'example' {
  kubernetes_cluster_id = azurerm_kubernetes_cluster.example.id
  name                  = 'example'
  roles                 = 'example-value'
  source_resource_id    = azurerm_machine_learning_workspace.example.id
}".AsTerraformTestConfig();
    public Type? SchemaModel => typeof(KubernetesClusterTrustedAccessRoleBindingResourceSchema);
    public TerraformMappingDefinition SchemaMappings => new KubernetesClusterTrustedAccessRoleBindingResourceMappings();
    public TerraformResourceTestDefinition Tests => new KubernetesClusterTrustedAccessRoleBindingResourceTests();

    public bool GenerateIDValidationFunction => true;
    public bool GenerateModel => true;
    public bool GenerateSchema => true;

    public MethodDefinition CreateMethod => new MethodDefinition
    {
        Generate = true,
        Method = typeof(v2023_04_02_preview.TrustedAccess.RoleBindingsCreateOrUpdateOperation),
        TimeoutInMinutes = 30,
    };
    public MethodDefinition DeleteMethod => new MethodDefinition
    {
        Generate = true,
        Method = typeof(v2023_04_02_preview.TrustedAccess.RoleBindingsDeleteOperation),
        TimeoutInMinutes = 30,
    };
    public MethodDefinition ReadMethod => new MethodDefinition
    {
        Generate = true,
        Method = typeof(v2023_04_02_preview.TrustedAccess.RoleBindingsGetOperation),
        TimeoutInMinutes = 5,
    };
    public MethodDefinition? UpdateMethod => new MethodDefinition
    {
        Generate = true,
        Method = typeof(v2023_04_02_preview.TrustedAccess.RoleBindingsCreateOrUpdateOperation),
        TimeoutInMinutes = 30,
    };
}
