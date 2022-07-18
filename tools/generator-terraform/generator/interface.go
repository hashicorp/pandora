package generator

import (
	"fmt"
	"strings"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

type ResourceInput struct {
	// Constants is a map of key (ConstantName) to value (ConstantDetails) for the constants used within this SDK Resource
	Constants map[string]resourcemanager.ConstantDetails

	// Details contains information about the Terraform Resource which should be generated.
	Details resourcemanager.TerraformResourceDetails

	// Models is a map of key (ModelName) to value (ModelDetails) for the models used within this SDK Resource
	Models map[string]resourcemanager.ModelDetails

	// Operations is a map of key (OperationName) to value (ApiOperation) of the operations within this SDK Resource
	Operations map[string]resourcemanager.ApiOperation

	// ProviderPrefix is the prefix used for the Terraform Provider (e.g. `azurerm`).
	ProviderPrefix string

	// ResourceIds is a map of key (ResourceIdName) to value (ResourceIdDefinition) for the specified SdkResourceName
	ResourceIds map[string]resourcemanager.ResourceIdDefinition

	// ResourceLabel is the label used for this resource without the provider prefix (e.g. `resource_group`).
	ResourceLabel string

	// ResourceTypeName is the name of the Resource Type, used as the name of the struct.
	ResourceTypeName string

	// RootDirectory is the path to the directory where generated files should be output.
	RootDirectory string

	// ServiceName is the name of the `service` within the Data API
	ServiceName string

	// ServicePackageName is the name of the Service Package within the Terraform Provider repository.
	ServicePackageName string

	// SdkApiVersion is the API Version within the SdkServiceName which should be used.
	SdkApiVersion string

	// SdkResourceName is the name of the `resource` within the ApiVersion for this Service
	SdkResourceName string

	// SdkServiceName is the name of the `service` within `github.com/hashicorp/go-azure-sdk` which should be used.
	SdkServiceName string
}

func (id ResourceInput) parseResourceIdFuncName() (*string, error) {
	resourceId, ok := id.ResourceIds[id.Details.ResourceIdName]
	if !ok {
		return nil, fmt.Errorf("missing Resource ID %q", id.Details.ResourceIdName)
	}

	if resourceId.CommonAlias != nil {
		out := fmt.Sprintf("commonids.Parse%[1]sID", *resourceId.CommonAlias)
		return &out, nil
	}

	out := fmt.Sprintf("%[1]s.Parse%[2]sID", id.SdkResourceName, strings.TrimSuffix(id.Details.ResourceIdName, "Id"))
	return &out, nil
}

func (id ResourceInput) newResourceIdFuncName() (*string, error) {
	resourceId, ok := id.ResourceIds[id.Details.ResourceIdName]
	if !ok {
		return nil, fmt.Errorf("missing Resource ID %q", id.Details.ResourceIdName)
	}

	if resourceId.CommonAlias != nil {
		out := fmt.Sprintf("commonids.New%[1]sID", *resourceId.CommonAlias)
		return &out, nil
	}

	out := fmt.Sprintf("%[1]s.New%[2]sID", id.SdkResourceName, strings.TrimSuffix(id.Details.ResourceIdName, "Id"))
	return &out, nil
}

func (id ResourceInput) validateResourceIdFuncName() (*string, error) {
	resourceId, ok := id.ResourceIds[id.Details.ResourceIdName]
	if !ok {
		return nil, fmt.Errorf("missing Resource ID %q", id.Details.ResourceIdName)
	}

	if resourceId.CommonAlias != nil {
		out := fmt.Sprintf("commonids.Validate%[1]sID", *resourceId.CommonAlias)
		return &out, nil
	}

	out := fmt.Sprintf("%[1]s.Validate%[2]sID", id.SdkResourceName, strings.TrimSuffix(id.Details.ResourceIdName, "Id"))
	return &out, nil
}
