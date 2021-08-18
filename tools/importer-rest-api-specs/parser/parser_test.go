package parser

import (
	"context"
	"encoding/json"
	"fmt"
	"log"
	"net/http"
	"os"
	"reflect"
	"strings"
	"testing"
	"time"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

const swaggerDirectory = "../../../swagger/specification"
const runAllEnvVar = "ALL"

func TestAllSwaggersUsingParser(t *testing.T) {
	if os.Getenv(runAllEnvVar) == "" {
		t.Skipf("skipping since %q is unset", runAllEnvVar)
	}

	services, err := FindResourceManagerServices(swaggerDirectory, false, true)
	if err != nil {
		t.Fatal(err)
	}

	for _, service := range *services {
		for apiVersion, versionPath := range service.ApiVersionPaths {
			serviceType := "resource-manager"
			if strings.Contains(versionPath, "data-plane") {
				serviceType = "data-plane"
			}

			t.Run(fmt.Sprintf("%s/%s/%s", service.Name, serviceType, apiVersion), func(t *testing.T) {
				t.Parallel()

				// safety
				_, done := context.WithTimeout(context.TODO(), 90*time.Second)
				defer done()
				log.Printf("[DEBUG] Validating %q at %q..", service.Name, versionPath)
				err := validateDirectory(service.Name, apiVersion, versionPath)
				if err != nil {
					t.Fatal(err)
				}
			})
		}
	}
}

func TestAllSwaggersValidateAllContainTypes(t *testing.T) {
	if os.Getenv(runAllEnvVar) == "" {
		t.Skipf("skipping since %q is unset", runAllEnvVar)
	}

	services, err := FindResourceManagerServices(swaggerDirectory, false, true)
	if err != nil {
		t.Fatal(err)
	}

	for _, service := range *services {
		for apiVersion, versionPath := range service.ApiVersionPaths {
			serviceType := "resource-manager"
			if strings.Contains(versionPath, "data-plane") {
				serviceType = "data-plane"
			}

			t.Run(fmt.Sprintf("%s/%s/%s", service.Name, serviceType, apiVersion), func(t *testing.T) {
				t.Parallel()

				// safety
				_, done := context.WithTimeout(context.TODO(), 90*time.Second)
				defer done()
				log.Printf("[DEBUG] Validating %q at %q..", service.Name, versionPath)
				err := validateDirectory(service.Name, apiVersion, versionPath)
				if err != nil {
					if strings.HasSuffix(err.Error(), "is missing a type") {
						t.Fatal(err)
					}
				}
			})
		}
	}
}

func TestAllSwaggersValidateFindOAIGenParserBug(t *testing.T) {
	if os.Getenv(runAllEnvVar) == "" {
		t.Skipf("skipping since %q is unset", runAllEnvVar)
	}

	services, err := FindResourceManagerServices(swaggerDirectory, false, true)
	if err != nil {
		t.Fatal(err)
	}

	for _, service := range *services {
		for apiVersion, versionPath := range service.ApiVersionPaths {
			serviceType := "resource-manager"
			if strings.Contains(versionPath, "data-plane") {
				serviceType = "data-plane"
			}

			t.Run(fmt.Sprintf("%s/%s/%s", service.Name, serviceType, apiVersion), func(t *testing.T) {
				// safety
				_, done := context.WithTimeout(context.TODO(), 30*time.Second)
				defer done()
				log.Printf("[DEBUG] Validating %q at %q..", service.Name, versionPath)
				err := validateDirectory(service.Name, apiVersion, versionPath)
				if err != nil {
					if strings.Contains(err.Error(), "OAIGen") {
						t.Fatal(err)
					}
				}
			})
		}
	}
}

func TestAllSwaggersValidateFindUnknownBugs(t *testing.T) {
	if os.Getenv(runAllEnvVar) == "" {
		t.Skipf("skipping since %q is unset", runAllEnvVar)
	}

	services, err := FindResourceManagerServices(swaggerDirectory, false, true)
	if err != nil {
		t.Fatal(err)
	}

	for _, service := range *services {
		for apiVersion, versionPath := range service.ApiVersionPaths {
			serviceType := "resource-manager"
			if strings.Contains(versionPath, "data-plane") {
				serviceType = "data-plane"
			}

			t.Run(fmt.Sprintf("%s/%s/%s", service.Name, serviceType, apiVersion), func(t *testing.T) {
				// safety
				_, done := context.WithTimeout(context.TODO(), 30*time.Second)
				defer done()
				log.Printf("[DEBUG] Validating %q at %q..", service.Name, versionPath)
				err := validateDirectory(service.Name, apiVersion, versionPath)
				if err != nil {
					if !strings.Contains(err.Error(), "OAIGen") &&
						!strings.HasSuffix(err.Error(), "is missing a type") &&
						!strings.HasSuffix(err.Error(), "duplicate operation ID") {
						t.Fatal(err)
					}
				}
			})
		}
	}
}

func TestAssertParserCanParseAppConfiguration(t *testing.T) {
	if os.Getenv(runAllEnvVar) == "" {
		t.Skipf("skipping since %q is unset", runAllEnvVar)
	}

	directory := fmt.Sprintf("%s/appconfiguration/resource-manager/Microsoft.AppConfiguration/stable/2020-06-01", swaggerDirectory)
	fileName := "appconfiguration.json"

	parsedFile, err := Load(directory, fileName, true)
	if err != nil {
		t.Fatal(err)
	}

	result, err := parsedFile.Parse("AppConfiguration", "2020-06-01")
	if err != nil {
		t.Fatal(err)
	}

	var strPtr = func(in string) *string {
		return &in
	}

	expected := models.AzureApiDefinition{
		ServiceName: "AppConfiguration",
		ApiVersion:  "2020-06-01",
		Resources: map[string]models.AzureApiResource{
			"ConfigurationStores": {
				Constants: map[string]models.ConstantDetails{
					"ActionsRequired": {
						FieldType: models.StringConstant,
						Values: map[string]string{
							"None":     "None",
							"Recreate": "Recreate",
						},
					},
					"ConnectionStatus": {
						FieldType: models.StringConstant,
						Values: map[string]string{
							"Approved":     "Approved",
							"Disconnected": "Disconnected",
							"Pending":      "Pending",
							"Rejected":     "Rejected",
						},
					},
					"IdentityType": {
						FieldType: models.StringConstant,
						Values: map[string]string{
							"None":                       "None",
							"SystemAssigned":             "SystemAssigned",
							"SystemAssignedUserAssigned": "SystemAssigned, UserAssigned",
							"UserAssigned":               "UserAssigned",
						},
					},
					"ProvisioningState": {
						FieldType: models.StringConstant,
						Values: map[string]string{
							"Canceled":  "Canceled",
							"Creating":  "Creating",
							"Deleting":  "Deleting",
							"Failed":    "Failed",
							"Succeeded": "Succeeded",
							"Updating":  "Updating",
						},
					},
					"PublicNetworkAccess": {
						FieldType: models.StringConstant,
						Values: map[string]string{
							"Disabled": "Disabled",
							"Enabled":  "Enabled",
						},
					},
				},
				Models: map[string]models.ModelDetails{
					"AccessKey": {
						Description: "",
						Fields: map[string]models.FieldDetails{
							"Id": {
								Type:     models.String,
								JsonName: "id",
							},
							"Name": {
								Type:     models.String,
								JsonName: "name",
							},
							"Value": {
								Type:     models.String,
								JsonName: "value",
							},
							"ConnectionString": {
								Type:      models.String,
								JsonName:  "connectionString",
								Sensitive: true,
							},
							"LastModified": {
								Type:     models.DateTime,
								JsonName: "lastModified",
							},
							"ReadOnly": {
								Type:     models.Boolean,
								JsonName: "readOnly",
							},
						},
					},
					"ConfigurationStore": {
						Description: "",
						Fields: map[string]models.FieldDetails{
							"Id": {
								Type:     models.String,
								JsonName: "id",
							},
							"Identity": {
								Type:           models.Object,
								ModelReference: strPtr("ResourceIdentity"),
								JsonName:       "identity",
							},
							"Location": {
								Type:     models.Location,
								JsonName: "location",
								Required: true,
							},
							"Name": {
								Type:     models.String,
								JsonName: "name",
							},
							"Properties": {
								Type:           models.Object,
								ModelReference: strPtr("ConfigurationStoreProperties"),
								JsonName:       "properties",
							},
							"Sku": {
								Type:           models.Object,
								ModelReference: strPtr("Sku"),
								JsonName:       "sku",
								Required:       true,
							},
							"Tags": {
								Type:     models.Tags,
								JsonName: "tags",
							},
							"Type": {
								Type:     models.String,
								JsonName: "type",
							},
						},
					},

					"ConfigurationStoreProperties": {
						Description: "",
						Fields: map[string]models.FieldDetails{
							"CreationDate": {
								Type:     models.DateTime,
								JsonName: "creationDate",
							},
							"Encryption": {
								Type:           models.Object,
								ModelReference: strPtr("EncryptionProperties"),
								JsonName:       "encryption",
							},
							"Endpoint": {
								Type:     models.String,
								JsonName: "endpoint",
							},
							"PrivateEndpointConnections": {
								Type:           models.List,
								ModelReference: strPtr("PrivateEndpointConnection"),
								JsonName:       "privateEndpointConnections",
							},
							"ProvisioningState": {
								Type:              models.Object,
								ConstantReference: strPtr("ProvisioningState"),
								JsonName:          "provisioningState",
								ReadOnly:          true,
							},
							"PublicNetworkAccess": {
								Type:              models.Object,
								ConstantReference: strPtr("PublicNetworkAccess"),
								JsonName:          "publicNetworkAccess",
							},
						},
					},
					"ConfigurationStoreUpdateParameters": {
						Description: "",
						Fields: map[string]models.FieldDetails{
							"Identity": {
								Type:           models.Object,
								JsonName:       "identity",
								ModelReference: strPtr("ResourceIdentity"),
							},
							"Properties": {
								Type:           models.Object,
								ModelReference: strPtr("ConfigurationStorePropertiesUpdateParameters"),
								JsonName:       "properties",
							},
							"Sku": {
								Type:           models.Object,
								ModelReference: strPtr("Sku"),
								JsonName:       "sku",
							},
							"Tags": {
								Type:     models.Tags,
								JsonName: "tags",
							},
						},
					},
					"ConfigurationStorePropertiesUpdateParameters": {
						Description: "",
						Fields: map[string]models.FieldDetails{
							"Encryption": {
								Type:           models.Object,
								ModelReference: strPtr("EncryptionProperties"),
								JsonName:       "encryption",
							},
							"PublicNetworkAccess": {
								Type:              models.Object,
								ConstantReference: strPtr("PublicNetworkAccess"),
								JsonName:          "publicNetworkAccess",
							},
						},
					},
					"EncryptionProperties": {
						Description: "",
						Fields: map[string]models.FieldDetails{
							"KeyVaultProperties": {
								Type:           models.Object,
								ModelReference: strPtr("KeyVaultProperties"),
								JsonName:       "keyVaultProperties",
							},
						},
					},
					"KeyVaultProperties": {
						Description: "",
						Fields: map[string]models.FieldDetails{
							"IdentityClientId": {
								Type:     models.String,
								JsonName: "identityClientId",
							},
							"KeyIdentifier": {
								Type:     models.String,
								JsonName: "keyIdentifier",
							},
						},
					},
					"PrivateEndpoint": {
						Description: "",
						Fields: map[string]models.FieldDetails{
							"Id": {
								Type:     models.String,
								JsonName: "id",
							},
						},
					},
					"PrivateEndpointConnection": {
						Description: "",
						Fields: map[string]models.FieldDetails{
							"Id": {
								Type:     models.String,
								JsonName: "id",
							},
							"Name": {
								Type:     models.String,
								JsonName: "name",
							},
							"Properties": {
								Type:           models.Object,
								ModelReference: strPtr("PrivateEndpointConnectionProperties"),
								JsonName:       "properties",
							},
							"Type": {
								Type:     models.String,
								JsonName: "type",
							},
						},
					},
					"PrivateEndpointConnectionProperties": {
						Description: "",
						Fields: map[string]models.FieldDetails{
							"PrivateEndpoint": {
								Type:           models.Object,
								ModelReference: strPtr("PrivateEndpoint"),
								JsonName:       "privateEndpoint",
							},
							"PrivateLinkServiceConnectionState": {
								Type:           models.Object,
								ModelReference: strPtr("PrivateLinkServiceConnectionState"),
								JsonName:       "privateLinkServiceConnectionState",
								Required:       true,
							},
							"ProvisioningState": {
								Type:              models.Object,
								ConstantReference: strPtr("ProvisioningState"),
								JsonName:          "provisioningState",
							},
						},
					},
					"PrivateLinkServiceConnectionState": {
						Description: "",
						Fields: map[string]models.FieldDetails{
							"ActionsRequired": {
								Type:              models.Object,
								ConstantReference: strPtr("ActionsRequired"),
								JsonName:          "actionsRequired",
							},
							"Description": {
								Type:     models.String,
								JsonName: "description",
							},
							"Status": {
								Type:              models.Object,
								ConstantReference: strPtr("ConnectionStatus"),
								JsonName:          "status",
							},
						},
					},
					"ResourceIdentity": {
						Description: "",
						Fields: map[string]models.FieldDetails{
							"PrincipalId": {
								Type:     models.String,
								JsonName: "principalId",
							},
							"TenantId": {
								Type:     models.String,
								JsonName: "tenantId",
							},
							"Type": {
								Type:              models.Object,
								ConstantReference: strPtr("IdentityType"),
								JsonName:          "type",
							},
							"UserAssignedIdentities": {
								Type:           models.Dictionary,
								ModelReference: strPtr("UserIdentity"),
								JsonName:       "userAssignedIdentities",
							},
						},
					},
					"Sku": {
						Description: "",
						Fields: map[string]models.FieldDetails{
							"Name": {
								Type:     models.String,
								Required: true,
								JsonName: "name",
							},
						},
					},
					"UserIdentity": {
						Description: "",
						Fields: map[string]models.FieldDetails{
							"ClientId": {
								Type:     models.String,
								JsonName: "clientId",
							},
							"PrincipalId": {
								Type:     models.String,
								JsonName: "principalId",
							},
						},
					},
				},
				Operations: map[string]models.OperationDetails{
					"Create": {
						LongRunning:       true,
						RequestObjectName: strPtr("ConfigurationStore"),
						ResourceIdName:    strPtr("ConfigurationStore"),
						Method:            http.MethodPut,
						Options:           map[string]models.OperationOption{},
						ApiVersion:        strPtr("2020-06-01"),
						Uri:               "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AppConfiguration/configurationStores/{configStoreName}",
					},
					"Delete": {
						LongRunning: true,
						ExpectedStatusCodes: []int{
							http.StatusNoContent,
							http.StatusOK,
							http.StatusAccepted,
						},
						ResourceIdName: strPtr("ConfigurationStore"),
						Method:         http.MethodDelete,
						Options:        map[string]models.OperationOption{},
						ApiVersion:     strPtr("2020-06-01"),
						Uri:            "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AppConfiguration/configurationStores/{configStoreName}",
					},
					"Get": {
						ResponseObjectName: strPtr("ConfigurationStore"),
						ResourceIdName:     strPtr("ConfigurationStore"),
						Method:             http.MethodGet,
						Options:            map[string]models.OperationOption{},
						ApiVersion:         strPtr("2020-06-01"),
						Uri:                "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AppConfiguration/configurationStores/{configStoreName}",
					},
					"ListKeys": {
						FieldContainingPaginationDetails: strPtr("nextLink"),
						ResponseObjectName:               strPtr("AccessKey"),
						UriSuffix:                        strPtr("/listKeys"),
						ResourceIdName:                   strPtr("ConfigurationStore"),
						Method:                           http.MethodPost,
						Options:                          map[string]models.OperationOption{},
						ApiVersion:                       strPtr("2020-06-01"),
						Uri:                              "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AppConfiguration/configurationStores/{configStoreName}/listKeys",
					},
					"Update": {
						RequestObjectName: strPtr("ConfigurationStoreUpdateParameters"),
						ResourceIdName:    strPtr("ConfigurationStore"),
						Method:            http.MethodPatch,
						Options:           map[string]models.OperationOption{},
						ApiVersion:        strPtr("2020-06-01"),
						Uri:               "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AppConfiguration/configurationStores/{configStoreName}",
					},
				},
				ResourceIds: map[string]string{
					"ConfigurationStore": "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AppConfiguration/configurationStores/{configStoreName}",
				},
			},
			"PrivateEndpointConnections": {
				Constants: map[string]models.ConstantDetails{
					"ActionsRequired": {
						FieldType: models.StringConstant,
						Values: map[string]string{
							"None":     "None",
							"Recreate": "Recreate",
						},
					},
					"ConnectionStatus": {
						FieldType: models.StringConstant,
						Values: map[string]string{
							"Approved":     "Approved",
							"Disconnected": "Disconnected",
							"Pending":      "Pending",
							"Rejected":     "Rejected",
						},
					},
					"ProvisioningState": {
						FieldType: models.StringConstant,
						Values: map[string]string{
							"Canceled":  "Canceled",
							"Creating":  "Creating",
							"Deleting":  "Deleting",
							"Failed":    "Failed",
							"Succeeded": "Succeeded",
							"Updating":  "Updating",
						},
					},
				},
				Models: map[string]models.ModelDetails{
					"PrivateEndpoint": {
						Description: "",
						Fields: map[string]models.FieldDetails{
							"Id": {
								Type:     models.String,
								JsonName: "id",
							},
						},
					},
					"PrivateEndpointConnection": {
						Description: "",
						Fields: map[string]models.FieldDetails{
							"Id": {
								Type:     models.String,
								JsonName: "id",
							},
							"Name": {
								Type:     models.String,
								JsonName: "name",
							},
							"Properties": {
								Type:           models.Object,
								ModelReference: strPtr("PrivateEndpointConnectionProperties"),
								JsonName:       "properties",
							},
							"Type": {
								Type:     models.String,
								JsonName: "type",
							},
						},
					},
					"PrivateEndpointConnectionProperties": {
						Description: "",
						Fields: map[string]models.FieldDetails{
							"PrivateEndpoint": {
								Type:           models.Object,
								ModelReference: strPtr("PrivateEndpoint"),
								JsonName:       "privateEndpoint",
							},
							"PrivateLinkServiceConnectionState": {
								Type:           models.Object,
								ModelReference: strPtr("PrivateLinkServiceConnectionState"),
								JsonName:       "privateLinkServiceConnectionState",
								Required:       true,
							},
							"ProvisioningState": {
								Type:              models.Object,
								ConstantReference: strPtr("ProvisioningState"),
								JsonName:          "provisioningState",
							},
						},
					},
					"PrivateLinkServiceConnectionState": {
						Description: "",
						Fields: map[string]models.FieldDetails{
							"ActionsRequired": {
								Type:              models.Object,
								ConstantReference: strPtr("ActionsRequired"),
								JsonName:          "actionsRequired",
							},
							"Description": {
								Type:     models.String,
								JsonName: "description",
							},
							"Status": {
								Type:              models.Object,
								ConstantReference: strPtr("ConnectionStatus"),
								JsonName:          "status",
							},
						},
					},
				},
				Operations: map[string]models.OperationDetails{
					"CreateOrUpdate": {
						Method:            http.MethodPut,
						LongRunning:       true,
						RequestObjectName: strPtr("PrivateEndpointConnection"),
						Options:           map[string]models.OperationOption{},
						ResourceIdName:    strPtr("PrivateEndpointConnection"),
						ApiVersion:        strPtr("2020-06-01"),
						Uri:               "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AppConfiguration/configurationStores/{configStoreName}/privateEndpointConnections/{privateEndpointConnectionName}",
					},
					"Delete": {
						Method:      http.MethodDelete,
						LongRunning: true,
						ExpectedStatusCodes: []int{
							http.StatusOK,
							http.StatusAccepted,
							http.StatusNoContent,
						},
						Options:        map[string]models.OperationOption{},
						ResourceIdName: strPtr("PrivateEndpointConnection"),
						ApiVersion:     strPtr("2020-06-01"),
						Uri:            "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AppConfiguration/configurationStores/{configStoreName}/privateEndpointConnections/{privateEndpointConnectionName}",
					},
					"Get": {
						Method:             http.MethodGet,
						ResponseObjectName: strPtr("PrivateEndpointConnection"),
						Options:            map[string]models.OperationOption{},
						ResourceIdName:     strPtr("PrivateEndpointConnection"),
						ApiVersion:         strPtr("2020-06-01"),
						Uri:                "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AppConfiguration/configurationStores/{configStoreName}/privateEndpointConnections/{privateEndpointConnectionName}",
					},
				},
				ResourceIds: map[string]string{
					"PrivateEndpointConnection": "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AppConfiguration/configurationStores/{configStoreName}/privateEndpointConnections/{privateEndpointConnectionName}",
				},
			},
			"PrivateLinkResources": {
				Constants: map[string]models.ConstantDetails{},
				Models: map[string]models.ModelDetails{
					"PrivateLinkResource": {
						Description: "",
						Fields: map[string]models.FieldDetails{
							"Id": {
								Type:     models.String,
								JsonName: "id",
							},
							"Name": {
								Type:     models.String,
								JsonName: "name",
							},
							"Properties": {
								Type:           models.Object,
								ModelReference: strPtr("PrivateLinkResourceProperties"),
								JsonName:       "properties",
							},
							"Type": {
								Type:     models.String,
								JsonName: "type",
							},
						},
					},
					"PrivateLinkResourceProperties": {
						Description: "",
						Fields: map[string]models.FieldDetails{
							"GroupId": {
								Type:     models.String,
								JsonName: "groupId",
							},
							"RequiredMembers": {
								Type: models.List,
								ListElementType: func() *models.FieldDefinitionType {
									v := models.String
									return &v
								}(),
								JsonName: "requiredMembers",
							},
							"RequiredZoneNames": {
								Type: models.List,
								ListElementType: func() *models.FieldDefinitionType {
									v := models.String
									return &v
								}(),
								JsonName: "requiredZoneNames",
							},
						},
					},
				},
				Operations: map[string]models.OperationDetails{
					"Get": {
						ApiVersion:         strPtr("2020-06-01"),
						ContentType:        "",
						Method:             http.MethodGet,
						ResponseObjectName: strPtr("PrivateLinkResource"),
						ResourceIdName:     strPtr("PrivateLinkResource"),
						Uri:                "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AppConfiguration/configurationStores/{configStoreName}/privateLinkResources/{groupName}",
						Options:            map[string]models.OperationOption{},
					},
				},
				ResourceIds: map[string]string{
					"PrivateLinkResource": "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AppConfiguration/configurationStores/{configStoreName}/privateLinkResources/{groupName}",
				},
			},
		},
	}

	expectedJson, err := json.Marshal(expected)
	if err != nil {
		t.Fatalf("%s", err)
	}
	actualJson, err := json.Marshal(*result)
	if err != nil {
		t.Fatalf("%s", err)
	}

	if !reflect.DeepEqual(expectedJson, actualJson) {
		t.Fatalf("Expected: %s\n\nActual: %s", expectedJson, actualJson)
	}
}

func validateDirectory(serviceName, apiVersion, versionDirectory string) error {
	swaggerFiles, err := SwaggerFilesInDirectory(versionDirectory)
	if err != nil {
		return fmt.Errorf("parsing swagger files in %q: %+v", versionDirectory, err)
	}

	for _, file := range *swaggerFiles {
		log.Printf("[DEBUG]    - File %q..", file)

		fileName := strings.TrimPrefix(file, versionDirectory)
		parsedFile, err := Load(versionDirectory, fileName, true)
		if err != nil {
			return err
		}

		_, err = parsedFile.Parse(serviceName, apiVersion)
		if err != nil {
			return err
		}

		// TODO; something more useful with the result
	}

	return nil
}
