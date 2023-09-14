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

	// TODO Generate Models
	// TODO Generate Operations

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

	s.logger.Debug("Generating Package Definition..")
	packageDefinitionCode, err := codeForPackageDefinition(resourceName, resource)
	if err != nil {
		return fmt.Errorf("marshaling Package Definition: %+v", err)
	}
	packageDefinitionFileName := path.Join(workingDirectory, "Definition.yaml")
	if err := writeYamlToFile(packageDefinitionFileName, packageDefinitionCode); err != nil {
		return fmt.Errorf("writing package definition for %q: %+v", packageDefinitionFileName, err)
	}

	return nil
}
