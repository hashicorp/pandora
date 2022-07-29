package resource

import (
	"strings"

	"github.com/hashicorp/pandora/tools/generator-terraform/generator/models"
)

func codeForResource(input models.ResourceInput) (*string, error) {
	components := []func(input models.ResourceInput) (*string, error){
		// NOTE: the ordering is important, components can opt in/out of generation
		packageDefinitionForResource,
		generationNoteForResource,
		copyrightLinesForResource,
		importsForResource,
		definitionForResource,

		// then the functions
		idValidationFunctionForResource,
		typeFuncForResource,
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
			lines = append(lines, *line)
		}
	}

	items := []string{
		argumentsCodeFunctionForResource(input),
		attributesCodeFunctionForResource(input),
		createFunctionForResource(input),
		// TODO: Mappings
		readFunctionForResource(input),
		deleteFunctionForResource(input),
		// TODO: Typed Model & Model func.
		updateFuncForResource(input),
		methodsYetToBeImplementedForResource(input),
	}
	output := strings.Join(items, "\n")
	return &output, nil
}
