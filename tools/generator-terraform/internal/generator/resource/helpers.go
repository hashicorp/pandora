// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package resource

import (
	"fmt"
	"strings"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

func argumentsForApiOperationMethod(operation models.SDKOperation, sdkResourceName, methodName string, idIsAPointer bool) string {
	methodArguments := []string{
		"ctx",
	}

	if operation.ResourceIDName != nil {
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
		optionsArgument := fmt.Sprintf("%[1]s.Default%[2]sOperationOptions()", strings.ToLower(sdkResourceName), methodName)
		methodArguments = append(methodArguments, optionsArgument)
	}

	return strings.Join(methodArguments, ", ")
}

func methodNameToCallForOperation(operation models.SDKOperation, methodName string) string {
	if operation.LongRunning {
		return fmt.Sprintf("%sThenPoll", methodName)
	}

	return methodName
}

func updateTemplateWithVariableNames(input string) (template *string, variableNames *string, err error) {
	variables := make([]string, 0)

	// NOTE: we could parse the hcl config directly at this point, and an earlier version of this did just that
	// however it's far simpler to string replace these in retrospect
	lines := make([]string, 0)
	for _, line := range strings.Split(input, "\n") {
		if strings.HasPrefix(line, `variable "primary_location"`) {
			lines = append(lines, `variable "primary_location" {
  default = %q
}`)
			variables = append(variables, "data.Locations.Primary")
			continue
		}
		if strings.HasPrefix(line, `variable "random_integer"`) {
			lines = append(lines, `variable "random_integer" {
  default = %d
}`)
			variables = append(variables, "data.RandomInteger")
			continue
		}
		if strings.HasPrefix(line, `variable "random_string"`) {
			lines = append(lines, `variable "random_string" {
  default = %q
}`)
			variables = append(variables, "data.RandomString")
			continue
		}

		lines = append(lines, line)
	}

	template = pointer.To(strings.Join(lines, "\n"))
	variableNames = pointer.To(strings.Join(variables, ", "))
	return
}
