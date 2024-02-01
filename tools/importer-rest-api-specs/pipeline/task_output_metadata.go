package pipeline

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/dataapigeneratorjson"
)

func (pipelineTask) outputMetaData(input RunInput, swaggerGitSha string) error {
	// This is named metadata since it could make sense to output additional items in the future
	// such as the licence for this imported data etc
	if err := dataapigeneratorjson.OutputMetaData(input.OutputDirectory, swaggerGitSha); err != nil {
		return fmt.Errorf("outputting the Revision ID: %+v", err)
	}

	return nil
}
