// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package resource

import (
	"fmt"
	"strings"

	"github.com/hashicorp/pandora/tools/generator-terraform/internal/generator/helpers"
	"github.com/hashicorp/pandora/tools/generator-terraform/internal/generator/models"
)

func deleteFunctionForResource(input models.ResourceInput) (*string, error) {
	if !input.Details.DeleteMethod.Generate {
		return nil, nil
	}

	idParseLine, err := input.ParseResourceIdFuncName()
	if err != nil {
		return nil, fmt.Errorf("determining Parse function name for Resource ID: %+v", err)
	}

	deleteOperation, ok := input.Operations[input.Details.DeleteMethod.SDKOperationName]
	if !ok {
		return nil, fmt.Errorf("couldn't find delete operation named %q", input.Details.DeleteMethod.SDKOperationName)
	}

	methodArguments := argumentsForApiOperationMethod(deleteOperation, input.SdkResourceName, input.Details.DeleteMethod.SDKOperationName, true)
	deleteMethodName := methodNameToCallForOperation(deleteOperation, input.Details.DeleteMethod.SDKOperationName)
	variablesForMethod := "err"
	if !deleteOperation.LongRunning {
		variablesForMethod = "_, err"
	}

	output := fmt.Sprintf(`
func (r %[1]sResource) Delete() sdk.ResourceFunc {
	return sdk.ResourceFunc{
		Timeout: %[2]d * time.Minute,
		Func: func(ctx context.Context, metadata sdk.ResourceMetaData) error {
			client := metadata.Client.%[3]s.%[9]s.%[4]s

			id, err := %[5]s(metadata.ResourceData.Id())
			if err != nil {
				return err
			}

			if %[8]s := client.%[6]s(%[7]s); err != nil {
				return fmt.Errorf("deleting %%s: %%+v", *id, err)
			}

			return nil
		},
	}
}
`, input.ResourceTypeName, input.Details.DeleteMethod.TimeoutInMinutes, input.ServiceName, input.SdkResourceName, *idParseLine, deleteMethodName, methodArguments, variablesForMethod, strings.Title(helpers.NamespaceForApiVersion(input.SdkApiVersion)))
	return &output, nil
}
