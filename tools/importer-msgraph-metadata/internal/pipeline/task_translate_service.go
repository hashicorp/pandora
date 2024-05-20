package pipeline

import sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"

func (p pipelineTask) translateServiceToDataApiSdkTypes(models Models, resources Resources) (*map[string]sdkModels.Service, error) {

	sdkServices := make(map[string]sdkModels.Service, 0)

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

		// Populate everything else
		for _, operation := range resource.Operations {
			var resourceIdName *string

			if operation.ResourceId != nil {
				resourceIdName = &operation.ResourceId.Name

				sdkResourceId := sdkModels.ResourceID{
					CommonIDAlias: nil,
					ConstantNames: nil,
					Constants:     nil,
					ExampleValue:  operation.ResourceId.ID(),
					Segments:      make([]sdkModels.ResourceIDSegment, 0, len(operation.ResourceId.Segments)),
				}

				for _, segment := range operation.ResourceId.Segments {
					switch segment.Type {
					case SegmentAction, SegmentCast, SegmentFunction, SegmentLabel, SegmentODataReference:
						sdkResourceId.Segments = append(sdkResourceId.Segments, sdkModels.ResourceIDSegment{
							ConstantReference: nil,
							FixedValue:        &segment.Value,
							Type:              sdkModels.StaticResourceIDSegmentType,
							Name:              segment.Value,
						})
					case SegmentUserValue:
						sdkResourceId.Segments = append(sdkResourceId.Segments, sdkModels.ResourceIDSegment{
							ConstantReference: nil,
							FixedValue:        nil,
							Type:              sdkModels.UserSpecifiedSegment,
							Name:              *segment.Field,
						})
					default:
						panic("unknown segment type")
					}
				}

				sdkServices[resource.Service].APIVersions[resource.Version].Resources[resource.Category].ResourceIDs[operation.ResourceId.Name] = sdkResourceId
			}

			var requestObject *sdkModels.SDKObjectDefinition

			if operation.RequestModel != nil {
				if !models.Found(*operation.RequestModel) {
					panic("request model not found")
				}

				requestObject = &sdkModels.SDKObjectDefinition{
					NestedItem:    nil,
					ReferenceName: operation.RequestModel,
					Type:          sdkModels.ReferenceSDKObjectDefinitionType,
				}

				if !models[*operation.RequestModel].Common {
					// TODO convert model
					//sdkModel := sdkModels.SDKModel{
					//	DiscriminatedValue:                    nil,
					//	FieldNameContainingDiscriminatedValue: nil,
					//	Fields:                                make(map[string]sdkModels.SDKField),
					//	ParentTypeName:                        nil,
					//}
				}
			}

			if operation.RequestType != nil {
				var requestObjectType sdkModels.SDKObjectDefinitionType

				switch *operation.RequestType {
				case DataTypeInteger64, DataTypeIntegerUnsigned64, DataTypeInteger32, DataTypeIntegerUnsigned32, DataTypeInteger16, DataTypeIntegerUnsigned16, DataTypeInteger8, DataTypeIntegerUnsigned8:
					requestObjectType = sdkModels.IntegerSDKObjectDefinitionType
				case DataTypeFloat64, DataTypeFloat32:
					requestObjectType = sdkModels.FloatSDKObjectDefinitionType
				case DataTypeDateTime, DataTypeDate, DataTypeTime:
					requestObjectType = sdkModels.DateTimeSDKObjectDefinitionType
				case DataTypeBase64, DataTypeDuration, DataTypeString, DataTypeUuid:
					requestObjectType = sdkModels.StringSDKObjectDefinitionType
				}

				requestObject = &sdkModels.SDKObjectDefinition{
					NestedItem:    nil,
					ReferenceName: nil,
					Type:          requestObjectType,
				}
			}

			var responseObject *sdkModels.SDKObjectDefinition

			for _, response := range operation.Responses {
				if response.ModelName != nil {
					if !models.Found(*response.ModelName) {
						panic("response model not found")
					}

					if !models[*response.ModelName].Common {
						// TODO convert model
					}

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
	}

	return &sdkServices, nil
}
