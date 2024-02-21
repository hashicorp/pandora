// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package pipeline

import (
	"fmt"

	"github.com/hashicorp/go-hclog"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/dataapigeneratorjson"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

func (pipelineTask) generateApiDefinitionsV2(serviceName string, apiVersions []models.AzureApiDefinition, outputDirectory, swaggerGitSha string, resourceProvider, terraformPackageName *string, logger hclog.Logger) error {
	logger.Info(fmt.Sprintf("Persisting API Definitions for Service %s..", serviceName))
	if err := dataapigeneratorjson.Run(apiVersions, outputDirectory, swaggerGitSha, resourceProvider, terraformPackageName, logger); err != nil {
		return fmt.Errorf("persisting Data API Definitions for Service %q: %+v", serviceName, err)
	}

	return nil
}
