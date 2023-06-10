package pipeline

import (
	"fmt"
	"path/filepath"
	"sort"
	"strings"

	"github.com/getkin/kin-openapi/openapi3"
	"github.com/hashicorp/pandora/tools/sdk/config/definitions"
)

func runImporter(input RunInput, resources *definitions.Config, swaggerGitSha string) error {
	logger := input.Logger
	for _, apiVersion := range input.ApiVersions {
		openApiFile := fmt.Sprintf(input.OpenApiFilePattern, apiVersion)
		if err := runImportForVersion(input, resources, apiVersion, openApiFile, swaggerGitSha); err != nil {
			return err
		}
	}
	logger.Info("Finished!")

	return nil
}

func runImportForVersion(input RunInput, resources *definitions.Config, apiVersion, openApiFile, swaggerGitSha string) error {
	logger := input.Logger

	logger.Info(fmt.Sprintf("Loading OpenAPI3 definitions for API version %q", apiVersion))
	spec, err := openapi3.NewLoader().LoadFromFile(filepath.Join(input.MetadataDirectory, openApiFile))
	if err != nil {
		return err
	}

	files := newTree()

	models := parseModels(spec.Components.Schemas)

	logger.Info(fmt.Sprintf("Templating models for API version %q", apiVersion))
	if err = templateModels(apiVersion, files, models); err != nil {
		return err
	}

	logger.Info(fmt.Sprintf("Templating constants for API version %q", apiVersion))
	if err = templateConstants(apiVersion, files, models); err != nil {
		return err
	}

	services, err := parseTags(spec)
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

		if err = runImportForService(input, files, apiVersion, service, serviceTags, models, spec, swaggerGitSha); err != nil {
			return err
		}
	}

	if err = files.write(input.OutputDirectory, logger); err != nil {
		return err
	}

	return nil
}

func runImportForService(input RunInput, files *Tree, apiVersion, service string, serviceTags []string, models Models, spec *openapi3.T, swaggerGitSha string) error {
	logger := input.Logger

	task := pipelineTask{
		spec:          spec,
		swaggerGitSha: swaggerGitSha,
	}

	logger.Info(fmt.Sprintf("Parsing resource IDs for %q", service))
	resourceIds, err := task.parseResourceIDsForService(logger, apiVersion, service, serviceTags, spec.Paths)
	if err != nil {
		return err
	}

	logger.Info(fmt.Sprintf("Parsing resources for %q", service))
	resources, err := task.parseResourcesForService(logger, apiVersion, service, serviceTags, spec.Paths, resourceIds, models)
	if err != nil {
		return err
	}

	logger.Info(fmt.Sprintf("Templating resource IDs for %q", service))
	if err := task.templateResourceIdsForService(files, service, resources, logger); err != nil {
		return err
	}

	logger.Info(fmt.Sprintf("Templating methods for %q", service))
	if err := task.templateOperationsForService(files, service, resources, logger); err != nil {
		return err
	}

	logger.Info(fmt.Sprintf("Templating API version definition for %q", service))
	if err := task.templateApiVersionDefinitionForService(files, service, apiVersion, logger); err != nil {
		return err
	}

	return nil
}
