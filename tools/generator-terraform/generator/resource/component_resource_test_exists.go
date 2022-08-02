package resource

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/generator-terraform/generator/models"
)

func existsFuncForResourceTest(input models.ResourceInput) (*string, error) {
	if !input.Details.ReadMethod.Generate {
		return nil, nil
	}

	idParseLine, err := input.ParseResourceIdFuncName()
	if err != nil {
		return nil, fmt.Errorf("determining Parse function name for Resource ID: %+v", err)
	}

	readOperation, ok := input.Operations[input.Details.ReadMethod.MethodName]
	if !ok {
		return nil, fmt.Errorf("couldn't find read operation named %q", input.Details.ReadMethod.MethodName)
	}

	methodArguments := argumentsForApiOperationMethod(readOperation, input.SdkResourceName, input.Details.ReadMethod.MethodName, true)
	output := fmt.Sprintf(`
func (r %[1]sTestResource) Exists(ctx context.Context, clients *clients.Client, state *pluginsdk.InstanceState) (*bool, error) {
	id, err := %[2]s(state.ID)
	if err != nil {
		return nil, err
	}

	resp, err := clients.%[3]s.%[4]s.%[5]s(%[6]s)
	if err != nil {
		return nil, fmt.Errorf("reading %%s: %%+v", *id, err)
	}

	return utils.Bool(resp.Model != nil), nil
}
`, input.ResourceTypeName, *idParseLine, input.ServiceName, input.SdkResourceName, input.Details.ReadMethod.MethodName, methodArguments)
	return &output, nil
}
