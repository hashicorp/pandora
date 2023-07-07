package pipeline

import (
	"fmt"
	"path/filepath"
	"sort"
	"strings"

	"github.com/getkin/kin-openapi/openapi3"
)

func runImporter(input RunInput, metadataGitSha string) error {
	logger := input.Logger
	for _, apiVersion := range input.ApiVersions {
		openApiFile := fmt.Sprintf(input.OpenApiFilePattern, apiVersion)
		if err := runImportForVersion(input, apiVersion, openApiFile, metadataGitSha); err != nil {
			return err
		}
	}
	logger.Info("Finished!")

	return nil
}

func runImportForVersion(input RunInput, apiVersion, openApiFile, metadataGitSha string) error {
	input.Logger.Info(fmt.Sprintf("Loading OpenAPI3 definitions for API version %q", apiVersion))
	spec, err := openapi3.NewLoader().LoadFromFile(filepath.Join(input.MetadataDirectory, openApiFile))
	if err != nil {
		return err
	}

	models, err := parseCommonModels(spec.Components.Schemas)
	if err != nil {
		return err
	}

	services, err := parseTags(spec.Tags)
	if err != nil {
		return err
	}

	serviceNames := make([]string, 0, len(services))
	for name := range services {
		serviceNames = append(serviceNames, name)
	}
	sort.Strings(serviceNames)

	for _, service := range serviceNames {
		serviceTags := services[service]
		if len(input.Tags) > 0 {
			skip := true
			for _, t := range input.Tags {
				if strings.EqualFold(service, t) {
					skip = false
					break
				}
			}
			if skip {
				continue
			}
		}

		task := &pipelineTask{
			apiVersion:               apiVersion,
			commonTypesDirectoryName: input.CommonTypesDirectoryName,
			files:                    newTree(),
			logger:                   input.Logger,
			metadataGitSha:           metadataGitSha,
			outputDirectory:          input.OutputDirectory,
			service:                  service,
			spec:                     spec,
		}

		if err = task.runImportForService(serviceTags, models); err != nil {
			return err
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
