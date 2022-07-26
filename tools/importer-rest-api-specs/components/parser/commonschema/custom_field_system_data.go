package commonschema

import (
	"reflect"
	"strings"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/parser/internal"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

var _ customFieldMatcher = systemDataMatcher{}

type systemDataMatcher struct{}

func (systemDataMatcher) CustomFieldType() models.CustomFieldType {
	return models.CustomFieldTypeSystemData
}

func (systemDataMatcher) IsMatch(_ models.FieldDetails, definition models.ObjectDefinition, known internal.ParseResult) bool {
	if definition.Type != models.ObjectDefinitionReference {
		return false
	}

	// retrieve the model from the reference
	model, ok := known.Models[*definition.ReferenceName]
	if !ok {
		return false
	}

	hasCreatedAt := false
	hasCreatedBy := false
	hasLastModifiedBy := false
	hasLastModifiedAt := false

	hasCreatedByType := false
	hasLastModifiedbyType := false

	for fieldName, fieldVal := range model.Fields {
		if strings.EqualFold(fieldName, "CreatedAt") {
			hasCreatedAt = true
			continue
		}

		if strings.EqualFold(fieldName, "CreatedBy") {
			hasCreatedBy = true
			continue
		}

		if strings.EqualFold(fieldName, "LastModifiedBy") {
			hasLastModifiedBy = true
			continue
		}

		if strings.EqualFold(fieldName, "LastModifiedAt") {
			hasLastModifiedAt = true
			continue
		}

		if strings.EqualFold(fieldName, "CreatedByType") {
			if fieldVal.ObjectDefinition == nil || fieldVal.ObjectDefinition.Type != models.ObjectDefinitionReference {
				continue
			}

			if fieldVal.ObjectDefinition.Type == models.ObjectDefinitionString {
				// Sometimes this field is a string.
				// https://github.com/Azure/azure-rest-api-specs/blob/main/specification/servicefabricmanagedclusters/resource-manager/Microsoft.ServiceFabric/stable/2021-05-01/managedcluster.json#L1322-L1325
				hasCreatedByType = true
				continue
			} else if fieldVal.ObjectDefinition.Type == models.ObjectDefinitionReference {
				// Sometimes it's not ...
				// https://github.com/Azure/azure-rest-api-specs/blob/main/specification/azurearcdata/resource-manager/Microsoft.AzureArcData/stable/2021-08-01/azurearcdata.json#L1294-L1297
				expected := map[string]string{
					"User":            "User",
					"Application":     "Application",
					"ManagedIdentity": "ManagedIdentity",
					"Key":             "Key",
				}
				constant, ok := known.Constants[*fieldVal.ObjectDefinition.ReferenceName]
				if !ok {
					continue
				}
				hasCreatedByType = validateSystemDataConstantValues(constant, expected)
			}

			continue
		}

		if strings.EqualFold(fieldName, "LastModifiedByType") {
			if fieldVal.ObjectDefinition == nil || fieldVal.ObjectDefinition.Type != models.ObjectDefinitionReference {
				continue
			}

			// Sometimes this field is a string.
			// https://github.com/Azure/azure-rest-api-specs/blob/main/specification/servicefabricmanagedclusters/resource-manager/Microsoft.ServiceFabric/stable/2021-05-01/managedcluster.json#L1322-L1325
			if fieldVal.ObjectDefinition.Type == models.ObjectDefinitionString {
				hasLastModifiedbyType = true
			} else if fieldVal.ObjectDefinition.Type == models.ObjectDefinitionReference {
				// Sometimes it's not ...
				// https://github.com/Azure/azure-rest-api-specs/blob/main/specification/azurearcdata/resource-manager/Microsoft.AzureArcData/stable/2021-08-01/azurearcdata.json#L1294-L1297
				expected := map[string]string{
					"User":            "User",
					"Application":     "Application",
					"ManagedIdentity": "ManagedIdentity",
					"Key":             "Key",
				}
				constant, ok := known.Constants[*fieldVal.ObjectDefinition.ReferenceName]
				if !ok {
					continue
				}
				hasLastModifiedbyType = validateSystemDataConstantValues(constant, expected)
			}
			continue
		}

		// other fields
		return false
	}

	return hasCreatedByType && hasCreatedBy && hasLastModifiedbyType && hasLastModifiedAt && hasLastModifiedBy && hasCreatedAt
}

func validateSystemDataConstantValues(input resourcemanager.ConstantDetails, expected map[string]string) bool {
	if input.Type != resourcemanager.StringConstant {
		return false
	}

	// we can't guarantee the casing on these, so we should parse this insensitively since it'll be swapped
	// out anyway
	actual := make(map[string]string, 0)
	for k, v := range input.Values {
		actual[strings.ToLower(k)] = strings.ToLower(v)
	}

	normalizedExpected := make(map[string]string, 0)
	for k, v := range expected {
		normalizedExpected[strings.ToLower(k)] = strings.ToLower(v)
	}

	return reflect.DeepEqual(actual, normalizedExpected)
}
