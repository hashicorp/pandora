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
	spec, err := openapi3.NewLoader().LoadFromFile(filepath.Join(input.MetadataDirectory, input.OpenApiFile))
	if err != nil {
		return err
	}

	files := newTree()

	models := parseModels(spec.Components.Schemas)

	logger.Info("Templating models")
	if err = templateModels(files, models); err != nil {
		return err
	}

	logger.Info("Templating constants")
	if err = templateConstants(files, models); err != nil {
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

		if err = runImportForService(input, files, service, serviceTags, spec, swaggerGitSha); err != nil {
			return err
		}
	}

	if err = files.write(input.OutputDirectory, logger); err != nil {
		return err
	}

	logger.Info("Finished!")

	return nil
}

func runImportForService(input RunInput, files *Tree, service string, serviceTags []string, spec *openapi3.T, swaggerGitSha string) error {
	logger := input.Logger
	task := pipelineTask{
		spec:          spec,
		swaggerGitSha: swaggerGitSha,
	}

	logger.Info(fmt.Sprintf("Parsing resource IDs for: %s", service))
	resourceIds := task.parseResourceIDsForService(service, serviceTags, spec.Paths)

	logger.Info(fmt.Sprintf("Parsing resources for: %s", service))
	resources := task.parseResourcesForService(service, serviceTags, spec.Paths, resourceIds)

	logger.Info(fmt.Sprintf("Templating methods for: %s", service))
	if err := task.templateOperationsForService(files, service, resources, logger); err != nil {
		return err
	}

	logger.Info(fmt.Sprintf("Templating resource IDs for: %s", service))
	if err := task.templateResourceIdsForService(files, service, resources, logger); err != nil {
		return err
	}

	return nil
}
