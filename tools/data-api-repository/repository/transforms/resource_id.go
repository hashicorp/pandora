// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package transforms

import (
	"fmt"

	repositoryModels "github.com/hashicorp/pandora/tools/data-api-repository/models"
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

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
