package dataworkarounds

import (
	"errors"
	"fmt"

	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

// Workaround for a type change on typespec migration
// request/response object types changed to `string` which is problematic for go-azure-sdk
var _ workaround = WorkaroundAutomation42369{}

type WorkaroundAutomation42369 struct{}

func (w WorkaroundAutomation42369) IsApplicable(serviceName string, apiVersion sdkModels.APIVersion) bool {
	return serviceName == "Automation" && apiVersion.APIVersion == "2024-10-23"
}

func (w WorkaroundAutomation42369) Name() string {
	return "Automation / 42369"
}

func (w WorkaroundAutomation42369) Process(input sdkModels.APIVersion) (*sdkModels.APIVersion, error) {
	runbook, ok := input.Resources["Runbook"]
	if !ok {
		return nil, errors.New("expected a `Runbook` resource but didn't get one")
	}

	runbookDraft, ok := input.Resources["RunbookDraft"]
	if !ok {
		return nil, errors.New("expected a `RunbookDraft` resource but didn't get one")
	}

	for _, resource := range []sdkModels.APIResource{runbook, runbookDraft} {
		operation, ok := resource.Operations["GetContent"]
		if !ok {
			return nil, fmt.Errorf("%s - expected an Operation named `GetContent` but didn't get one", resource.Name)
		}
		if operation.ResponseObject == nil {
			return nil, fmt.Errorf("%s - expected a non-nil RequestObject for Operation named `GetContent`", resource.Name)
		}
		if operation.ResponseObject.Type == sdkModels.RawFileSDKObjectDefinitionType {
			return nil, fmt.Errorf("%s - expected RequestObject.Type for Operation named `GetContent` to not be %s, this workaround can be removed", resource.Name, sdkModels.RawFileSDKObjectDefinitionType)
		}
		operation.ResponseObject.Type = sdkModels.RawFileSDKObjectDefinitionType
		resource.Operations["GetContent"] = operation
	}

	operation, ok := runbookDraft.Operations["ReplaceContent"]
	if !ok {
		return nil, errors.New("expected an Operation named `ReplaceContent` but didn't get one")
	}
	if operation.RequestObject == nil {
		return nil, errors.New("expected a non-nil RequestObject for Operation named `ReplaceContent`")
	}
	if operation.RequestObject.Type == sdkModels.RawFileSDKObjectDefinitionType {
		return nil, fmt.Errorf("expected RequestObject.Type for Operation named `ReplaceContent` to not be %s, this workaround can be removed", sdkModels.RawFileSDKObjectDefinitionType)
	}
	operation.RequestObject.Type = sdkModels.RawFileSDKObjectDefinitionType
	runbookDraft.Operations["ReplaceContent"] = operation

	input.Resources["Runbook"] = runbook
	input.Resources["RunbookDraft"] = runbookDraft
	return &input, nil
}
