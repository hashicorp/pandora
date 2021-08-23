package parser

import (
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

// customTypeMatcher tests whether a model matches the schema definition of a custom type.
// Note that each implementation of customTypeMatcher should be mutually exclusive.
type customTypeMatcher interface {
	Match(model models.ModelDetails, resource models.AzureApiResource) bool
	Name() models.FieldDefinitionType
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
				for mName, m := range resource.Models {
					// Skip current model that is deleted from the model set
					if mName == modelName {
						continue
					}
					for fieldName, field := range m.Fields {
						if field.ModelReference == nil || *field.ModelReference != modelName {
							continue
						}
						// note: the unused models and constants are cleaned up once this stage is finished
						field.ModelReference = nil
						field.Type = matcher.Name()
						m.Fields[fieldName] = field
					}
				}
			}
		}
	}
}
