package differ

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/parser"
)

func (d Differ) ApplyFromExistingAPIDefinitions(existing []parser.ParsedData, parsed parser.ParsedData) (*parser.ParsedData, error) {
	// we should work through and ensure that all Existing items are present within Parsed
	// Each of the Stages to apply can be found in ApplyStages()

	// TODO: apply these
	return nil, fmt.Errorf("TODO: implement ApplyFromExistingAPIDefinitions")
}
