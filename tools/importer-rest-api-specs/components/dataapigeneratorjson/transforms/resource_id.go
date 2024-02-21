// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package transforms

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/sdk/dataapimodels"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func MapResourceIDToRepository(name string, input resourcemanager.ResourceIdDefinition) (*dataapimodels.ResourceId, error) {
	segments := make([]dataapimodels.ResourceIdSegment, 0)
	for _, inputSegment := range input.Segments {
		outputSegment, err := mapResourceIdSegmentToRepository(inputSegment)
		if err != nil {
			return nil, fmt.Errorf("mapping the Resource ID segment: %+v", err)
		}
		segments = append(segments, *outputSegment)
	}

	return &dataapimodels.ResourceId{
		Name:        name,
		CommonAlias: input.CommonAlias,
		Id:          input.Id,
		Segments:    segments,
	}, nil
}
