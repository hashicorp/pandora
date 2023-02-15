package dataworkarounds

import (
	"fmt"
	"strings"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/parser/cleanup"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

var _ workaround = workaroundInconsistentlyDefinedSegments{}

type workaroundInconsistentlyDefinedSegments struct{}

func (workaroundInconsistentlyDefinedSegments) IsApplicable(_ *models.AzureApiDefinition) bool {
	return true
}

func (workaroundInconsistentlyDefinedSegments) Name() string {
	return "Workaround Inconsistently Defined Resource ID Segments"
}

func (workaroundInconsistentlyDefinedSegments) Process(apiDefinition models.AzureApiDefinition) (*models.AzureApiDefinition, error) {
	resources := make(map[string]models.AzureApiResource, 0)
	for resourceName := range apiDefinition.Resources {
		resource := apiDefinition.Resources[resourceName]

		ids := make(map[string]models.ParsedResourceId, 0)
		for key := range resource.ResourceIds {
			id := resource.ResourceIds[key]
			segments := make([]resourcemanager.ResourceIdSegment, 0)
			for i, val := range id.Segments {
				if i > 0 && val.Type == resourcemanager.UserSpecifiedSegment {
					// switch out the name of the User Specified Segment presuming it's not an `{val}Id` or `{val}Key`, since these names make more sense
					// this works around issues in the Swagger where the same URI may be defined differently depending on the endpoint
					if !strings.HasSuffix(val.Name, "Alias") && !strings.HasSuffix(val.Name, "Id") && !strings.HasSuffix(val.Name, "Key") && !strings.HasSuffix(val.Name, "Identifier") {
						previous := segments[i-1]
						if previous.Type == resourcemanager.StaticSegment && previous.FixedValue != nil {
							singularNameOfPrevious := cleanup.GetSingular(*previous.FixedValue)
							val.Name = fmt.Sprintf("%sName", singularNameOfPrevious)
						}
					}
				}
				segments = append(segments, val)
			}
			id.Segments = segments
			ids[key] = id
		}
		resource.ResourceIds = ids
		resources[resourceName] = resource
	}
	apiDefinition.Resources = resources
	return &apiDefinition, nil
}
