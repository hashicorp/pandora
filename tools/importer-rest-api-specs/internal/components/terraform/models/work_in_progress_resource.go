// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package models

import (
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/sdk/config/definitions"
)

// WorkInProgressResource is an intermediate type used by the `terraform` package to enable
// building a Terraform Resource component-by-component. It contains both the WIP Resource,
// the InputData used to identify the resource (which can in turn contain test data and defaults)
// but is ultimately only used within this package to build Resources.
//
// NOTE: this should only be used within the `terraform` package - with the SDK Model `TerraformResourceDefinition`
// used elsewhere.
type WorkInProgressResource struct {
	// APIResource contains the APIResource that's used for this Terraform Resource.
	APIResource models.APIResource

	// InputData contains the SourceData used to identify this Terraform Resource, alongside any defaults,
	// documentation and test values.
	InputData definitions.ResourceDefinition

	// Resource contains the work-in-progress Terraform Resource that's being built up - and will ultimately
	// be returned from the `terraform` package once it's completed.
	Resource models.TerraformResourceDefinition
}
