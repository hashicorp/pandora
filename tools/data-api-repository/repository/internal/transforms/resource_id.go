// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package transforms

import (
	"fmt"

	repositoryModels "github.com/hashicorp/pandora/tools/data-api-repository/repository/internal/models"
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

func MapResourceIDFromRepository(input repositoryModels.ResourceId, availableConstants map[string]sdkModels.SDKConstant) (*sdkModels.ResourceID, error) {
	segments := make([]sdkModels.ResourceIDSegment, 0)
	for _, inputSegment := range input.Segments {
		outputSegment, err := mapResourceIdSegmentFromRepository(inputSegment, availableConstants)
		if err != nil {
			return nil, fmt.Errorf("mapping the Resource ID segment: %+v", err)
		}
		segments = append(segments, *outputSegment)
	}

	constantsUsed := make(map[string]sdkModels.SDKConstant)
	for _, segment := range segments {
		if segment.ConstantReference == nil {
			continue
		}
		constant, ok := availableConstants[*segment.ConstantReference]
		if !ok {
			return nil, fmt.Errorf("the constant %q referenced in a constant segment was not found", *segment.ConstantReference)
		}
		constantsUsed[*segment.ConstantReference] = constant
	}
	// on the off chance a constant is in their twice
	constantNamesUsed := make([]string, 0)
	for k := range constantsUsed {
		constantNamesUsed = append(constantNamesUsed, k)
	}

	return &sdkModels.ResourceID{
		CommonIDAlias: input.CommonAlias,
		ConstantNames: constantNamesUsed,
		Constants:     constantsUsed,
		ExampleValue:  input.Id,
		Segments:      segments,
	}, nil
}

func MapResourceIDToRepository(name string, input sdkModels.ResourceID) (*repositoryModels.ResourceId, error) {
	segments := make([]repositoryModels.ResourceIdSegment, 0)
	for _, inputSegment := range input.Segments {
		outputSegment, err := mapResourceIdSegmentToRepository(inputSegment)
		if err != nil {
			return nil, fmt.Errorf("mapping the Resource ID segment: %+v", err)
		}
		segments = append(segments, *outputSegment)
	}

	return &repositoryModels.ResourceId{
		Name:        name,
		CommonAlias: input.CommonIDAlias,
		Id:          input.ExampleValue,
		Segments:    segments,
	}, nil
}
