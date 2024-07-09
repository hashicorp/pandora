package parser

import (
	"fmt"
	"strings"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	sdkHelpers "github.com/hashicorp/pandora/tools/data-api-sdk/v1/helpers"
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

func resourceIdUsesAResourceProviderOtherThan(input *sdkModels.ResourceID, resourceProvider *string) (*bool, error) {
	if input == nil || resourceProvider == nil {
		return pointer.To(false), nil
	}

	for i, segment := range input.Segments {
		if segment.Type != sdkModels.ResourceProviderResourceIDSegmentType {
			continue
		}

		if segment.FixedValue == nil {
			return nil, fmt.Errorf("the Resource ID %q Segment %d was a ResourceProviderSegment with no FixedValue", sdkHelpers.DisplayValueForResourceID(*input), i)
		}
		if !strings.EqualFold(*segment.FixedValue, *resourceProvider) {
			return pointer.To(true), nil
		}
	}
	return pointer.To(false), nil
}
