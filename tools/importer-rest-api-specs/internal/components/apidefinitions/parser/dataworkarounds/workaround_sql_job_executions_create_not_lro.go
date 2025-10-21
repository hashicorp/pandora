package dataworkarounds

import (
	"errors"

	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

type WorkaroundSqlJobExecutionsCreateNotLRO struct{}

var _ workaround = WorkaroundSqlJobExecutionsCreateNotLRO{}

func (w WorkaroundSqlJobExecutionsCreateNotLRO) IsApplicable(serviceName string, _ sdkModels.APIVersion) bool {
	// Apply this workaround regardless of the API version.
	// This isn't technically an API issue, our use-case requires this to not be marked as an LRO
	return serviceName == "Sql"
}

func (w WorkaroundSqlJobExecutionsCreateNotLRO) Name() string {
	return "Sql / Mark Job Executions Create As Not LRO"
}

func (w WorkaroundSqlJobExecutionsCreateNotLRO) Process(input sdkModels.APIVersion) (*sdkModels.APIVersion, error) {
	resource, ok := input.Resources["JobExecutions"]
	if !ok {
		return nil, errors.New("expected a resource named `JobExecutions` but didn't get one")
	}

	operation, ok := resource.Operations["Create"]
	if !ok {
		return nil, errors.New("couldn't find operation `Create`")
	}

	operation.LongRunning = false
	resource.Operations["Create"] = operation
	input.Resources["JobExecutions"] = resource

	return &input, nil
}
