package dataapigeneratoryaml

import (
	"sort"

	"github.com/go-yaml/yaml"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

type Package struct {
	Name       string   `yaml:"Name"`
	Operations []string `yaml:"Operations"`
	Constants  []string `yaml:"Constants"`
	Models     []string `yaml:"Models"`
}

func codeForPackageDefinition(resourceName string, input models.AzureApiResource) ([]byte, error) {
	operationNames := make([]string, 0)
	for operation := range input.Operations {
		operationNames = append(operationNames, operation)
	}
	sort.Strings(operationNames)

	operations := make([]string, 0)

	for _, operationName := range operationNames {
		operations = append(operations, operationName)
	}

	constantNames := make([]string, 0)
	for k := range input.Constants {
		constantNames = append(constantNames, k)
	}
	sort.Strings(constantNames)

	constants := make([]string, 0)
	for _, constantName := range constantNames {
		constants = append(constants, constantName)
	}

	modelNames := make([]string, 0)
	for k := range input.Models {
		modelNames = append(modelNames, k)
	}
	sort.Strings(modelNames)

	resourceModels := make([]string, 0)
	for _, modelName := range modelNames {
		resourceModels = append(resourceModels, modelName)
	}

	pkg := Package{
		Name:       resourceName,
		Operations: operations,
		Constants:  constants,
		Models:     resourceModels,
	}

	data, err := yaml.Marshal(&pkg)
	if err != nil {
		return nil, err
	}

	return data, nil
}
