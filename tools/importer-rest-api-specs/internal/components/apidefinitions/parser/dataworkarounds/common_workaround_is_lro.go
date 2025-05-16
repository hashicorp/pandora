package dataworkarounds

import (
	"fmt"
	"slices"

	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

// This is a common workaround for operations that are asynchronous but don't specify the `x-ms-long-running-operation` field as `true`
var _ workaround = commonWorkaroundIsLRO{}

type commonWorkaroundIsLRO struct {
	serviceName string
	apiVersions []string
	resources   []string
	operations  []string
}

func (w commonWorkaroundIsLRO) IsApplicable(serviceName string, apiVersion sdkModels.APIVersion) bool {
	return serviceName == w.serviceName && slices.Contains(w.apiVersions, apiVersion.APIVersion)
}

func (w commonWorkaroundIsLRO) Name() string {
	return fmt.Sprintf("Common Workaround `Is LRO` for `%s`", w.serviceName)
}

func (w commonWorkaroundIsLRO) Process(input sdkModels.APIVersion) (*sdkModels.APIVersion, error) {
	for _, resource := range w.resources {
		r, ok := input.Resources[resource]
		if !ok {
			return nil, fmt.Errorf("expected a resource named `%s` but didn't find one", resource)
		}

		for _, operation := range w.operations {
			o, ok := r.Operations[operation]
			if !ok {
				return nil, fmt.Errorf("couldn't find operation `%s`", operation)
			}

			if o.LongRunning {
				return nil, fmt.Errorf("expected operation `%s` to not be marked as `LongRunning`. The workaround for this operation should be removed", operation)
			}

			o.LongRunning = true
			r.Operations[operation] = o
		}

		input.Resources[resource] = r
	}

	return &input, nil
}
