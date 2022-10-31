package testattributes

import (
	"fmt"
	"sort"
	"strings"

	"github.com/hashicorp/hcl/v2"
	"github.com/hashicorp/hcl/v2/hclsyntax"
	"github.com/hashicorp/hcl/v2/hclwrite"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
	"github.com/zclconf/go-cty/cty"
)

type TestAttributesHelpers struct {
	SchemaModels map[string]resourcemanager.TerraformSchemaModelDefinition
	Dependencies *TestDependencyHelper
}

type TestDependencyHelper struct {
	Resource  DependentResources
	Variables DependentVariables
}

type DependentResources struct {
	HasResourceGroup        bool
	HasEdgeZone             bool
	HasUserAssignedIdentity bool
	HasSubnet               bool
	HasPublicIP             bool
	HasVirtualNetwork       bool
}

type DependentVariables struct {
	HasRandomInt    bool
	HasRandomString bool
}

// GetAttributesForTests builds terraform configuration based on the attributes passed in.
// It can get either Required only or Required/Optional Attributes
func (h TestAttributesHelpers) GetAttributesForTests(resourceLabel string, input resourcemanager.TerraformSchemaModelDefinition, hclBody *hclwrite.Body, requiredOnly bool) error {
	requiredFields := make([]string, 0)
	optionalFields := make([]string, 0)
	for fieldName, details := range input.Fields {
		if details.Required {
			requiredFields = append(requiredFields, fieldName)
			continue
		}
		if !requiredOnly {
			if details.Optional {
				optionalFields = append(optionalFields, fieldName)
				continue
			}
		}
	}

	sort.Strings(requiredFields)
	sortedNames := make([]string, 0)
	sortedNames = append(sortedNames, requiredFields...)

	if !requiredOnly {
		sort.Strings(optionalFields)
		sortedNames = append(sortedNames, optionalFields...)
	}

	for _, fieldName := range sortedNames {
		if err := h.codeForTestAttribute(resourceLabel, input.Fields[fieldName], requiredOnly, hclBody); err != nil {
			return err
		}
	}
	return nil
}

func (h TestAttributesHelpers) codeForTestAttribute(resourceLabel string, input resourcemanager.TerraformSchemaFieldDefinition, requiredOnly bool, hclBody *hclwrite.Body) error {
	if input.Validation != nil && input.Validation.Type == resourcemanager.TerraformSchemaValidationTypePossibleValues && input.Validation.PossibleValues != nil {
		return h.codeForTestAttributeWithPossibleValues(input, hclBody)
	}

	switch input.ObjectDefinition.Type {
	// todo randomize values
	case resourcemanager.TerraformSchemaFieldTypeBoolean:
		hclBody.SetAttributeValue(input.HclName, cty.False)
	case resourcemanager.TerraformSchemaFieldTypeFloat:
		hclBody.SetAttributeValue(input.HclName, cty.NumberFloatVal(10.1))
	case resourcemanager.TerraformSchemaFieldTypeInteger:
		hclBody.SetAttributeValue(input.HclName, cty.NumberIntVal(15))
	case resourcemanager.TerraformSchemaFieldTypeString:
		switch input.HclName {
		case "name":
			// todo pipe in packagename to make "acctest-vm-${local.random_integer}"
			tokens := hclwrite.Tokens{
				{Type: hclsyntax.TokenQuotedLit, Bytes: []byte(`"acctest-${local.random_integer}"`)},
			}
			hclBody.SetAttributeRaw(input.HclName, tokens)
			if h.Dependencies != nil {
				h.Dependencies.Variables.HasRandomInt = true
			}
		case "subnet_id":
			hclBody.SetAttributeTraversal(input.HclName, hcl.Traversal{
				hcl.TraverseRoot{
					Name: "azurerm_subnet.test.id",
				},
			})
			if h.Dependencies != nil {
				h.Dependencies.Resource.HasSubnet = true
				h.Dependencies.Resource.HasVirtualNetwork = true
				h.Dependencies.Resource.HasResourceGroup = true
				h.Dependencies.Variables.HasRandomInt = true
			}
		case "virtual_network_id":
			hclBody.SetAttributeTraversal(input.HclName, hcl.Traversal{
				hcl.TraverseRoot{
					Name: "azurerm_virtual_network.test.id",
				},
			})
			if h.Dependencies != nil {
				h.Dependencies.Resource.HasResourceGroup = true
				h.Dependencies.Resource.HasVirtualNetwork = true
				h.Dependencies.Variables.HasRandomInt = true
			}
		case "public_ip_address_id":
			hclBody.SetAttributeTraversal(input.HclName, hcl.Traversal{
				hcl.TraverseRoot{
					Name: "azurerm_public_ip.test.id",
				},
			})
			if h.Dependencies != nil {
				h.Dependencies.Resource.HasPublicIP = true
				h.Dependencies.Resource.HasResourceGroup = true
				h.Dependencies.Variables.HasRandomInt = true
			}
		default:
			hclBody.SetAttributeValue(input.HclName, cty.StringVal("foo"))
		}
	case resourcemanager.TerraformSchemaFieldTypeList, resourcemanager.TerraformSchemaFieldTypeSet:
		hclBody.AppendNewline()
		if input.ObjectDefinition.NestedObject.Type == resourcemanager.TerraformSchemaFieldTypeReference {
			if input.ObjectDefinition.NestedObject.ReferenceName == nil {
				return fmt.Errorf("missing name for reference")
			}
			reference, ok := h.SchemaModels[*input.ObjectDefinition.NestedObject.ReferenceName]
			if !ok {
				return fmt.Errorf("schema model %q was not found", *input.ObjectDefinition.NestedObject.ReferenceName)
			}
			if err := h.GetAttributesForTests(resourceLabel, reference, hclBody.AppendNewBlock(input.HclName, nil).Body(), requiredOnly); err != nil {
				return err
			}
		} else {
			// this is an array of a basic type
			switch input.ObjectDefinition.NestedObject.Type {
			case resourcemanager.TerraformSchemaFieldTypeFloat:
				hclBody.SetAttributeValue(input.HclName, cty.ListVal([]cty.Value{
					cty.NumberFloatVal(1.1),
					cty.NumberFloatVal(2.2),
					cty.NumberFloatVal(3.3),
				}))
			case resourcemanager.TerraformSchemaFieldTypeInteger:
				hclBody.SetAttributeValue(input.HclName, cty.ListVal([]cty.Value{
					cty.NumberIntVal(1),
					cty.NumberIntVal(2),
					cty.NumberIntVal(3),
				}))
			case resourcemanager.TerraformSchemaFieldTypeString:
				hclBody.SetAttributeValue(input.HclName, cty.ListVal([]cty.Value{
					cty.StringVal("foo"),
					cty.StringVal("baz"),
				}))
			default:
				return fmt.Errorf("internal-error: unimplemented schema field for nested object type %q", string(input.ObjectDefinition.NestedObject.Type))
			}
		}

		hclBody.AppendNewline()
	case resourcemanager.TerraformSchemaFieldTypeReference:
		hclBody.AppendNewline()
		if input.ObjectDefinition.ReferenceName == nil {
			return fmt.Errorf("missing name for reference")
		}
		_, ok := h.SchemaModels[*input.ObjectDefinition.ReferenceName]
		if !ok {
			return fmt.Errorf("schema model %q was not found", *input.ObjectDefinition.ReferenceName)
		}
		nestedBlock := hclBody.AppendNewBlock(input.HclName, nil).Body()
		if err := h.GetAttributesForTests(resourceLabel, h.SchemaModels[*input.ObjectDefinition.ReferenceName], nestedBlock, requiredOnly); err != nil {
			return err
		}
		hclBody.AppendNewline()
	case resourcemanager.TerraformSchemaFieldTypeEdgeZone:
		// todo put in the checks for correct Required/Optional/Computed usage?
		hclBody.SetAttributeTraversal(input.HclName, hcl.Traversal{
			hcl.TraverseRoot{
				Name: "data.azurerm_extended_locations.test.extended_locations[0]",
			},
		})
		if h.Dependencies != nil {
			h.Dependencies.Resource.HasEdgeZone = true
			h.Dependencies.Resource.HasResourceGroup = true
			h.Dependencies.Variables.HasRandomInt = true
		}
	case resourcemanager.TerraformSchemaFieldTypeIdentitySystemAssigned, resourcemanager.TerraformSchemaFieldTypeIdentitySystemOrUserAssigned:
		hclBody.AppendNewline()
		identityBody := *hclBody.AppendNewBlock(input.HclName, nil).Body()
		identityBody.SetAttributeValue("type", cty.StringVal("SystemAssigned"))
		hclBody.AppendNewline()
	case resourcemanager.TerraformSchemaFieldTypeIdentitySystemAndUserAssigned:
		hclBody.AppendNewline()
		identityBody := *hclBody.AppendNewBlock(input.HclName, nil).Body()
		identityBody.SetAttributeValue("type", cty.StringVal("SystemAssigned, UserAssigned"))

		identityBody.SetAttributeRaw("identity_ids", hclwrite.TokensForTuple([]hclwrite.Tokens{
			hclwrite.TokensForTraversal(hcl.Traversal{
				hcl.TraverseRoot{
					Name: "azurerm_user_assigned_identity.test.id",
				},
			})}))
		hclBody.AppendNewline()
		if h.Dependencies != nil {
			h.Dependencies.Resource.HasUserAssignedIdentity = true
			h.Dependencies.Resource.HasResourceGroup = true
			h.Dependencies.Variables.HasRandomInt = true
		}
	case resourcemanager.TerraformSchemaFieldTypeIdentityUserAssigned:
		hclBody.AppendNewline()
		identityBody := *hclBody.AppendNewBlock(input.HclName, nil).Body()
		identityBody.SetAttributeValue("type", cty.StringVal("UserAssigned"))

		identityBody.SetAttributeRaw("identity_ids", hclwrite.TokensForTuple([]hclwrite.Tokens{
			hclwrite.TokensForTraversal(hcl.Traversal{
				hcl.TraverseRoot{
					Name: "azurerm_user_assigned_identity.test.id",
				},
			})}))
		hclBody.AppendNewline()
		if h.Dependencies != nil {
			h.Dependencies.Resource.HasUserAssignedIdentity = true
			h.Dependencies.Resource.HasResourceGroup = true
			h.Dependencies.Variables.HasRandomInt = true
		}
	case resourcemanager.TerraformSchemaFieldTypeLocation:
		if strings.EqualFold(resourceLabel, "resource_group") {
			tokens := hclwrite.Tokens{
				{Type: hclsyntax.TokenQuotedLit, Bytes: []byte(` "${local.primary_location}"`)},
			}
			hclBody.SetAttributeRaw(input.HclName, tokens)
			if h.Dependencies != nil {
				h.Dependencies.Variables.HasRandomInt = true
				h.Dependencies.Resource.HasResourceGroup = false
			}
		} else {
			hclBody.SetAttributeTraversal(input.HclName, hcl.Traversal{
				hcl.TraverseRoot{
					Name: "azurerm_resource_group.test.location",
				},
			})
			if h.Dependencies != nil {
				h.Dependencies.Variables.HasRandomInt = true
				h.Dependencies.Resource.HasResourceGroup = true
			}
		}
	case resourcemanager.TerraformSchemaFieldTypeResourceGroup:
		if strings.EqualFold(resourceLabel, "resource_group") {
			tokens := hclwrite.Tokens{
				{Type: hclsyntax.TokenQuotedLit, Bytes: []byte(` "acctestrg-${local.random_integer}"`)},
			}
			hclBody.SetAttributeRaw(input.HclName, tokens)
			if h.Dependencies != nil {
				h.Dependencies.Variables.HasRandomInt = true
				h.Dependencies.Resource.HasResourceGroup = false
			}
		} else {
			hclBody.SetAttributeTraversal(input.HclName, hcl.Traversal{
				hcl.TraverseRoot{
					Name: "azurerm_resource_group.test.name",
				},
			})
			if h.Dependencies != nil {
				h.Dependencies.Variables.HasRandomInt = true
				h.Dependencies.Resource.HasResourceGroup = true
			}
		}
	case resourcemanager.TerraformSchemaFieldTypeTags:
		hclBody.SetAttributeValue("tags", cty.ObjectVal(map[string]cty.Value{
			"env":  cty.StringVal("Production"),
			"test": cty.StringVal("Acceptance"),
		}))
	case resourcemanager.TerraformSchemaFieldTypeZone:
		hclBody.SetAttributeValue(input.HclName, cty.NumberIntVal(1))
	case resourcemanager.TerraformSchemaFieldTypeZones:
		hclBody.SetAttributeValue(input.HclName, cty.ListVal([]cty.Value{
			cty.StringVal("1"),
		}))
	}

	return nil
}

func (h TestAttributesHelpers) codeForTestAttributeWithPossibleValues(input resourcemanager.TerraformSchemaFieldDefinition, hclBody *hclwrite.Body) error {
	if len(input.Validation.PossibleValues.Values) == 0 {
		return fmt.Errorf("the Field %q had a Validation Type of PossibleValues but no PossibleValues were defined", input.HclName)
	}
	if input.ObjectDefinition.Type == resourcemanager.TerraformSchemaFieldTypeList {
		if input.ObjectDefinition.NestedObject == nil {
			return fmt.Errorf("the Field %q was a List with no NestedObject", input.HclName)
		}

		if input.Validation.PossibleValues.Type == resourcemanager.TerraformSchemaValidationPossibleValueTypeFloat {
			hclBody.SetAttributeValue(input.HclName, cty.ListVal([]cty.Value{
				cty.NumberFloatVal(input.Validation.PossibleValues.Values[0].(float64)),
			}))
			return nil
		}
		if input.Validation.PossibleValues.Type == resourcemanager.TerraformSchemaValidationPossibleValueTypeInt {
			hclBody.SetAttributeValue(input.HclName, cty.ListVal([]cty.Value{
				cty.NumberIntVal(input.Validation.PossibleValues.Values[0].(int64)),
			}))
			return nil
		}
		if input.Validation.PossibleValues.Type == resourcemanager.TerraformSchemaValidationPossibleValueTypeString {
			hclBody.SetAttributeValue(input.HclName, cty.ListVal([]cty.Value{
				cty.StringVal(input.Validation.PossibleValues.Values[0].(string)),
			}))
			return nil
		}

		// TODO: what if it's a list of constant strings?
		return fmt.Errorf("unimplemented: the Field %q was a List NestedObject Type %q", input.HclName, string(input.ObjectDefinition.NestedObject.Type))
	}

	if input.Validation.PossibleValues.Type == resourcemanager.TerraformSchemaValidationPossibleValueTypeFloat {
		hclBody.SetAttributeValue(input.HclName, cty.NumberFloatVal(input.Validation.PossibleValues.Values[0].(float64)))
		return nil
	}
	if input.Validation.PossibleValues.Type == resourcemanager.TerraformSchemaValidationPossibleValueTypeInt {
		hclBody.SetAttributeValue(input.HclName, cty.NumberIntVal(input.Validation.PossibleValues.Values[0].(int64)))
		return nil
	}
	if input.Validation.PossibleValues.Type == resourcemanager.TerraformSchemaValidationPossibleValueTypeString {
		hclBody.SetAttributeValue(input.HclName, cty.StringVal(input.Validation.PossibleValues.Values[0].(string)))
		return nil
	}

	return fmt.Errorf("missing PossibleValues implementation for Schema Field %q (%s)", input.HclName, input.ObjectDefinition.String())
}

func addCommentToTestConfig(hclBody hclwrite.Body, comment string) {
	hclBody.AppendNewline()
	hclBody.AppendUnstructuredTokens(hclwrite.TokensForTraversal(hcl.Traversal{
		hcl.TraverseRoot{
			Name: fmt.Sprintf("// %s", comment),
		},
	}))
	hclBody.AppendNewline()
}
