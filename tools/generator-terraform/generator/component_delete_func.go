package generator

import (
	"fmt"
	"strings"
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

	deleteMethodArguments := []string{
		"ctx",
		"id",
	}
	if len(deleteOperation.Options) > 0 {
		// NOTE: we're intentionally using `input.Details.DeleteMethodName` rather than `deleteMethodName` since we want the options object
		optionsArgument := fmt.Sprintf("%[1]s.Default%[2]sOperationOptions()", input.ServicePackageName, input.Details.DeleteMethod.MethodName)
		deleteMethodArguments = append(deleteMethodArguments, optionsArgument)
	}

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
`, input.ResourceTypeName, input.Details.DeleteMethod.TimeoutInMinutes, input.ServiceName, *idParseLine, deleteMethodName, strings.Join(deleteMethodArguments, ", "))
}
