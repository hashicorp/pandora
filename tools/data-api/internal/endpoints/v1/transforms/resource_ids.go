// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package transforms

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/data-api/internal/repositories"
)

var resourceIdSegmentType = map[repositories.ResourceIdSegmentType]models.ResourceIDSegmentType{
	repositories.ConstantResourceIdSegmentType:         models.ConstantResourceIDSegmentType,
	repositories.ResourceGroupResourceIdSegmentType:    models.ResourceGroupResourceIDSegmentType,
	repositories.ResourceProviderResourceIdSegmentType: models.ResourceProviderResourceIDSegmentType,
	repositories.ScopeResourceIdSegmentType:            models.ScopeResourceIDSegmentType,
	repositories.StaticResourceIdSegmentType:           models.StaticResourceIDSegmentType,
	repositories.SubscriptionIdResourceIdSegmentType:   models.SubscriptionIDResourceIDSegmentType,
	repositories.UserSpecifiedResourceIdSegmentType:    models.UserSpecifiedResourceIDSegmentType,
}

func MapResourceIDs(input map[string]repositories.ResourceIdDefinition, availableConstants map[string]models.SDKConstant) (*map[string]models.ResourceID, error) {
	output := make(map[string]models.ResourceID)
	for key, value := range input {
		mapped, err := mapResourceID(value, availableConstants)
		if err != nil {
			return nil, fmt.Errorf("mapping ResourceID %q: %+v", key, err)
		}
		output[key] = *mapped
	}
	return &output, nil
}

func mapResourceID(input repositories.ResourceIdDefinition, availableConstants map[string]models.SDKConstant) (*models.ResourceID, error) {
	segments, err := mapResourceIDSegments(input.Segments)
	if err != nil {
		return nil, fmt.Errorf("mapping Segments: %+v", err)
	}

	constants := make(map[string]models.SDKConstant)
	for _, segment := range *segments {
		if segment.ConstantReference == nil {
			continue
		}

		val, ok := availableConstants[*segment.ConstantReference]
		if !ok {
			return nil, fmt.Errorf("the Constant %q was referenced but not found", *segment.ConstantReference)
		}
		constants[*segment.ConstantReference] = val
	}

	return &models.ResourceID{
		CommonIDAlias: input.CommonAlias,
		ConstantNames: input.ConstantNames, // TODO: remove this once everything is switched over
		Constants:     constants,
		ExampleValue:  input.Id,
		Segments:      *segments,
	}, nil
}

func mapResourceIDSegments(input []repositories.ResourceIdSegment) (*[]models.ResourceIDSegment, error) {
	output := make([]models.ResourceIDSegment, 0)

	for i, item := range input {
		segmentType, ok := resourceIdSegmentType[item.Type]
		if !ok {
			return nil, fmt.Errorf("internal-error: mapping ResourceIDSegment %d - missing mapping for %q", i, string(item.Type))
		}

		output = append(output, models.ResourceIDSegment{
			ConstantReference: item.ConstantReference,
			ExampleValue:      item.ExampleValue,
			FixedValue:        item.FixedValue,
			Type:              segmentType,
			Name:              item.Name,
		})
	}

	return &output, nil
}
