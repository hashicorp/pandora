// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package transforms

import (
	"fmt"

	repositoryModels "github.com/hashicorp/pandora/tools/data-api-repository/models"
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

func mapResourceIdSegmentToRepository(input sdkModels.ResourceIDSegment) (*repositoryModels.ResourceIdSegment, error) {
	if input.Type == sdkModels.ConstantResourceIDSegmentType {
		if input.ConstantReference == nil {
			return nil, fmt.Errorf("constant segment type with missing constant reference: %+v", input)
		}
		return &repositoryModels.ResourceIdSegment{
			Name:         input.Name,
			Type:         repositoryModels.ConstantResourceIdSegmentType,
			ConstantName: input.ConstantReference,
		}, nil
	}

	if input.Type == sdkModels.ResourceGroupResourceIDSegmentType {
		return &repositoryModels.ResourceIdSegment{
			Name: input.Name,
			Type: repositoryModels.ResourceGroupResourceIdSegmentType,
		}, nil
	}

	if input.Type == sdkModels.ResourceProviderResourceIDSegmentType {
		if input.FixedValue == nil {
			return nil, fmt.Errorf("resource provider segment type with missing fixed value: %+v", input)
		}

		return &repositoryModels.ResourceIdSegment{
			Name:  input.Name,
			Type:  repositoryModels.ResourceProviderResourceIdSegmentType,
			Value: input.FixedValue,
		}, nil
	}

	if input.Type == sdkModels.ScopeResourceIDSegmentType {
		return &repositoryModels.ResourceIdSegment{
			Name: input.Name,
			Type: repositoryModels.ScopeResourceIdSegmentType,
		}, nil
	}

	if input.Type == sdkModels.StaticResourceIDSegmentType {
		if input.FixedValue == nil {
			return nil, fmt.Errorf("static segment type with missing fixed value: %+v", input)
		}
		return &repositoryModels.ResourceIdSegment{
			Type:  repositoryModels.StaticResourceIdSegmentType,
			Name:  input.Name,
			Value: input.FixedValue,
		}, nil
	}

	if input.Type == sdkModels.SubscriptionIDResourceIDSegmentType {
		return &repositoryModels.ResourceIdSegment{
			Type: repositoryModels.SubscriptionIdResourceIdSegmentType,
			Name: input.Name,
		}, nil
	}

	if input.Type == sdkModels.UserSpecifiedResourceIDSegmentType {
		return &repositoryModels.ResourceIdSegment{
			Type: repositoryModels.UserSpecifiedResourceIdSegmentType,
			Name: input.Name,
		}, nil
	}

	return nil, fmt.Errorf("internal-error: unimplemented segment type %q", string(input.Type))
}
