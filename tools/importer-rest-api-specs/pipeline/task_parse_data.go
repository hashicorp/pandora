// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package pipeline

import (
	"fmt"

	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/discovery"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/parser"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/logging"
)

func (pipelineTask) parseDataForApiVersion(input discovery.ServiceInput) (*map[string]sdkModels.APIResource, error) {
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

func parseSwaggerFiles(input discovery.ServiceInput) (*map[string]sdkModels.APIResource, error) {
	parseResult, err := parser.LoadAndParseFiles(input.SwaggerDirectory, input.SwaggerFiles, input.ServiceName, input.ApiVersion, input.ResourceProviderToFilterTo)
	if err != nil {
		return nil, fmt.Errorf("parsing files in %q: %+v", input.SwaggerDirectory, err)
	}

	if parseResult == nil {
		return nil, nil
	}

	return &parseResult.Resources, nil
}
