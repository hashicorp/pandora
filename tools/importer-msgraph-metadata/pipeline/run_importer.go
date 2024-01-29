// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package pipeline

import (
	"fmt"
	"github.com/getkin/kin-openapi/openapi3"
	"github.com/hashicorp/pandora/tools/sdk/config/services"
	"path/filepath"
)

func runImporter(input RunInput, metadataGitSha string) error {
	logger := input.Logger

	config, err := services.LoadFromFile(input.ConfigFilePath)
	if err != nil {
		return fmt.Errorf("loading config: %+v", err)
	}

	for _, apiVersion := range input.SupportedVersions {
		openApiFile := fmt.Sprintf(input.OpenApiFilePattern, apiVersion)
		if err := runImportForVersion(input, apiVersion, openApiFile, metadataGitSha, config); err != nil {
			return err
		}
	}
	logger.Info("Finished!")

	return nil
}

func runImportForVersion(input RunInput, apiVersion, openApiFile, metadataGitSha string, config *services.Config) error {
	input.Logger.Info(fmt.Sprintf("Loading OpenAPI3 definitions for API version %q", apiVersion))
	spec, err := openapi3.NewLoader().LoadFromFile(filepath.Join(input.MetadataDirectory, openApiFile))
	if err != nil {
		return err
	}

	models, err := parseCommonModels(spec.Components.Schemas)
	if err != nil {
		return err
	}

	serviceTags, err := parseTags(spec.Tags)
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

				input.Logger.Info(fmt.Sprintf("Importing service %q for API version %q", service.Name, version))

				task := &pipelineTask{
					apiVersion:               apiVersion,
					commonTypesDirectoryName: input.CommonTypesDirectoryName,
					files:                    newTree(),
					logger:                   input.Logger,
					metadataGitSha:           metadataGitSha,
					outputDirectory:          input.OutputDirectory,
					service:                  service.Directory,
					spec:                     spec,
				}

				if err = task.runImportForService(serviceTags[service.Directory], models); err != nil {
					return err
				}
			}
		}
	}

	files := newTree()

	input.Logger.Info(fmt.Sprintf("Templating models for API version %q", apiVersion))
	if err = templateCommonModels(files, input.CommonTypesDirectoryName, apiVersion, models); err != nil {
		return err
	}

	input.Logger.Info(fmt.Sprintf("Templating constants for API version %q", apiVersion))
	if err = templateCommonConstants(files, input.CommonTypesDirectoryName, apiVersion, models); err != nil {
		return err
	}

	if err = files.write(input.OutputDirectory, input.Logger); err != nil {
		return err
	}

	return nil
}
