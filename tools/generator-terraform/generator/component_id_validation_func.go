package generator

import (
	"fmt"
	"strings"
)

func idValidationFunctionForResource(input ResourceInput) string {
	if !input.Details.GenerateIdValidation {
		return ""
	}

	resourceId, ok := input.ResourceIds[input.Details.ResourceIdName]
	if !ok {
		// TODO: thread through errors
		panic(fmt.Sprintf("missing Resource ID %q", input.Details.ResourceIdName))
	}

	validationLine := fmt.Sprintf("%[1]s.Validate%[2]sID", input.SdkResourceName, strings.TrimSuffix(input.Details.ResourceIdName, "Id"))
	if resourceId.CommonAlias != nil {
		validationLine = fmt.Sprintf("commonids.Validate%[1]sID", *resourceId.CommonAlias)
	}

	return fmt.Sprintf(`
func (r %[1]sResource) IDValidationFunc() pluginsdk.SchemaValidateFunc {
	return %[2]s
}
`, input.ResourceTypeName, validationLine)
}
