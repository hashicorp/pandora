// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package transforms

import (
	"fmt"
	"strings"

	repositoryModels "github.com/hashicorp/pandora/tools/data-api-repository/repository/internal/models"
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

func mapResourceIdSegmentFromRepository(input repositoryModels.ResourceIdSegment, availableConstants map[string]sdkModels.SDKConstant) (*sdkModels.ResourceIDSegment, error) {
	if input.Type == repositoryModels.ConstantResourceIdSegmentType {
		if input.ConstantName == nil {
			return nil, fmt.Errorf("constant segment type with missing constant reference: %+v", input)
		}
		constant, ok := availableConstants[*input.ConstantName]
		if !ok {
			return nil, fmt.Errorf("the segment referenced a constant %q which was not found", *input.ConstantName)
		}
		exampleValue, err := determineExampleValue(constant.Values)
		if err != nil {
			return nil, fmt.Errorf("determining the example value for constant %q: %+v", *input.ConstantName, err)
		}
		segment := sdkModels.NewConstantResourceIDSegment(input.Name, *input.ConstantName, *exampleValue)
		return &segment, nil
	}

	if input.Type == repositoryModels.ResourceGroupResourceIdSegmentType {
		segment := sdkModels.NewResourceGroupNameResourceIDSegment(input.Name)
		return &segment, nil
	}

	if input.Type == repositoryModels.ResourceProviderResourceIdSegmentType {
		if input.Value == nil {
			return nil, fmt.Errorf("resource provider segment type with missing fixed value: %+v", input)
		}

		segment := sdkModels.NewResourceProviderResourceIDSegment(input.Name, *input.Value)
		return &segment, nil
	}

	if input.Type == repositoryModels.ScopeResourceIdSegmentType {
		segment := sdkModels.NewScopeResourceIDSegment(input.Name)
		return &segment, nil
	}

	if input.Type == repositoryModels.StaticResourceIdSegmentType {
		if input.Value == nil {
			return nil, fmt.Errorf("static segment type with missing fixed value: %+v", input)
		}

		segment := sdkModels.NewStaticValueResourceIDSegment(input.Name, *input.Value)
		return &segment, nil
	}

	if input.Type == repositoryModels.SubscriptionIdResourceIdSegmentType {
		segment := sdkModels.NewSubscriptionIDResourceIDSegment(input.Name)
		return &segment, nil
	}

	if input.Type == repositoryModels.UserSpecifiedResourceIdSegmentType {
		exampleValue := input.ExampleValue
		if exampleValue == "" {
			exampleValue = fmt.Sprintf("%sValue", strings.TrimSuffix(input.Name, "Name"))
		}
		segment := sdkModels.NewUserSpecifiedResourceIDSegment(input.Name, exampleValue)
		return &segment, nil
	}

	return nil, fmt.Errorf("internal-error: unimplemented segment type %q", string(input.Type))
}

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
			Type:         repositoryModels.UserSpecifiedResourceIdSegmentType,
			Name:         input.Name,
			ExampleValue: input.ExampleValue,
		}, nil
	}

	return nil, fmt.Errorf("internal-error: unimplemented segment type %q", string(input.Type))
}
