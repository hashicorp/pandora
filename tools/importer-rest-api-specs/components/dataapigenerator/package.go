package dataapigenerator

import (
	"fmt"
	"path"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

func (s Generator) generateResources(resourceName, namespace string, resource models.AzureApiResource, workingDirectory string) error {
	s.logger.Debug(fmt.Sprintf("Generating %q (Resource %q)..", namespace, resourceName))

	if err := RecreateDirectory(workingDirectory, s.logger); err != nil {
		return fmt.Errorf("recreating directory %q: %+v", workingDirectory, err)
	}

	// TODO: we should duplicate the types depending on the operation
	// This would allow us to have a "CreateThing", "UpdateThing" and "GetThing" where "Thing"
	// defines a single model in the Swagger. These could then output the specifics for each field, for example
	// the GetThing model would be the only one with the ReadOnly fields output
	// We'd also need to parse the mutability data out of the fields, which we're not doing today - but exists in
	// the Swagger and is parsed out just unused

	s.logger.Debug("Generating Constants..")
	for constantName, vals := range resource.Constants {
		s.logger.Trace(fmt.Sprintf("Generating Constant %q (in %q)", constantName, namespace))
		code, err := codeForConstant(namespace, constantName, vals)
		if err != nil {
			return err
		}
		fileName := path.Join(workingDirectory, fmt.Sprintf("Constant-%s.cs", constantName))
		if err := writeToFile(fileName, *code); err != nil {
			return fmt.Errorf("generating code for %q: %+v", constantName, err)
		}
	}

	s.logger.Debug("Generating Models..")
	for modelName, vals := range resource.Models {
		s.logger.Trace(fmt.Sprintf("Generating Model %q (in %s)", modelName, namespace))

		var parent *models.ModelDetails
		if vals.ParentTypeName != nil {
			p, ok := resource.Models[*vals.ParentTypeName]
			if ok {
				parent = &p
			}
		}

		code, err := codeForModel(namespace, modelName, vals, parent, resource.Constants, resource.Models)
		if err != nil {
			return fmt.Errorf("generating code for model %q in %q: %+v", modelName, namespace, err)
		}
		fileName := path.Join(workingDirectory, fmt.Sprintf("Model-%s.cs", modelName))
		if *code != "" {
			if err := writeToFile(fileName, *code); err != nil {
				return fmt.Errorf("writing code for model %q: %+v", modelName, err)
			}
		}
	}

	s.logger.Debug("Generating Operations..")
	for operationName, operation := range resource.Operations {
		s.logger.Trace(fmt.Sprintf("Generating Operation %q (in %s)", operationName, namespace))
		code, err := codeForOperation(namespace, operationName, operation, resource)
		if err != nil {
			return fmt.Errorf("generating code for operation %q in %q: %+v", operationName, namespace, err)
		}
		fileName := path.Join(workingDirectory, fmt.Sprintf("Operation-%s.cs", operationName))
		if err := writeToFile(fileName, *code); err != nil {
			return fmt.Errorf("writing code for operation %q: %+v", operationName, err)
		}
	}

	s.logger.Debug("Generating Resource IDs..")
	for name, id := range resource.ResourceIds {
		s.logger.Trace(fmt.Sprintf("Generating Resource ID %q (in %s)", name, namespace))
		code, err := codeForResourceID(namespace, name, id)
		if err != nil {
			return fmt.Errorf("generating Resource ID %q in %q: %+v", name, namespace, err)
		}
		fileName := path.Join(workingDirectory, fmt.Sprintf("ResourceId-%s.cs", name))
		if err := writeToFile(fileName, *code); err != nil {
			return fmt.Errorf("writing code for Resource Id %q: %+v", name, err)
		}
	}

	s.logger.Debug("Generating Package Definition..")
	packageDefinitionCode := codeForPackageDefinition(namespace, resourceName, resource)
	packageDefinitionFileName := path.Join(workingDirectory, "Definition.cs")
	if err := writeToFile(packageDefinitionFileName, packageDefinitionCode); err != nil {
		return fmt.Errorf("writing package definition for %q: %+v", packageDefinitionFileName, err)
	}

	return nil
}
