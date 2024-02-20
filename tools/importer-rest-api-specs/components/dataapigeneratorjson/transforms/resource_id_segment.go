package transforms

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/sdk/dataapimodels"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func mapResourceIdSegmentToRepository(input resourcemanager.ResourceIdSegment) (*dataapimodels.ResourceIdSegment, error) {
	if input.Type == resourcemanager.ConstantSegment {
		if input.ConstantReference == nil {
			return nil, fmt.Errorf("constant segment type with missing constant reference: %+v", input)
		}
		return &dataapimodels.ResourceIdSegment{
			Name:         input.Name,
			Type:         dataapimodels.ConstantResourceIdSegmentType,
			ConstantName: input.ConstantReference,
		}, nil
	}

	if input.Type == resourcemanager.ResourceGroupSegment {
		return &dataapimodels.ResourceIdSegment{
			Name: input.Name,
			Type: dataapimodels.ResourceGroupResourceIdSegmentType,
		}, nil
	}

	if input.Type == resourcemanager.ResourceProviderSegment {
		if input.FixedValue == nil {
			return nil, fmt.Errorf("resource provider segment type with missing fixed value: %+v", input)
		}

		return &dataapimodels.ResourceIdSegment{
			Name:  input.Name,
			Type:  dataapimodels.ResourceProviderResourceIdSegmentType,
			Value: input.FixedValue,
		}, nil
	}

	if input.Type == resourcemanager.ScopeSegment {
		return &dataapimodels.ResourceIdSegment{
			Name: input.Name,
			Type: dataapimodels.ScopeResourceIdSegmentType,
		}, nil
	}

	if input.Type == resourcemanager.StaticSegment {
		if input.FixedValue == nil {
			return nil, fmt.Errorf("static segment type with missing fixed value: %+v", input)
		}
		return &dataapimodels.ResourceIdSegment{
			Type:  dataapimodels.StaticResourceIdSegmentType,
			Name:  input.Name,
			Value: input.FixedValue,
		}, nil
	}

	if input.Type == resourcemanager.SubscriptionIdSegment {
		return &dataapimodels.ResourceIdSegment{
			Type: dataapimodels.SubscriptionIdResourceIdSegmentType,
			Name: input.Name,
		}, nil
	}

	if input.Type == resourcemanager.UserSpecifiedSegment {
		return &dataapimodels.ResourceIdSegment{
			Type: dataapimodels.UserSpecifiedResourceIdSegmentType,
			Name: input.Name,
		}, nil
	}

	return nil, fmt.Errorf("internal-error: unimplemented segment type %q", string(input.Type))
}
