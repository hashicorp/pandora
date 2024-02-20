// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package dataapigeneratorjson

import (
	"encoding/json"
	"fmt"
	"path"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/dataapigeneratorjson/transforms"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

func (s Generator) generateServiceDefinitions(apiVersions []models.AzureApiDefinition) error {
	s.logger.Debug(fmt.Sprintf("Processing Service %q..", s.serviceName))

	s.logger.Trace(fmt.Sprintf("Generating Service Definition Code for Service %q..", s.serviceName))
	serviceDefinition, err := transforms.MapServiceDefinitionToRepository(s.serviceName, s.resourceProvider, s.terraformPackageName, apiVersions)
	if err != nil {
		return fmt.Errorf("mapping Service Definition for %q: %+v", s.serviceName, err)
	}
	data, err := json.MarshalIndent(serviceDefinition, "", " ")
	if err != nil {
		return fmt.Errorf("marshalling Service Definition for %q: %+v", s.serviceName, err)
	}

	serviceDefinitionFilePath := path.Join(s.workingDirectoryForService, "ServiceDefinition.json")
	s.logger.Trace(fmt.Sprintf("Outputting the Service Definition to %q for Service %q..", serviceDefinitionFilePath, s.serviceName))
	if err := writeJsonToFile(serviceDefinitionFilePath, data); err != nil {
		return fmt.Errorf("generating Service Definition into %q: %+v", serviceDefinitionFilePath, err)
	}

	return nil
}
