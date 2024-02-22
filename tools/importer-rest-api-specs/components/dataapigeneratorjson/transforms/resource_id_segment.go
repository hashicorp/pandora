// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package transforms

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/sdk/dataapimodels"
)

func mapResourceIdSegmentToRepository(input models.ResourceIDSegment) (*dataapimodels.ResourceIdSegment, error) {
	if input.Type == models.ConstantResourceIDSegmentType {
		if input.ConstantReference == nil {
			return nil, fmt.Errorf("constant segment type with missing constant reference: %+v", input)
		}
		return &dataapimodels.ResourceIdSegment{
			Name:         input.Name,
			Type:         dataapimodels.ConstantResourceIdSegmentType,
			ConstantName: input.ConstantReference,
		}, nil
	}

	if input.Type == models.ResourceGroupResourceIDSegmentType {
		return &dataapimodels.ResourceIdSegment{
			Name: input.Name,
			Type: dataapimodels.ResourceGroupResourceIdSegmentType,
		}, nil
	}

	if input.Type == models.ResourceProviderResourceIDSegmentType {
		if input.FixedValue == nil {
			return nil, fmt.Errorf("resource provider segment type with missing fixed value: %+v", input)
		}

		return &dataapimodels.ResourceIdSegment{
			Name:  input.Name,
			Type:  dataapimodels.ResourceProviderResourceIdSegmentType,
			Value: input.FixedValue,
		}, nil
	}

	if input.Type == models.ScopeResourceIDSegmentType {
		return &dataapimodels.ResourceIdSegment{
			Name: input.Name,
			Type: dataapimodels.ScopeResourceIdSegmentType,
		}, nil
	}

	if input.Type == models.StaticResourceIDSegmentType {
		if input.FixedValue == nil {
			return nil, fmt.Errorf("static segment type with missing fixed value: %+v", input)
		}
		return &dataapimodels.ResourceIdSegment{
			Type:  dataapimodels.StaticResourceIdSegmentType,
			Name:  input.Name,
			Value: input.FixedValue,
		}, nil
	}

	if input.Type == models.SubscriptionIDResourceIDSegmentType {
		return &dataapimodels.ResourceIdSegment{
			Type: dataapimodels.SubscriptionIdResourceIdSegmentType,
			Name: input.Name,
		}, nil
	}

	if input.Type == models.UserSpecifiedResourceIDSegmentType {
		return &dataapimodels.ResourceIdSegment{
			Type: dataapimodels.UserSpecifiedResourceIdSegmentType,
			Name: input.Name,
		}, nil
	}

	return nil, fmt.Errorf("internal-error: unimplemented segment type %q", string(input.Type))
}
