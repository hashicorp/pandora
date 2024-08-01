// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package pipeline

import (
	"fmt"
	"path/filepath"

	"github.com/getkin/kin-openapi/openapi3"
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/importer-msgraph-metadata/components/parser"
	"github.com/hashicorp/pandora/tools/importer-msgraph-metadata/components/tags"
	"github.com/hashicorp/pandora/tools/importer-msgraph-metadata/components/versions"
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
	logging.Infof(fmt.Sprintf("Loading OpenAPI3 definitions for API version %q", apiVersion))
	spec, err := openapi3.NewLoader().LoadFromFile(filepath.Join(input.MetadataDirectory, openApiFile))
	if err != nil {
		return err
	}

	logging.Infof(fmt.Sprintf("Parsing models and constants..."))
	models, constants, err := parser.Common(spec.Components.Schemas)
	if err != nil {
		return err
	}

	logging.Infof(fmt.Sprintf("Parsing resource IDs..."))
	resourceIds, err := parser.ParseResourceIDs(spec.Paths, nil)
	if err != nil {
		return err
	}

	commonTypesForApiVersion, err := translateModelsToDataApiSdkTypes(models, constants, resourceIds)
	if err != nil {
		return err
	}

	serviceTags, err := tags.Parse(spec.Tags)
	if err != nil {
		return err
	}

	p := &pipeline{
		apiVersion:            apiVersion,
		commonTypesForVersion: *commonTypesForApiVersion,
		metadataGitSha:        metadataGitSha,
		outputDirectory:       input.OutputDirectory,
		resourceIds:           resourceIds,
		repo:                  input.Repo,
		spec:                  spec,
	}

	if err = p.PersistCommonTypesDefinitions(); err != nil {
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

				logging.Infof(fmt.Sprintf("Importing service %q for API version %q", service.Name, version))

				if err = p.ForService(service.Directory).RunImport(serviceTags[service.Directory], models, constants); err != nil {
					return err
				}

				break
			}
		}
	}

	return nil
}
