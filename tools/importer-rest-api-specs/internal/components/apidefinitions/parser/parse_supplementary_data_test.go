package parser_test

import (
	"testing"

	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/apidefinitions/parser"
	parserModels "github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/apidefinitions/parser/models"
)

func TestParseSupplementaryData(t *testing.T) {
	filePath := "/Users/tharvey/code/src/github.com/hashicorp/pandora/submodules/rest-api-specs/specification/datafactory/resource-manager/Microsoft.DataFactory/stable/2018-06-01/entityTypes/LinkedService.json"
	parser, err := parser.NewAPIDefinitionsParser(filePath, parserModels.SupplementaryData{
		Constants: make(map[string]sdkModels.SDKConstant),
		Models:    make(map[string]sdkModels.SDKModel),
	})
	if err != nil {
		t.Fatalf(err.Error())
	}
	data, err := parser.SupplementaryData()
	if err != nil {
		t.Fatalf(err.Error())
	}

	t.Logf("Got %d Constants", len(data.Constants))
	t.Logf("Got %d Models", len(data.Models))
}
