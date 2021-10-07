package main

import (
	"fmt"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/parser"
)

func parseSwaggerFiles(input RunInput, debug bool) (*[]parser.ParsedData, error) {
	parseResult, err := parser.LoadAndParseFiles(input.SwaggerDirectory, input.SwaggerFiles, input.ServiceName, input.ApiVersion, debug)
	if err != nil {
		return nil, fmt.Errorf("parsing files in %q: %+v", input.SwaggerDirectory, err)
	}

	return parseResult, nil
}
