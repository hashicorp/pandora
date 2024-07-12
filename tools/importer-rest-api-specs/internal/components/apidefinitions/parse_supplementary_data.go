package apidefinitions

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/apidefinitions/parser"
	parserModels "github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/apidefinitions/parser/models"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/logging"
)

// parseSupplementaryDataFromFile loads any available Supplementary Data from the file in question
func parseSupplementaryDataFromFile(filePath string, knownData parserModels.SupplementaryData) (*parserModels.SupplementaryData, error) {
	logging.Tracef("Building an Definitions Parser for %q..", filePath)
	parser, err := parser.NewAPIDefinitionsParser(filePath, knownData)
	if err != nil {
		return nil, fmt.Errorf("building the APIDefinitions Parser for %q: %+v", filePath, err)
	}
	logging.Tracef("Parsing the Supplementary Data from %q..", filePath)
	data, err := parser.SupplementaryData()
	if err != nil {
		return nil, fmt.Errorf("parsing the Supplementary Data from %q: %+v", filePath, err)
	}
	logging.Tracef("Loaded the Supplementary Data from %q.", filePath)

	return data, nil
}
