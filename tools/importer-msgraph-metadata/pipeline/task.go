// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package pipeline

import (
	"fmt"

	"github.com/davecgh/go-spew/spew"
	"github.com/getkin/kin-openapi/openapi3"
	"github.com/hashicorp/go-hclog"
)

type pipelineTask struct {
	apiVersion               string
	commonTypesDirectoryName string
	files                    *Tree
	logger                   hclog.Logger
	metadataGitSha           string
	outputDirectory          string
	service                  string
	spec                     *openapi3.T
}

func (p pipelineTask) runImportForService(serviceTags []string, models Models) error {
	p.logger.Info(fmt.Sprintf("Parsing resource IDs for %q", p.service))
	resourceIds, err := p.parseResourceIDsForService()
	if err != nil {
		return err
	}

	p.logger.Info(fmt.Sprintf("Parsing resources for %q", p.service))
	resources, err := p.parseResourcesForService(resourceIds, models)
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

	p.logger.Info(fmt.Sprintf("Deleting any exsting directory for %q", p.service))
	if err = p.removeDirectoryForService(resources); err != nil {
		return err
	}

	p.logger.Info(fmt.Sprintf("Templating resource IDs for %q", p.service))
	if err = p.templateResourceIdsForService(resources); err != nil {
		return err
	}

	p.logger.Info(fmt.Sprintf("Templating models for %q", p.service))
	if err = p.templateModelsForService(p.commonTypesDirectoryName, resources, models); err != nil {
		return err
	}

	p.logger.Info(fmt.Sprintf("Templating constants for %q", p.service))
	if err = p.templateConstantsForService(resources, models); err != nil {
		return err
	}

	p.logger.Info(fmt.Sprintf("Templating operations for %q", p.service))
	if err = p.templateOperationsForService(p.commonTypesDirectoryName, resources); err != nil {
		return err
	}

	p.logger.Info(fmt.Sprintf("Templating definitions for %q", p.service))
	if err = p.templateDefinitionsForService(p.commonTypesDirectoryName, resources, models); err != nil {
		return err
	}

	p.logger.Info(fmt.Sprintf("Templating service definition for %q", p.service))
	if err = p.templateServiceDefinitionForService(resources); err != nil {
		return err
	}

	p.logger.Info(fmt.Sprintf("Templating API version definition for %q", p.service))
	if err = p.templateApiVersionDefinitionForService(resources); err != nil {
		return err
	}

	if err = p.files.write(p.outputDirectory, p.logger); err != nil {
		return err
	}

	return nil
}
