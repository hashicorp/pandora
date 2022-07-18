package generator

import (
	"fmt"
)

func readFunctionForResource(input ResourceInput) string {
	if !input.Details.ReadMethod.Generate {
		return ""
	}

	idParseLine, err := input.parseResourceIdFuncName()
	if err != nil {
		// TODO: thread through errors
		panic(err)
	}

	readOperation, ok := input.Operations[input.Details.ReadMethod.MethodName]
	if !ok {
		// TODO: thread through errors
		panic(fmt.Sprintf("couldn't find read operation named %q", input.Details.ReadMethod.MethodName))
	}

	methodArguments := argumentsForApiOperationMethod(readOperation, input.SdkResourceName, input.Details.ReadMethod.MethodName)

	return fmt.Sprintf(`
func (r %[1]sResource) Read() sdk.ResourceFunc {
	return sdk.ResourceFunc{
		Timeout: %[2]d * time.Minute,
		Func: func(ctx context.Context, metadata sdk.ResourceMetaData) error {
			client := metadata.Client.%[3]s.%[1]sClient

			id, err := %[4]s(metadata.ResourceData.Id())
			if err != nil {
				return err
			}

			resp, err := client.%[5]s(%[6]s)
			if err != nil {
				if response.WasNotFound(resp.HttpResponse) {
					return metadata.MarkAsGone(*id)
				}
				return fmt.Errorf("retrieving %%s: %%+v", *id, err)
			}

			if model := resp.Model; model != nil {
				// TODO: set the ID fields into the Schema
				// TODO: set the fields from 'model' into the schema
			}

			return nil
		},
	}
}
`, input.ResourceTypeName, input.Details.ReadMethod.TimeoutInMinutes, input.ServiceName, *idParseLine, input.Details.ReadMethod.MethodName, methodArguments)
}
