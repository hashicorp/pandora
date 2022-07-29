package resource

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func findTopLevelFieldForResourceIdSegment(segmentName string, terraformModel resourcemanager.TerraformSchemaModelDefinition) (*string, error) {
	for k, v := range terraformModel.Fields {
		if v.Mappings.ResourceIdSegment == nil {
			continue
		}

		if *v.Mappings.ResourceIdSegment == segmentName {
			return &k, nil
		}
	}

	return nil, fmt.Errorf("no Resource ID mapping defined for segment %q", segmentName)
}
