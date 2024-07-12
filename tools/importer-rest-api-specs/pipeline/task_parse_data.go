// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package pipeline

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/discovery"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/parser"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/logging"
	importerModels "github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

func (pipelineTask) parseDataForApiVersion(input discovery.ServiceInput) (*importerModels.AzureApiDefinition, error) {
	logging.Tracef("Parsing Swagger Files..")
	data, err := parseSwaggerFiles(input)
	if err != nil {
		err = fmt.Errorf("parsing Swagger files: %+v", err)
		logging.Infof(fmt.Sprintf("❌ Service %q - Api Version %q", input.ServiceName, input.ApiVersion))
		logging.Errorf(fmt.Sprintf("     💥 Error: %+v", err))
		return nil, err
	}
	if data == nil {
		logging.Infof("😵 Service %q / Api Version %q contains no resources, skipping.", input.ServiceName, input.ApiVersion)
		return nil, nil
	}

	return data, nil
}

func parseSwaggerFiles(input discovery.ServiceInput) (*importerModels.AzureApiDefinition, error) {
	parseResult, err := parser.LoadAndParseFiles(input.SwaggerDirectory, input.SwaggerFiles, input.ServiceName, input.ApiVersion, input.ResourceProviderToFilterTo)
	if err != nil {
		return nil, fmt.Errorf("parsing files in %q: %+v", input.SwaggerDirectory, err)
	}

	return parseResult, nil
}
