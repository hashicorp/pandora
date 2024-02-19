package parser

import (
	"testing"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

func TestParseModel_CommonSchema_IdentityLegacySystemAndUserAssignedList(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "model_commonschema_identitylegacysystemanduserassignedlist.json")
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
							"Identity": {
								JsonName:        "identity",
								CustomFieldType: pointer.To(models.CustomFieldTypeLegacySystemAndUserAssignedIdentityList),
								Required:        false,
							},
							"Name": {
								JsonName: "name",
								ObjectDefinition: &models.ObjectDefinition{
									Type: models.ObjectDefinitionString,
								},
								Required: false,
							},
						},
					},
				},
				Operations: map[string]models.OperationDetails{
					"Test": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						OperationId:         "Resource_Test",
						ResponseObject: &models.ObjectDefinition{
							ReferenceName: pointer.To("Model"),
							Type:          models.ObjectDefinitionReference,
						},
						UriSuffix: pointer.To("/example"),
					},
				},
			},
		},
	}
	validateParsedSwaggerResultMatches(t, expected, actual)
}

func TestParseModel_CommonSchema_IdentitySystemAssigned(t *testing.T) {
	actual, err := ParseSwaggerFileForTesting(t, "model_commonschema_identitysystemassigned.json")
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
							"Identity": {
								JsonName:        "identity",
								CustomFieldType: pointer.To(models.CustomFieldTypeSystemAssignedIdentity),
								Required:        false,
							},
							"Name": {
								JsonName: "name",
								ObjectDefinition: &models.ObjectDefinition{
									Type: models.ObjectDefinitionString,
								},
								Required: false,
							},
						},
					},
				},
				Operations: map[string]models.OperationDetails{
					"Test": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						OperationId:         "Resource_Test",
						ResponseObject: &models.ObjectDefinition{
							ReferenceName: pointer.To("Model"),
							Type:          models.ObjectDefinitionReference,
						},
						UriSuffix: pointer.To("/example"),
					},
				},
			},
		},
	}
	validateParsedSwaggerResultMatches(t, expected, actual)
}

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
							"Name": {
								JsonName: "name",
								ObjectDefinition: &models.ObjectDefinition{
									Type: models.ObjectDefinitionString,
								},
								Required: false,
							},
						},
					},
				},
				Operations: map[string]models.OperationDetails{
					"Test": {
						ContentType:         "application/json",
						ExpectedStatusCodes: []int{200},
						Method:              "GET",
						OperationId:         "Resource_Test",
						ResponseObject: &models.ObjectDefinition{
							ReferenceName: pointer.To("Model"),
							Type:          models.ObjectDefinitionReference,
						},
						UriSuffix: pointer.To("/example"),
					},
				},
			},
		},
	}
	validateParsedSwaggerResultMatches(t, expected, actual)
}
