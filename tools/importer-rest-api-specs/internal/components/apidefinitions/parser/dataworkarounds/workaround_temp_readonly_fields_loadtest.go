package dataworkarounds

import (
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

var _ workaround = workaroundTempReadOnlyFieldsLoadTest{}

type workaroundTempReadOnlyFieldsLoadTest struct {
}

func (w workaroundTempReadOnlyFieldsLoadTest) IsApplicable(serviceName string, apiVersion sdkModels.APIVersion) bool {
	return serviceName == "LoadTestService" && apiVersion.APIVersion == "2022-12-01"
}

func (w workaroundTempReadOnlyFieldsLoadTest) Name() string {
	return "Temp - Mark readonly fields as readonly - LoadTest"
}

func (w workaroundTempReadOnlyFieldsLoadTest) Process(input sdkModels.APIVersion) (*sdkModels.APIVersion, error) {
	definition, err := markFieldAsComputed(input, "LoadTests", "LoadTestProperties", "DataPlaneURI")
	if err != nil {
		return nil, err
	}

	return definition, nil
}
