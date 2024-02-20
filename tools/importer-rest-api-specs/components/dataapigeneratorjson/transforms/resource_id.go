package transforms

import (
	"fmt"

	importerModels "github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
	"github.com/hashicorp/pandora/tools/sdk/dataapimodels"
)

func MapResourceIDToRepository(name string, input importerModels.ParsedResourceId) (*dataapimodels.ResourceId, error) {
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
		Id:          input.ID(),
		Segments:    segments,
	}, nil
}
