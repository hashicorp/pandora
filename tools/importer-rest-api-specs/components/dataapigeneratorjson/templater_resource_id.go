// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package dataapigeneratorjson

import (
	"encoding/json"
	"fmt"

	importerModels "github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
	"github.com/hashicorp/pandora/tools/sdk/dataapimodels"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func codeForResourceId(name string, input importerModels.ParsedResourceId) ([]byte, error) {
	segments := make([]dataapimodels.ResourceIdSegment, 0)
	for _, inputSegment := range input.Segments {
		outputSegment, err := mapResourceIdSegment(inputSegment)
		if err != nil {
			return nil, fmt.Errorf("mapping the Resource ID segment: %+v", err)
		}
		segments = append(segments, *outputSegment)
	}

	resourceId := dataapimodels.ResourceId{
		Name:        name,
		CommonAlias: input.CommonAlias,
		Id:          input.ID(),
		Segments:    segments,
	}

	data, err := json.MarshalIndent(resourceId, "", " ")
	if err != nil {
		return nil, err
	}

	return data, nil
}

func mapResourceIdSegment(input resourcemanager.ResourceIdSegment) (*dataapimodels.ResourceIdSegment, error) {
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
