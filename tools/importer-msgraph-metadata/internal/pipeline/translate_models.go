package pipeline

import sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"

func translateModelsToDataApiSdkTypes(models Models) (*sdkModels.CommonTypes, error) {
	sdkConstantsMap := make(map[string]sdkModels.SDKConstant)
	sdkModelsMap := make(map[string]sdkModels.SDKModel)

	for modelName, model := range models {
		sdkModel, err := model.DataApiSdkModel(models)
		if err != nil {
			return nil, err
		}
		sdkModelsMap[modelName] = *sdkModel

		for _, field := range model.Fields {
			if field.ConstantName != nil {
				constantValues := make(map[string]string)
				for _, value := range field.Enum {
					constantValues[value] = value
				}

				// TODO support additional types, if there are any
				sdkConstantsMap[*field.ConstantName] = sdkModels.SDKConstant{
					Type:   sdkModels.StringSDKConstantType,
					Values: constantValues,
				}
			}
		}
	}

	return &sdkModels.CommonTypes{
		Constants: sdkConstantsMap,
		Models:    sdkModelsMap,
	}, nil
}
