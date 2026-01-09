// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package models

import (
	"fmt"
	"strings"

	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

type ResourceInput struct {
	// Constants is a map of Constant Name (key) to SDKConstant (value) for the constants used within this SDK Resource
	Constants map[string]models.SDKConstant

	// Details contains information about the Terraform Resource which should be generated.
	Details models.TerraformResourceDefinition

	// Models is a map of Model Name (key) to SDKModel (value) for the models used within this SDK Resource
	Models map[string]models.SDKModel

	// Operations is a map of Operation Name (key) to SDKOperation (value) of the operations within this SDK Resource
	Operations map[string]models.SDKOperation

	// ProviderPrefix is the prefix used for the Terraform Provider (e.g. `azurerm`).
	ProviderPrefix string

	// ResourceIds is a map of ResourceID Name (key) to ResourceID (value) for the specified SdkResourceName
	ResourceIds map[string]models.ResourceID

	// ResourceLabel is the label used for this resource without the provider prefix (e.g. `resource_group`).
	ResourceLabel string

	// ResourceTypeName is the name of the Resource Type, used as the name of the struct.
	ResourceTypeName string

	// RootDirectory is the path to the directory where generated files should be output.
	RootDirectory string

	// SchemaModelName is the name of the Schema Model within SchemaModels used for this Resource
	SchemaModelName string

	// SchemaModels is a map of Schema Model Name (key) to TerraformSchemaModel (value).
	SchemaModels map[string]models.TerraformSchemaModel

	// SdkApiVersion is the API Version within the SdkServiceName which should be used.
	SdkApiVersion string

	// SdkResourceName is the name of the `resource` within the ApiVersion for this Service
	SdkResourceName string

	// SdkServiceName is the name of the `service` within `github.com/hashicorp/go-azure-sdk` which should be used.
	SdkServiceName string

	// ServiceName is the name of the `service` within the Data API
	ServiceName string

	// ServicePackageName is the name of the Service Package within the Terraform Provider repository.
	ServicePackageName string
}

func (id ResourceInput) ParseResourceIdFuncName() (*string, error) {
	resourceId, ok := id.ResourceIds[id.Details.ResourceIDName]
	if !ok {
		return nil, fmt.Errorf("missing Resource ID %q", id.Details.ResourceIDName)
	}

	if resourceId.CommonIDAlias != nil {
		out := fmt.Sprintf("commonids.Parse%[1]sID", *resourceId.CommonIDAlias)
		return &out, nil
	}

	out := fmt.Sprintf("%[1]s.Parse%[2]sID", strings.ToLower(id.SdkResourceName), strings.TrimSuffix(id.Details.ResourceIDName, "Id"))
	return &out, nil
}

func (id ResourceInput) NewResourceIdFuncName() (*string, error) {
	resourceId, ok := id.ResourceIds[id.Details.ResourceIDName]
	if !ok {
		return nil, fmt.Errorf("missing Resource ID %q", id.Details.ResourceIDName)
	}

	if resourceId.CommonIDAlias != nil {
		out := fmt.Sprintf("commonids.New%[1]sID", *resourceId.CommonIDAlias)
		return &out, nil
	}

	out := fmt.Sprintf("%[1]s.New%[2]sID", strings.ToLower(id.SdkResourceName), strings.TrimSuffix(id.Details.ResourceIDName, "Id"))
	return &out, nil
}

func (id ResourceInput) ValidateResourceIdFuncName() (*string, error) {
	resourceId, ok := id.ResourceIds[id.Details.ResourceIDName]
	if !ok {
		return nil, fmt.Errorf("missing Resource ID %q", id.Details.ResourceIDName)
	}

	if resourceId.CommonIDAlias != nil {
		out := fmt.Sprintf("commonids.Validate%[1]sID", *resourceId.CommonIDAlias)
		return &out, nil
	}

	out := fmt.Sprintf("%[1]s.Validate%[2]sID", strings.ToLower(id.SdkResourceName), strings.TrimSuffix(id.Details.ResourceIDName, "Id"))
	return &out, nil
}
