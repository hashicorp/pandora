// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package dataworkarounds

import (
	"fmt"
	"strings"

	sdkHelpers "github.com/hashicorp/pandora/tools/data-api-sdk/v1/helpers"
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/apidefinitions/parser/cleanup"
)

var _ workaround = workaroundInconsistentlyDefinedSegments{}

type workaroundInconsistentlyDefinedSegments struct{}

func (workaroundInconsistentlyDefinedSegments) IsApplicable(_ string, _ sdkModels.APIVersion) bool {
	return true
}

func (workaroundInconsistentlyDefinedSegments) Name() string {
	return "Workaround Inconsistently Defined Resource ID Segments"
}

func (workaroundInconsistentlyDefinedSegments) Process(input sdkModels.APIVersion) (*sdkModels.APIVersion, error) {
	resources := make(map[string]sdkModels.APIResource)
	for resourceName := range input.Resources {
		resource := input.Resources[resourceName]

		ids := make(map[string]sdkModels.ResourceID)
		for key := range resource.ResourceIDs {
			id := resource.ResourceIDs[key]
			segments := make([]sdkModels.ResourceIDSegment, 0)
			for i, val := range id.Segments {
				if i > 0 && val.Type == sdkModels.UserSpecifiedResourceIDSegmentType {
					// switch out the name of the User Specified Segment presuming it's not an `{val}Id` or `{val}Key`, since these names make more sense
					// this works around issues in the Swagger where the same URI may be defined differently depending on the endpoint
					if !strings.HasSuffix(val.Name, "Alias") && !strings.HasSuffix(val.Name, "Id") && !strings.HasSuffix(val.Name, "Key") && !strings.HasSuffix(val.Name, "Identifier") {
						previous := segments[i-1]
						if previous.Type == sdkModels.StaticResourceIDSegmentType && previous.FixedValue != nil {
							singularNameOfPrevious := cleanup.GetSingular(*previous.FixedValue)
							val.Name = singularNameOfPrevious
							if !strings.HasSuffix(val.Name, "Name") {
								val.Name = fmt.Sprintf("%sName", singularNameOfPrevious)
								// the parser sets the same value into Name and ExampleValue so this needs to be applied to ExampleValue as well
								val.ExampleValue = fmt.Sprintf("%sName", singularNameOfPrevious)
							}
						}
					}
				}
				segments = append(segments, val)
			}
			id.Segments = segments
			id.ExampleValue = sdkHelpers.DisplayValueForResourceID(id)
			ids[key] = id
		}
		resource.ResourceIDs = ids
		resources[resourceName] = resource
	}
	input.Resources = resources
	return &input, nil
}
