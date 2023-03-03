package pipeline

import (
	"fmt"
	"log"
	"path/filepath"
	"strings"

	"github.com/getkin/kin-openapi/openapi3"
	"github.com/hashicorp/go-hclog"
)

type RunInput struct {
	Logger            hclog.Logger
	MetadataDirectory string
	OpenApiFile       string
	OutputDirectory   string
	Tags              []string
}

func Run(input RunInput) error {
	logger := input.Logger

	_, err := determineGitSha(input.MetadataDirectory, logger)
	if err != nil {
		return fmt.Errorf("determining Git SHA at %q: %+v", input.MetadataDirectory, err)
	}

	spec, err := load(filepath.Join(input.MetadataDirectory, input.OpenApiFile))
	if err != nil {
		log.Fatal(err)
	}

	tags, err := parseTags(spec)
	if err != nil {
		return err
	}

	files := newTree()
	models := parseModels(spec.Components.Schemas)

	logger.Info("Templating models")
	if err := templateModels(files, models); err != nil {
		return err
	}

	for tag, subtags := range tags {
		if len(input.Tags) > 0 {
			skip := true
			for _, t := range input.Tags {
				if tag == t {
					skip = false
					break
				}
			}
			if skip {
				continue
			}
		}

		logger.Info(fmt.Sprintf("Parsing endpoints for: %s", tag))
		endpoints := parseEndpointsForTag(tag, subtags, spec.Paths)

		logger.Info(fmt.Sprintf("Templating client for: %s", tag))
		if err := templateClient(files, tag); err != nil {
			return err
		}

		logger.Info(fmt.Sprintf("Templating options for: %s", tag))
		if err := templateOptions(files, tag); err != nil {
			return err
		}

		logger.Info(fmt.Sprintf("Templating methods for: %s", tag))
		if err := templateMethods(files, tag, endpoints, logger); err != nil {
			return err
		}
	}

	for tag := range tags {
		if dir, err := files.descend(tag); err == nil {
			methodFound := false
			for filename := range dir.files {
				if strings.HasPrefix(filename, "method_") {
					methodFound = true
					break
				}
			}
			if !methodFound {
				delete(files.tree, tag)
			}
		}
	}

	if err := files.write(input.OutputDirectory, logger); err != nil {
		return err
	}

	logger.Info("Finished!")

	return nil
}

func load(filename string) (*openapi3.T, error) {
	spec, err := openapi3.NewLoader().LoadFromFile(filename)
	if err != nil {
		return nil, err
	}
	return spec, nil
}
