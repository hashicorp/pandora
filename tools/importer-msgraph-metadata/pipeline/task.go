package pipeline

import (
	"fmt"

	"github.com/getkin/kin-openapi/openapi3"
	"github.com/hashicorp/go-hclog"
)

type pipelineTask struct {
	apiVersion      string
	service         string
	files           *Tree
	logger          hclog.Logger
	metadataGitSha  string
	outputDirectory string
	spec            *openapi3.T
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

	p.logger.Info(fmt.Sprintf("Templating resource IDs for %q", p.service))
	if err := p.templateResourceIdsForService(resources); err != nil {
		return err
	}

	p.logger.Info(fmt.Sprintf("Templating models for %q", p.service))
	if err := p.templateModelsForService(resources, models); err != nil {
		return err
	}

	p.logger.Info(fmt.Sprintf("Templating constants for %q", p.service))
	if err := p.templateConstantsForService(resources, models); err != nil {
		return err
	}

	p.logger.Info(fmt.Sprintf("Templating operations for %q", p.service))
	if err := p.templateOperationsForService(resources); err != nil {
		return err
	}

	p.logger.Info(fmt.Sprintf("Templating definitions for %q", p.service))
	if err := p.templateDefinitionsForService(resources, models); err != nil {
		return err
	}

	p.logger.Info(fmt.Sprintf("Templating service definition for %q", p.service))
	if err := p.templateServiceDefinitionForService(resources); err != nil {
		return err
	}

	p.logger.Info(fmt.Sprintf("Templating API version definition for %q", p.service))
	if err := p.templateApiVersionDefinitionForService(resources); err != nil {
		return err
	}

	if err = p.files.write(p.outputDirectory, p.logger); err != nil {
		return err
	}

	return nil
}
