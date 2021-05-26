package generator

import (
	"fmt"
	"log"
	"path"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

type PandoraDefinitionGenerator struct {
	rootNamespace string
	serviceName   string
	apiVersion    string
	debugLog      bool
}

func NewPackageDefinitionGenerator(rootNamespace, serviceName, apiVersion string, debug bool) PandoraDefinitionGenerator {
	return PandoraDefinitionGenerator{
		rootNamespace: rootNamespace,
		serviceName:   serviceName,
		apiVersion:    apiVersion,
		debugLog:      debug,
	}
}

func (g PandoraDefinitionGenerator) Generate(resourceName string, resource models.AzureApiResource, workingDirectory string) error {
	namespace := g.namespace(resourceName)
	if g.debugLog {
		log.Printf("[DEBUG] Generating %q..", namespace)
	}

	// TODO: we should duplicate the types depending on the operation
	// This would allow us to have a "CreateThing", "UpdateThing" and "GetThing" where "Thing"
	// defines a single model in the Swagger. These could then output the specifics for each field, for example
	// the GetThing model would be the only one with the ReadOnly fields output
	// We'd also need to parse the mutability data out of the fields, which we're not doing today - but exists in
	// the Swagger and is parsed out just unused

	if g.debugLog {
		log.Printf("[DEBUG] Generating Constants..")
	}
	for constantName, vals := range resource.Constants {
		if g.debugLog {
			log.Printf("Generating Constant %q (in %s)", constantName, namespace)
		}
		code := g.codeForConstant(namespace, constantName, vals)
		fileName := path.Join(workingDirectory, fmt.Sprintf("Constant-%s.cs", constantName))
		if err := writeToFile(fileName, code); err != nil {
			return fmt.Errorf("generating code for %q: %+v", constantName, err)
		}
	}

	if g.debugLog {
		log.Printf("[DEBUG] Generating Models..")
	}
	for modelName, vals := range resource.Models {
		if g.debugLog {
			log.Printf("Generating Model %q (in %s)", modelName, namespace)
		}

		var parent *models.ModelDetails
		if vals.ParentTypeName != nil {
			p, ok := resource.Models[*vals.ParentTypeName]
			if ok {
				parent = &p
			}
		}

		code, err := g.codeForModel(namespace, modelName, vals, parent)
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

	if g.debugLog {
		log.Printf("[DEBUG] Generating Operations..")
	}
	for operationName, operation := range resource.Operations {
		if g.debugLog {
			log.Printf("Generating Operation %q (in %s)", operationName, namespace)
		}
		code := g.codeForOperation(namespace, operationName, operation)
		fileName := path.Join(workingDirectory, fmt.Sprintf("Operation-%s.cs", operationName))
		if err := writeToFile(fileName, code); err != nil {
			return fmt.Errorf("writing code for operation %q: %+v", operationName, err)
		}
	}

	if g.debugLog {
		log.Printf("[DEBUG] Generating Resource IDs..")
	}
	for name, id := range resource.ResourceIds {
		if g.debugLog {
			log.Printf("Generating Resource ID %q (in %s)", name, namespace)
		}
		code := g.codeForResourceID(namespace, name, id)
		fileName := path.Join(workingDirectory, fmt.Sprintf("ResourceId-%s.cs", name))
		if err := writeToFile(fileName, code); err != nil {
			return fmt.Errorf("writing code for Resource Id %q: %+v", name, err)
		}
	}

	if g.debugLog {
		log.Printf("[DEBUG] Generating Package Definition..")
	}
	packageDefinitionCode := g.codeForPackageDefinition(namespace, resource.Operations)
	packageDefinitionFileName := path.Join(workingDirectory, "Definition.cs")
	if err := writeToFile(packageDefinitionFileName, packageDefinitionCode); err != nil {
		return fmt.Errorf("writing package definition for %q: %+v", packageDefinitionFileName, err)
	}

	return nil
}

func (g PandoraDefinitionGenerator) RecommendedWorkingDirectory(rootDirectory, resourceName string) string {
	apiVersion := g.normalizeApiVersion()
	return path.Join(rootDirectory, g.rootNamespace, g.serviceName, apiVersion, resourceName)
}
