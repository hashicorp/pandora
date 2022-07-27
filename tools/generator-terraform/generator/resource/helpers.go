package resource

import (
	"fmt"
	"strings"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func argumentsForApiOperationMethod(operation resourcemanager.ApiOperation, sdkResourceName, methodName string, idIsAPointer bool) string {
	methodArguments := []string{
		"ctx",
	}

	if operation.ResourceIdName != nil {
		if idIsAPointer {
			methodArguments = append(methodArguments, "*id")
		} else {
			methodArguments = append(methodArguments, "id")
		}
	}

	if operation.RequestObject != nil {
		// the object for `payload` will always be defined in the CRUD method - we're naming it such for consistency
		methodArguments = append(methodArguments, "payload")
	}

	if len(operation.Options) > 0 {
		optionsArgument := fmt.Sprintf("%[1]s.Default%[2]sOperationOptions()", sdkResourceName, methodName)
		methodArguments = append(methodArguments, optionsArgument)
	}

	return strings.Join(methodArguments, ", ")
}

func methodNameToCallForOperation(operation resourcemanager.ApiOperation, methodName string) string {
	if operation.LongRunning {
		return fmt.Sprintf("%sThenPoll", methodName)
	}

	return methodName
}
