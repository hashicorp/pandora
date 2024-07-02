// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package pipeline

import (
	"fmt"

	"github.com/hashicorp/go-hclog"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/discovery"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/parser"
	importerModels "github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

func (pipelineTask) parseDataForApiVersion(input discovery.ServiceInput, logger hclog.Logger) (*importerModels.AzureApiDefinition, error) {
	logger.Trace("Parsing Swagger Files..")
	data, err := parseSwaggerFiles(input, logger.Named("Swagger"))
	if err != nil {
		err = fmt.Errorf("parsing Swagger files: %+v", err)
		logger.Info(fmt.Sprintf("❌ Service %q - Api Version %q", input.ServiceName, input.ApiVersion))
		logger.Error(fmt.Sprintf("     💥 Error: %+v", err))
		return nil, err
	}
	if data == nil {
		logger.Info(fmt.Sprintf("😵 Service %q / Api Version %q contains no resources, skipping.", input.ServiceName, input.ApiVersion))
		return nil, nil
	}

	return data, nil
}

func parseSwaggerFiles(input discovery.ServiceInput, logger hclog.Logger) (*importerModels.AzureApiDefinition, error) {
	parseResult, err := parser.LoadAndParseFiles(input.SwaggerDirectory, input.SwaggerFiles, input.ServiceName, input.ApiVersion, input.ResourceProviderToFilterTo, logger)
	if err != nil {
		return nil, fmt.Errorf("parsing files in %q: %+v", input.SwaggerDirectory, err)
	}

	return parseResult, nil
}
