package pipeline

import (
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
					return &sdkServices, err
				}

				sdkServices[resource.Service].APIVersions[resource.Version].Resources[resource.Category].ResourceIDs[operation.ResourceId.Name] = *sdkResourceId
			}

			var requestObject *sdkModels.SDKObjectDefinition

			if operation.RequestModel != nil {
				if !models.Found(*operation.RequestModel) {
					panic("request model not found")
				}

				if model := models[*operation.RequestModel]; !model.IsValid() && !model.Common {
					if err := serviceModels.MergeDependants(models, *operation.RequestModel); err != nil {
						return &sdkServices, err
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
				if response.ModelName != nil {
					if !models.Found(*response.ModelName) {
						panic("response model not found")
					}

					if model := models[*response.ModelName]; !model.IsValid() && !model.Common {
						if err := serviceModels.MergeDependants(models, *response.ModelName); err != nil {
							return &sdkServices, err
						}
					}

					// TODO this is not right
					if operation.Type == OperationTypeList {
						responseObject = &sdkModels.SDKObjectDefinition{
							NestedItem: &sdkModels.SDKObjectDefinition{
								NestedItem:    nil,
								ReferenceName: response.ModelName,
								Type:          sdkModels.ReferenceSDKObjectDefinitionType,
							},
							ReferenceName: nil,
							Type:          sdkModels.ListSDKObjectDefinitionType,
						}
					} else {
						responseObject = &sdkModels.SDKObjectDefinition{
							NestedItem:    nil,
							ReferenceName: response.ModelName,
							Type:          sdkModels.ReferenceSDKObjectDefinitionType,
						}
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
				panic("unknown content type")
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
				return &sdkServices, err
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
