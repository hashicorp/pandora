package pipeline

import (
	"fmt"
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

func (p pipelineTask) translateServiceToDataApiSdkTypes(models Models, resources Resources) (*map[string]sdkModels.Service, error) {
	sdkServices := make(map[string]sdkModels.Service)

	for _, resource := range resources {
		// First scaffold all discovered services, version(s) and resources (categories)
		if _, ok := sdkServices[resource.Service]; !ok {
			sdkServices[resource.Service] = sdkModels.Service{
				APIVersions:         make(map[string]sdkModels.APIVersion),
				Generate:            true,
				ResourceProvider:    nil,
				TerraformDefinition: nil,
			}
		}

		if _, ok := sdkServices[resource.Service].APIVersions[resource.Version]; !ok {
			sdkServices[resource.Service].APIVersions[resource.Version] = sdkModels.APIVersion{
				Generate:  true,
				Preview:   versionIsPreview(resource.Version),
				Resources: make(map[string]sdkModels.APIResource),
				Source:    sdkModels.MicrosoftGraphMetaDataSourceDataOrigin,
			}
		}

		if _, ok := sdkServices[resource.Service].APIVersions[resource.Version].Resources[resource.Category]; !ok {
			sdkServices[resource.Service].APIVersions[resource.Version].Resources[resource.Category] = sdkModels.APIResource{
				Constants:   make(map[string]sdkModels.SDKConstant),
				Models:      make(map[string]sdkModels.SDKModel),
				Operations:  make(map[string]sdkModels.SDKOperation),
				ResourceIDs: make(map[string]sdkModels.ResourceID),
			}
		}

		serviceModels := make(Models)

		// Populate everything else
		for _, operation := range resource.Operations {
			var resourceIdName *string

			if operation.ResourceId != nil {
				resourceIdName = &operation.ResourceId.Name

				sdkResourceId, err := operation.ResourceId.DataApiSdkResourceId()
				if err != nil {
					return nil, err
				}

				sdkServices[resource.Service].APIVersions[resource.Version].Resources[resource.Category].ResourceIDs[operation.ResourceId.Name] = *sdkResourceId
			}

			var requestObject *sdkModels.SDKObjectDefinition

			if operation.RequestModel != nil {
				if !models.Found(*operation.RequestModel) {
					return nil, fmt.Errorf("request model not found")
				}

				if model := models[*operation.RequestModel]; !model.IsValid() {
					return nil, fmt.Errorf("request model was invalid")
				} else { //if !model.Common {
					if err := serviceModels.MergeDependants(models, *operation.RequestModel); err != nil {
						return nil, err
					}
				}

				requestObject = &sdkModels.SDKObjectDefinition{
					NestedItem:    nil,
					ReferenceName: operation.RequestModel,
					Type:          sdkModels.ReferenceSDKObjectDefinitionType,
				}
			} else if operation.RequestType != nil {
				requestObject = &sdkModels.SDKObjectDefinition{
					NestedItem:    nil,
					ReferenceName: nil,
					Type:          operation.RequestType.DataApiSdkObjectDefinitionType(),
				}
			}

			var responseObject *sdkModels.SDKObjectDefinition

			for _, response := range operation.Responses {
				if response.Type != nil && *response.Type == DataTypeModel && response.ModelName != nil {
					if !models.Found(*response.ModelName) {
						return nil, fmt.Errorf("response model not found")
					}

					if model := models[*response.ModelName]; !model.IsValid() {
						return nil, fmt.Errorf("response model was invalid")
					} else { //if !model.Common {
						if err := serviceModels.MergeDependants(models, *response.ModelName); err != nil {
							return nil, err
						}
					}

					responseObject = &sdkModels.SDKObjectDefinition{
						NestedItem:    nil,
						ReferenceName: response.ModelName,
						Type:          sdkModels.ReferenceSDKObjectDefinitionType,
					}
				} else if response.Type != nil {
					requestObject = &sdkModels.SDKObjectDefinition{
						NestedItem:    nil,
						ReferenceName: nil,
						Type:          response.Type.DataApiSdkObjectDefinitionType(),
					}
				}
			}

			contentType := "application/json"
			expectedStatusCodes := make([]int, 0)
			for _, response := range operation.Responses {
				expectedStatusCodes = append(expectedStatusCodes, response.Status)

				if response.ContentType != nil {
					contentType = *response.ContentType
				}
			}

			if contentType == "" {
				return nil, fmt.Errorf("unknown content type")
			}

			// TODO probably don't hardcode this, but it'll work fine for now
			paginationField := "@odata.nextLink"

			sdkServices[resource.Service].APIVersions[resource.Version].Resources[resource.Category].Operations[operation.Name] = sdkModels.SDKOperation{
				ContentType:                      contentType,
				ExpectedStatusCodes:              expectedStatusCodes,
				FieldContainingPaginationDetails: &paginationField,
				LongRunning:                      false,
				Method:                           operation.Method,
				Options:                          nil, // TODO request options for odata queries etc
				RequestObject:                    requestObject,
				ResourceIDName:                   resourceIdName,
				ResponseObject:                   responseObject,
				URISuffix:                        operation.UriSuffix,
			}
		}

		for modelName, model := range serviceModels {
			sdkModel, err := model.DataApiSdkModel(models)
			if err != nil {
				return nil, err
			}

			sdkServices[resource.Service].APIVersions[resource.Version].Resources[resource.Category].Models[modelName] = *sdkModel

			for _, field := range model.Fields {
				if field.ConstantName != nil {
					constantValues := make(map[string]string)
					for _, value := range field.Enum {
						constantValues[value] = value
					}

					// TODO support additional types, if there are any
					sdkServices[resource.Service].APIVersions[resource.Version].Resources[resource.Category].Constants[*field.ConstantName] = sdkModels.SDKConstant{
						Type:   sdkModels.StringSDKConstantType,
						Values: constantValues,
					}
				}
			}
		}
	}

	return &sdkServices, nil
}
