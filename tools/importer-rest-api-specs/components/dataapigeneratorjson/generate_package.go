// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package dataapigeneratorjson

import (
	"fmt"
	"path"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

func (s Generator) generateResources(resource models.AzureApiResource, workingDirectory string) error {
	if err := RecreateDirectory(workingDirectory, s.logger); err != nil {
		return fmt.Errorf("recreating directory %q: %+v", workingDirectory, err)
	}

	s.logger.Debug("Generating Constants..")
	for constantName, vals := range resource.Constants {
		s.logger.Trace(fmt.Sprintf("Generating Constant %q..", constantName))
		code, err := codeForConstant(constantName, vals)
		if err != nil {
			return fmt.Errorf("marshaling Constants: %+v", err)
		}
		fileName := path.Join(workingDirectory, fmt.Sprintf("Constant-%s.json", constantName))
		if err := writeJsonToFile(fileName, code); err != nil {
			return fmt.Errorf("generating code for %q: %+v", constantName, err)
		}
	}

	s.logger.Debug("Generating Models..")
	for modelName, vals := range resource.Models {
		s.logger.Trace(fmt.Sprintf("Generating Model %q..", modelName))
		var parent *models.ModelDetails
		if vals.ParentTypeName != nil {
			s.logger.Trace("Finding parent model %q..", *vals.ParentTypeName)
			p, ok := resource.Models[*vals.ParentTypeName]
			if ok {
				parent = &p
			}
		}

		code, err := codeForModel(modelName, vals, parent, resource.Constants, resource.Models)
		if err != nil {
			return fmt.Errorf("generating code for model %q: %+v", modelName, err)
		}
		fileName := path.Join(workingDirectory, fmt.Sprintf("Model-%s.json", modelName))
		if code != nil {
			if err := writeJsonToFile(fileName, code); err != nil {
				return fmt.Errorf("writing code for model %q: %+v", modelName, err)
			}
		}
	}

	s.logger.Debug("Generating Operations..")
	for operationName, operation := range resource.Operations {
		s.logger.Trace(fmt.Sprintf("Generating Operation %q..", operationName))
		code, err := codeForOperation(operationName, operation, resource.Constants, resource.Models)
		if err != nil {
			return fmt.Errorf("marshaling Operation %q: %+v", operationName, err)
		}
		fileName := path.Join(workingDirectory, fmt.Sprintf("Operation-%s.json", operationName))
		if err := writeJsonToFile(fileName, code); err != nil {
			return fmt.Errorf("writing code for operation %q: %+v", operationName, err)
		}
	}

	s.logger.Debug("Generating Resource IDs..")
	for name, id := range resource.ResourceIds {
		s.logger.Trace(fmt.Sprintf("Generating Resource ID %q..", name))
		code, err := codeForResourceId(name, id)
		if err != nil {
			return fmt.Errorf("generating Resource ID %q: %+v", name, err)
		}
		fileName := path.Join(workingDirectory, fmt.Sprintf("ResourceId-%s.json", name))
		if err := writeJsonToFile(fileName, code); err != nil {
			return fmt.Errorf("writing code for Resource Id %q: %+v", name, err)
		}
	}

	return nil
}
