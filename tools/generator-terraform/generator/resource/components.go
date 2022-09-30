package resource

import (
	"strings"

	"github.com/hashicorp/pandora/tools/generator-terraform/generator/models"
)

func componentsForResourceTest(input models.ResourceInput) (*string, error) {
	components := []func(input models.ResourceInput) (*string, error){
		packageTestDefinitionForResource,
		generationNoteForResource,
		// Do something about acctest license?
		copyrightLinesForResource,
		importsForResourceTest,

		testResourceStruct,
		codeForResourceTestFunctions,
		existsFuncForResourceTest,
		codeForResourceTestConfigurationFunctions,
	}

	lines := make([]string, 0)
	for _, component := range components {
		line, err := component(input)
		if err != nil {
			return nil, err
		}

		// components can opt-out of generation so if it's not generating anything
		// do nothing
		if line != nil {
			lines = append(lines, strings.TrimSpace(*line))
		}
	}
	output := strings.Join(lines, "\n")
	return &output, nil
}

func codeForResource(input models.ResourceInput) (*string, error) {
	components := []func(input models.ResourceInput) (*string, error){
		// NOTE: the ordering is important, components can opt in/out of generation
		packageDefinitionForResource,
		generationNoteForResource,
		copyrightLinesForResource,
		importsForResource,
		definitionForResource,

		// then the Top-Level Typed Model/it's function definition
		codeForTopLevelTypedModelAndDefinition,

		// then the other functions
		idValidationFunctionForResource,
		typeFuncForResource,
		argumentsCodeFunctionForResource,
		attributesCodeFunctionForResource,
		createFunctionForResource,
		readFunctionForResource,
		deleteFunctionForResource,
		updateFuncForResource,

		codeForNonTopLevelModels,
		codeForMappings,
	}

	lines := make([]string, 0)
	for _, component := range components {
		line, err := component(input)
		if err != nil {
			return nil, err
		}

		// components can opt-out of generation so if it's not generating anything
		// do nothing
		if line != nil {
			lines = append(lines, strings.TrimSpace(*line))
		}
	}
	output := strings.Join(lines, "\n")
	return &output, nil
}
