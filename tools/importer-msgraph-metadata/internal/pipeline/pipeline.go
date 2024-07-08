// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package pipeline

import (
	"fmt"

	"github.com/davecgh/go-spew/spew"
	"github.com/getkin/kin-openapi/openapi3"
	"github.com/hashicorp/go-hclog"
	"github.com/hashicorp/pandora/tools/data-api-repository/repository"
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/importer-msgraph-metadata/components/parser"
)

type pipeline struct {
	apiVersion            string
	commonTypesForVersion sdkModels.CommonTypes
	repo                  repository.Repository
	logger                hclog.Logger
	metadataGitSha        string
	outputDirectory       string
	spec                  *openapi3.T
}

type pipelineForService struct {
	pipeline
	service string
}

func (p pipeline) ForService(serviceName string) pipelineForService {
	return pipelineForService{
		pipeline: p,
		service:  serviceName,
	}
}

func (p pipelineForService) RunImport(serviceTags []string, models parser.Models, constants parser.Constants) error {
	p.logger.Info(fmt.Sprintf("Parsing resource IDs for %q", p.service))
	resourceIds, err := p.parseResourceIDs()
	if err != nil {
		return err
	}

	p.logger.Info(fmt.Sprintf("Parsing resources for %q", p.service))
	resources, err := p.parseResources(resourceIds, models, constants)
	if err != nil {
		return err
	}
	if len(resources) == 0 {
		return nil
	}

	// Consistency checks for discovered resources
	for resourceName, resource := range resources {
		if resource == nil {
			return fmt.Errorf("nil resource named %q was encountered for %q", resourceName, p.service)
		}
		if resource.Category == "" {
			path := "(no path)"
			if len(resource.Paths) > 0 {
				path = resource.Paths[0].ID()
			}
			p.logger.Warn(spew.Sprintf("Resource with no category was encountered for %q at %q: %#v", p.service, path, *resource))
		}
	}

	sdkServices, err := p.translateServiceToDataApiSdkTypes(models, constants, resources)
	if err != nil {
		return err
	}

	commonTypes := map[string]sdkModels.CommonTypes{
		p.apiVersion: p.commonTypesForVersion,
	}

	if err = p.persistApiDefinitions(*sdkServices, commonTypes); err != nil {
		return err
	}

	return nil
}
