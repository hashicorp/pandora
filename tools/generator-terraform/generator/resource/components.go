package resource

import (
	"github.com/hashicorp/pandora/tools/generator-terraform/generator/models"
)

func componentsForResource(input models.ResourceInput) []string {
	return []string{
		// NOTE: the ordering is important, components can opt in/out of generation
		packageDefinitionForResource(input),
		generationNoteForResource(),
		copyrightLinesForResource(input),
		importsForResource(input),
		definitionForResource(input),

		// then the functions
		idValidationFunctionForResource(input),
		typeFuncForResource(input),
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
}
