// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package pipeline

import (
	"fmt"
	"path/filepath"

	"github.com/davecgh/go-spew/spew"
	"github.com/getkin/kin-openapi/openapi3"
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/importer-msgraph-metadata/components/parser"
	"github.com/hashicorp/pandora/tools/importer-msgraph-metadata/components/tags"
	"github.com/hashicorp/pandora/tools/importer-msgraph-metadata/components/versions"
	"github.com/hashicorp/pandora/tools/importer-msgraph-metadata/components/workarounds"
	"github.com/hashicorp/pandora/tools/importer-msgraph-metadata/internal/logging"
	"github.com/hashicorp/pandora/tools/sdk/config/services"
)

func runImporter(input RunInput, metadataGitSha string) error {
	config, err := services.LoadFromFile(input.ConfigFilePath)
	if err != nil {
		return fmt.Errorf("loading config: %+v", err)
	}

	logging.Debugf("Removing any existing API Definitions")
	if err = input.Repo.PurgeExistingData(sdkModels.MicrosoftGraphMetaDataSourceDataOrigin); err != nil {
		return fmt.Errorf("removing existing API Definitions: %+v", err)
	}

	for _, apiVersion := range versions.Supported {
		openApiFile := fmt.Sprintf(input.OpenApiFilePattern, versions.Upstream(apiVersion))
		if err := runImportForVersion(input, apiVersion, openApiFile, metadataGitSha, config); err != nil {
			return err
		}
	}
	logging.Infof("Finished!")

	return nil
}

func runImportForVersion(input RunInput, apiVersion, openApiFile, metadataGitSha string, config *services.Config) error {
	var err error

	p := &pipeline{
		apiVersion:      apiVersion,
		metadataGitSha:  metadataGitSha,
		outputDirectory: input.OutputDirectory,
		resources:       make(map[string]parser.Resources),
		repo:            input.Repo,
	}

	logging.Infof("Loading OpenAPI3 definitions for API version %q", apiVersion)
	p.spec, err = openapi3.NewLoader().LoadFromFile(filepath.Join(input.MetadataDirectory, openApiFile))
	if err != nil {
		return err
	}

	logging.Infof("Parsing models and constants...")
	p.models, p.constants, err = parser.Common(p.spec.Components.Schemas)
	if err != nil {
		return err
	}

	logging.Infof("Applying workarounds for invalid model definitions..")
	if err = workarounds.ApplyWorkarounds(p.apiVersion, p.models, p.constants); err != nil {
		return err
	}

	logging.Infof("Cleaning up models...")
	if err = p.cleanupModels(); err != nil {
		return err
	}

	logging.Infof("Parsing resource IDs...")
	p.resourceIds, err = parser.ParseResourceIDs(p.spec.Paths, nil)
	if err != nil {
		return err
	}

	serviceTags, err := tags.Parse(p.spec.Tags)
	if err != nil {
		return err
	}

	for _, service := range config.Services {
		for _, version := range service.Available {
			if version == apiVersion {
				// Check that service is known
				known := false
				for serviceTag := range serviceTags {
					if serviceTag == service.Directory {
						known = true
						break
					}
				}
				if !known {
					return fmt.Errorf("unknown service was configured for API version %s: %#v", version, service)
				}

				if len(input.Services) > 0 {
					skip := true

					for _, serviceName := range input.Services {
						if serviceName == service.Name {
							skip = false
							break
						}
					}

					if skip {
						continue
					}
				}

				logging.Infof("Importing service %q for API version %q", service.Name, version)

				if err = p.ForService(service.Directory).RunImport(); err != nil {
					return err
				}

				break
			}
		}
	}

	// Determine which resource IDs were actually used in resources
	usedResourceIds := make(map[string]parser.ResourceId)
	for _, resources := range p.resources {
		for _, resource := range resources {
			for _, operation := range resource.Operations {
				if operation.ResourceId != nil {
					usedResourceIds[operation.ResourceId.Name] = *operation.ResourceId
				}
			}
		}
	}
	p.resourceIds = make(parser.ResourceIds, 0, len(usedResourceIds))
	for _, resourceId := range usedResourceIds {
		p.resourceIds = append(p.resourceIds, &resourceId)
	}

	commonTypesForApiVersion, err := p.translateCommonTypesToDataApiSdkTypes()
	if err != nil {
		return err
	}

	for service := range p.resources {
		if err = p.ForService(service).PersistDefinitions(*commonTypesForApiVersion); err != nil {
			return err
		}
	}

	if err = p.PersistCommonTypesDefinitions(*commonTypesForApiVersion); err != nil {
		return err
	}

	return nil
}

func (p pipelineForService) RunImport() error {
	logging.Infof("Parsing resources for %q", p.service)
	resources, err := p.parseResources(p.resourceIds, p.models, p.constants)
	if err != nil {
		return err
	}
	if len(resources) == 0 {
		return nil
	}

	p.resources[p.service] = resources

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
			logging.Warnf(spew.Sprintf("Resource with no category was encountered for %q at %q: %#v", p.service, path, *resource))
		}
	}

	return nil
}

func (p pipelineForService) PersistDefinitions(commonTypesForVersion sdkModels.CommonTypes) error {
	sdkService, err := p.translateServiceToDataApiSdkTypes()
	if err != nil {
		return err
	}

	commonTypes := map[string]sdkModels.CommonTypes{
		p.apiVersion: commonTypesForVersion,
	}

	if err = p.persistApiDefinitions(*sdkService, commonTypes); err != nil {
		return err
	}

	return nil
}
