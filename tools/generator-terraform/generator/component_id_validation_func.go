package generator

import "fmt"

func idValidationFunctionForResource(input ResourceInput) string {
	if !input.Details.GenerateIdValidation {
		return ""
	}

	validationLine, err := input.validateResourceIdFuncName()
	if err != nil {
		// TODO: thread through errors
		panic(err)
	}

	return fmt.Sprintf(`
func (r %[1]sResource) IDValidationFunc() pluginsdk.SchemaValidateFunc {
	return %[2]s
}
`, input.ResourceTypeName, *validationLine)
}
