package generator

import (
	"fmt"
	"strings"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func argumentsForApiOperationMethod(operation resourcemanager.ApiOperation, sdkResourceName, methodName string) string {
	methodArguments := []string{
		"ctx",
		"id",
	}

	// TODO: Payload

	if len(operation.Options) > 0 {
		optionsArgument := fmt.Sprintf("%[1]s.Default%[2]sOperationOptions()", sdkResourceName, methodName)
		methodArguments = append(methodArguments, optionsArgument)
	}

	return strings.Join(methodArguments, ", ")
}
