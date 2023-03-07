package pipeline

import (
	"fmt"
	"path/filepath"
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

	tags, err := parseServices(spec)
	if err != nil {
		return err
	}

	for tag, subTags := range tags {
		skip := true
		if len(input.Tags) > 0 {
			for _, t := range input.Tags {
				if strings.EqualFold(tag, t) {
					skip = false
					break
				}
			}
		}
		if skip {
			continue
		}

		if err = runImportForTag(input, files, tag, subTags, spec, swaggerGitSha); err != nil {
			return err
		}
	}

	if err = files.write(input.OutputDirectory, logger); err != nil {
		return err
	}

	logger.Info("Finished!")

	return nil
}

func runImportForTag(input RunInput, files *Tree, tag string, subTags []string, spec *openapi3.T, swaggerGitSha string) error {
	logger := input.Logger
	task := pipelineTask{}

	logger.Info(fmt.Sprintf("Parsing endpoints for: %s", tag))
	endpoints := task.parseResourcesForTag(tag, subTags, spec.Paths)

	//logger.Info(fmt.Sprintf("Templating client for: %s", tag))
	//if err := task.templateClient(files, tag); err != nil {
	//	return err
	//}

	logger.Info(fmt.Sprintf("Templating methods for: %s", tag))
	if err := task.templateMethods(files, tag, endpoints, logger); err != nil {
		return err
	}

	return nil
}
