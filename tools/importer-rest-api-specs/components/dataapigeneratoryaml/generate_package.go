package dataapigeneratoryaml

import (
	"fmt"
	"path"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

func (s Generator) generateResources(resourceName, resourceMetadata string, resource models.AzureApiResource, workingDirectory string) error {
	s.logger.Debug(fmt.Sprintf("Generating %q (Resource %q)..", resourceMetadata, resourceName))

	if err := RecreateDirectory(workingDirectory, s.logger); err != nil {
		return fmt.Errorf("recreating directory %q: %+v", workingDirectory, err)
	}

	s.logger.Debug("Generating Constants..")
	for constantName, vals := range resource.Constants {
		s.logger.Trace(fmt.Sprintf("Generating Constant %q (in %s)", constantName, resourceMetadata))
		code, err := codeForConstant(constantName, vals)
		if err != nil {
			return fmt.Errorf("marshaling Constants: %+v", err)
		}
		fileName := path.Join(workingDirectory, fmt.Sprintf("Constant-%s.yaml", constantName))
		if err := writeYamlToFile(fileName, code); err != nil {
			return fmt.Errorf("generating code for %q: %+v", constantName, err)
		}
	}

	s.logger.Debug("Generating Models..")
	for modelName, vals := range resource.Models {
		s.logger.Trace(fmt.Sprintf("Generating Model %q (in %s)", modelName, resourceMetadata))

		var parent *models.ModelDetails
		if vals.ParentTypeName != nil {
			p, ok := resource.Models[*vals.ParentTypeName]
			if ok {
				parent = &p
			}
		}

		code, err := codeForModel(resourceMetadata, modelName, vals, parent, resource.Constants, resource.Models)
		if err != nil {
			return fmt.Errorf("generating code for model %q in %q: %+v", modelName, resourceMetadata, err)
		}
		fileName := path.Join(workingDirectory, fmt.Sprintf("Model-%s.yaml", modelName))
		if code != nil {
			if err := writeYamlToFile(fileName, code); err != nil {
				return fmt.Errorf("writing code for model %q: %+v", modelName, err)
			}
		}
	}

	s.logger.Debug("Generating Operations..")
	for operationName, operation := range resource.Operations {
		s.logger.Trace(fmt.Sprintf("Generating Operation %q (in %s)", operationName, resourceMetadata))
		code, err := codeForOperation(operationName, operation, resource)
		if err != nil {
			return fmt.Errorf("marshaling Operation %q: %+v", operationName, err)
		}
		fileName := path.Join(workingDirectory, fmt.Sprintf("Operation-%s.yaml", operationName))
		if err := writeYamlToFile(fileName, code); err != nil {
			return fmt.Errorf("writing code for operation %q: %+v", operationName, err)
		}
	}

	s.logger.Debug("Generating Resource IDs..")
	for name, id := range resource.ResourceIds {
		s.logger.Trace(fmt.Sprintf("Generating Resource ID %q (in %s)", name, resourceMetadata))
		code, err := codeForResourceID(name, id)
		if err != nil {
			return fmt.Errorf("generating Resource ID %q in %q: %+v", name, resourceMetadata, err)
		}
		fileName := path.Join(workingDirectory, fmt.Sprintf("ResourceId-%s.yaml", name))
		if err := writeYamlToFile(fileName, code); err != nil {
			return fmt.Errorf("writing code for Resource Id %q: %+v", name, err)
		}
	}

	return nil
}
