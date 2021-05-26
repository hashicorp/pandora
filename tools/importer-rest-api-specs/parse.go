package main

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/parser"
)

func parseSwaggerFiles(input RunInput, debug bool) (*[]parsedData, error) {
	parsed := make(map[string]parsedData, 0)
	for _, file := range input.SwaggerFiles {
		swaggerFile, err := parser.Load(input.SwaggerDirectory, file, debug)
		if err != nil {
			return nil, fmt.Errorf("parsing file %q: %+v", file, err)
		}

		definition, err := swaggerFile.Parse(input.ServiceName, input.ApiVersion)
		if err != nil {
			return nil, fmt.Errorf("parsing definition: %+v", err)
		}

		data := parsedData{
			ServiceName: input.ServiceName,
			ApiVersion:  input.ApiVersion,
			Resources:   definition.Resources,
		}

		if existing, ok := parsed[data.Key()]; ok {
			for k, v := range existing.Resources {
				data.Resources[k] = v
			}
		}

		parsed[data.Key()] = data
	}

	out := make([]parsedData, 0)
	for _, v := range parsed {
		out = append(out, v)
	}
	return &out, nil
}

type parsedData struct {
	ServiceName string
	ApiVersion  string
	Resources   map[string]models.AzureApiResource
}

func (d parsedData) Key() string {
	return fmt.Sprintf("%s-%s", d.ServiceName, d.ApiVersion)
}
