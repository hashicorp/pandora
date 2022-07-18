package generator

import (
	"fmt"
)

func deleteFunctionForResource(input ResourceInput) string {
	if !input.Details.DeleteMethod.Generate {
		return ""
	}

	idParseLine, err := input.parseResourceIdFuncName()
	if err != nil {
		// TODO: thread through errors
		panic(err)
	}

	deleteOperation, ok := input.Operations[input.Details.DeleteMethod.MethodName]
	if !ok {
		// TODO: thread through errors
		panic(fmt.Sprintf("couldn't find delete operation named %q", input.Details.DeleteMethod.MethodName))
	}

	deleteMethodName := input.Details.DeleteMethod.MethodName
	if deleteOperation.LongRunning {
		deleteMethodName = fmt.Sprintf("%sThenPoll", deleteMethodName)
	}
	methodArguments := argumentsForApiOperationMethod(deleteOperation, input.SdkResourceName, input.Details.DeleteMethod.MethodName)

	return fmt.Sprintf(`
func (r %[1]sResource) Delete() sdk.ResourceFunc {
	return sdk.ResourceFunc{
		Timeout: %[2]d * time.Minute,
		Func: func(ctx context.Context, metadata sdk.ResourceMetaData) error {
			client := metadata.Client.%[3]s.%[1]sClient

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
}
