package parser

import (
	"testing"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

func TestParseModel_CommonSchema_Location(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "model_commonschema_location.json")
	if err != nil {
		t.Fatalf("parsing: %+v", err)
	}

	expected := models.AzureApiDefinition{
		ServiceName: "Example",
		ApiVersion:  "2020-01-01",
		Resources: map[string]models.AzureApiResource{
			"Resource": {
				Models: map[string]models.ModelDetails{
					"Model": {
						Fields: map[string]models.FieldDetails{
							"Location": {
								JsonName:        "location",
								CustomFieldType: pointer.To(models.CustomFieldTypeLocation),
								Required:        false,
							},
						},
					},
				},
				Operations: map[string]models.OperationDetails{
					"Test": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "PUT",
						OperationId:         "Resource_Test",
						RequestObject: &models.ObjectDefinition{
							ReferenceName: pointer.To("Model"),
							Type:          models.ObjectDefinitionReference,
						},
						ResponseObject: &models.ObjectDefinition{
							ReferenceName: pointer.To("Model"),
							Type:          models.ObjectDefinitionReference,
						},
						UriSuffix: pointer.To("/foo"),
					},
				},
			},
		},
	}
	validateParsedSwaggerResultMatches(t, expected, actual)
}
