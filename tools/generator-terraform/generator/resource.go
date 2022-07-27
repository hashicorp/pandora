package generator

import (
	"fmt"
	"os"
	"strings"
)

func Resource(input ResourceInput) error {
	// ensure the service directory exists
	serviceDirectory := fmt.Sprintf("%s/internal/services/%s", input.RootDirectory, input.ServicePackageName)
	os.MkdirAll(serviceDirectory, 0755)

	// TODO: generating Tests and Docs

	filePath := fmt.Sprintf("%s/%s_resource.gen.go", serviceDirectory, input.ResourceLabel)
	// remove the file if it already exists
	os.Remove(filePath)

	components := []string{
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
		deleteFunctionForResource(input),
		// TODO: Mappings
		readFunctionForResource(input),
		// TODO: Schema
		// TODO: Typed Model & Model func.
		updateFuncForResource(input),
		methodsYetToBeImplementedForResource(input),
	}
	writeToPath(filePath, strings.Join(components, "\n"))
	return nil
}
