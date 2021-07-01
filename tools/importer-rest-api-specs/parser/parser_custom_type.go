package parser

import (
	"reflect"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

// customTypeMatcher tests whether a model matches the schema definition of a custom type.
// Note that each implementation of customTypeMatcher should be mutually exclusive.
type customTypeMatcher interface {
	Match(model models.ModelDetails, resource models.AzureApiResource) bool
	Name() models.FieldDefinitionType
}

func fieldIsIdentityTypeOfValue(field models.FieldDetails, constants constantDetailsMap, expect map[string]string) bool {
	if field.Type != models.Object {
		return false
	}
	if field.ConstantReference == nil {
		return false
	}
	constant, ok := constants[*field.ConstantReference]
	if !ok {
		return false
	}
	actual := map[string]string{}
	for k, v := range constant.Values {
		// Some model doesn't define a "None" as an enum value for identity type. So we will skip it for comparison.
		if k == "None" {
			continue
		}
		actual[k] = v
	}
	return reflect.DeepEqual(actual, expect)
}

func (d *SwaggerDefinition) replaceCustomType(input map[string]models.AzureApiResource) {
	matchers := []customTypeMatcher{
		systemAssignedIdentityMatcher{},
		userAssignedIdentityListMatcher{},
		userAssignedIdentityMapMatcher{},
		systemAssignedUserAssignedIdentityListMatcher{},
		systemAssignedUserAssignedIdentityMapMatcher{},
	}

	for resourceName, resource := range input {
		for modelName, model := range resource.Models {
			for _, matcher := range matchers {
				if !matcher.Match(model, resource) {
					continue
				}
				// Remove the model from the model set
				delete(input[resourceName].Models, modelName)

				// Iterate over all the models' fields, modify any field referencing this model by nil set its ModelReference, and set its Type to the custom type.
				// TODO: Do we need to remove the models that are only referenced by the "model" under iteration?
				//       E.g. the "model" might has reference to the "userAssignedIdentities" model.
				for mName, m := range resource.Models {
					// Skip current model that is deleted from the model set
					if mName == modelName {
						continue
					}
					for fieldName, field := range m.Fields {
						if field.ModelReference == nil || *field.ModelReference != modelName {
							continue
						}
						field.ModelReference = nil
						field.Type = matcher.Name()
						m.Fields[fieldName] = field
					}
				}
			}
		}
	}
}
