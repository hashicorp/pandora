package resource

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/generator-terraform/generator/models"
)

func deleteFunctionForResource(input models.ResourceInput) (*string, error) {
	if !input.Details.DeleteMethod.Generate {
		return nil, nil
	}

	idParseLine, err := input.ParseResourceIdFuncName()
	if err != nil {
		return nil, fmt.Errorf("determining Parse function name for Resource ID: %+v", err)
	}

	deleteOperation, ok := input.Operations[input.Details.DeleteMethod.MethodName]
	if !ok {
		return nil, fmt.Errorf("couldn't find delete operation named %q", input.Details.DeleteMethod.MethodName)
	}

	methodArguments := argumentsForApiOperationMethod(deleteOperation, input.SdkResourceName, input.Details.DeleteMethod.MethodName, true)
	deleteMethodName := methodNameToCallForOperation(deleteOperation, input.Details.DeleteMethod.MethodName)

	output := fmt.Sprintf(`
func (r %[1]sResource) Delete() sdk.ResourceFunc {
	return sdk.ResourceFunc{
		Timeout: %[2]d * time.Minute,
		Func: func(ctx context.Context, metadata sdk.ResourceMetaData) error {
			client := metadata.Client.%[3]s.%[1]s

			id, err := %[4]s(metadata.ResourceData.Id())
			if err != nil {
				return err
			}

			if err := client.%[5]s(%[6]s); err != nil {
				return fmt.Errorf("deleting %%s: %%+v", *id, err)
			}

			return nil
		},
	}
}
`, input.ResourceTypeName, input.Details.DeleteMethod.TimeoutInMinutes, input.ServiceName, *idParseLine, deleteMethodName, methodArguments)
	return &output, nil
}
