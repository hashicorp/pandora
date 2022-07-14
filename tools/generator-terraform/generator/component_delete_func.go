package generator

import (
	"fmt"
	"strings"
)

func deleteFunctionForResource(input ResourceInput) string {
	if !input.Details.GenerateDelete {
		return ""
	}

	// TODO: we're going to need to generate a "Client" within the SDK which exposes one of everything
	// that allows this to become way simpler
	clientName := "Resources"
	timeoutInMinutes := 30

	idParseLine, err := input.parseResourceIdFuncName()
	if err != nil {
		// TODO: thread through errors
		panic(err)
	}

	deleteOperation, ok := input.Operations[input.Details.DeleteMethodName]
	if !ok {
		// TODO: thread through errors
		panic(fmt.Sprintf("couldn't find delete operation named %q", input.Details.DeleteMethodName))
	}

	deleteMethodName := input.Details.DeleteMethodName
	if deleteOperation.LongRunning {
		deleteMethodName = fmt.Sprintf("%sThenPoll", deleteMethodName)
	}

	deleteMethodArguments := []string{
		"ctx",
		"id",
	}
	if len(deleteOperation.Options) > 0 {
		// NOTE: we're intentionally using `input.Details.DeleteMethodName` rather than `deleteMethodName` since we want the options object
		optionsArgument := fmt.Sprintf("%[1]s.Default%[2]sOperationOptions()", input.ServicePackageName, input.Details.DeleteMethodName)
		deleteMethodArguments = append(deleteMethodArguments, optionsArgument)
	}

	return fmt.Sprintf(`
func (r %[1]sResource) Delete() sdk.ResourceFunc {
	return sdk.ResourceFunc{
		Timeout: %[2]d * time.Minute,
		Func: func(ctx context.Context, metadata sdk.ResourceMetaData) error {
			client := metadata.Client.%[3]s //TODO: add a meta client for each service

			id, err := %[4]s(metadata.ResourceData.Id())
			if err != nil {
				return err
			}

			if err := client.%[5]s(ctx, id%[6]s); err != nil {
				return fmt.Errorf("deleting %%s: %%+v", *id, err)
			}

			return nil
		},
	}
}
`, input.ResourceTypeName, timeoutInMinutes, clientName, *idParseLine, deleteMethodName, strings.Join(deleteMethodArguments, ", "))
}
