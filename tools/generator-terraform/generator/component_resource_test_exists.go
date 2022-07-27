package generator

import "fmt"

func existsFuncForResourceTest(input ResourceInput) string {
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

	methodArguments := argumentsForApiOperationMethod(readOperation, input.SdkResourceName, input.Details.ReadMethod.MethodName, true)


	return fmt.Sprintf(`
func (r %[1]sResource) Exists(ctx context.Context, clients *clients.Client, state *pluginsdk.InstanceState) (*bool, error) {
	id, err := %[2]s(state.ID)
	if err != nil {
		return nil, err
	}

	resp, err := clients.%[3]s.%[1]sClient.%[4]s(%[5]s)
	if err != nil {
		return fmt.Errorf("reading %%s: %%+v", *id, err)
	}

	return utils.Bool(resp.Model != nil), nil
}
`, input.ResourceTypeName, *idParseLine, input.ServiceName, input.Details.ReadMethod.MethodName, methodArguments)
}
