package resource

import (
	"fmt"
	"strings"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func updateFuncForResource(input ResourceInput) string {
	if input.Details.UpdateMethod == nil || !input.Details.UpdateMethod.Generate {
		return ""
	}

	idParseLine, err := input.parseResourceIdFuncName()
	if err != nil {
		// TODO: thread through errors
		panic(err)
	}

	updateOperation, ok := input.Operations[input.Details.UpdateMethod.MethodName]
	if !ok {
		// TODO: thread through errors
		panic(fmt.Sprintf("couldn't find update operation named %q", input.Details.UpdateMethod.MethodName))
	}

	createOperation, ok := input.Operations[input.Details.CreateMethod.MethodName]
	if !ok {
		// TODO: thread through errors
		panic(fmt.Sprintf("couldn't find create operation named %q for update operation", input.Details.CreateMethod.MethodName))
	}

	readOperation, ok := input.Operations[input.Details.ReadMethod.MethodName]
	if !ok {
		// TODO: thread through errors
		panic(fmt.Sprintf("couldn't find read operation named %q for update operation", input.Details.ReadMethod.MethodName))
	}

	helpers := updateFuncHelpers{
		sdkResourceName:         input.SdkResourceName,
		createMethod:            createOperation,
		createMethodName:        input.Details.CreateMethod.MethodName,
		updateMethod:            updateOperation,
		updateMethodName:        input.Details.UpdateMethod.MethodName,
		readMethod:              readOperation,
		readMethodName:          input.Details.ReadMethod.MethodName,
		resourceIdParseFuncName: *idParseLine,
		resourceTypeName:        input.ResourceTypeName,
	}
	components := []string{
		helpers.resourceIdParser(),
		helpers.modelDecode(),
		helpers.payloadDefinition(),
		helpers.mappingsFromSchema(),
		helpers.update(),
	}

	return fmt.Sprintf(`
func (r %[1]sResource) Update() sdk.ResourceFunc {
	return sdk.ResourceFunc{
		Timeout: %[2]d * time.Minute,
		Func: func(ctx context.Context, metadata sdk.ResourceMetaData) error {
			client := metadata.Client.%[3]s.%[1]sClient

			%[4]s

			return nil
		},
	}
}
`, input.ResourceTypeName, input.Details.UpdateMethod.TimeoutInMinutes, input.ServiceName, strings.Join(components, "\n"))
}

type updateFuncHelpers struct {
	sdkResourceName string

	createMethod     resourcemanager.ApiOperation
	createMethodName string

	updateMethod     resourcemanager.ApiOperation
	updateMethodName string

	readMethod     resourcemanager.ApiOperation
	readMethodName string

	resourceIdParseFuncName string
	resourceTypeName        string
}

func (h updateFuncHelpers) mappingsFromSchema() string {
	return `
			// TODO: mapping from the Schema -> Payload
`
}

func (h updateFuncHelpers) modelDecode() string {
	return fmt.Sprintf(`
			var config %[1]sResourceModel
			if err := metadata.Decode(&config); err != nil {
				return fmt.Errorf("decoding: %%+v", err)
			}
`, h.resourceTypeName)
}

func (h updateFuncHelpers) payloadDefinition() string {
	updateObjectName, err := h.updateMethod.RequestObject.GolangTypeName(&h.sdkResourceName)
	if err != nil {
		// TODO: thread through errors
		panic(fmt.Sprintf("determining Golang Type name for Update Request Object: %+v", err))
	}

	// if the same method is used for CreateOrUpdate - and Read - then we need to load and patch the existing resource
	hasMatchingPayloads := false
	if h.updateMethod.RequestObject != nil && h.createMethod.RequestObject != nil && h.readMethod.ResponseObject != nil {
		if h.updateMethod.RequestObject != nil && h.updateMethod.RequestObject.Type == resourcemanager.ReferenceApiObjectDefinitionType {
			hasMatchingPayloads = h.updateMethod.RequestObject.Matches(h.createMethod.RequestObject) && h.updateMethod.RequestObject.Matches(h.readMethod.ResponseObject)
		}
	}

	if hasMatchingPayloads {
		methodName := methodNameToCallForOperation(h.readMethod, h.readMethodName)
		methodArguments := argumentsForApiOperationMethod(h.readMethod, h.sdkResourceName, h.readMethodName, true)
		return fmt.Sprintf(`
			existing, err := client.%[1]s(%[2]s)
			if err != nil {
				return fmt.Errorf("retrieving existing %%s: %%+v", *id, err)
			}
			if existing.Model == nil {
				return fmt.Errorf("retrieving existing %%s: properties was nil", *id)
			}
			payload := *existing.Model
`, methodName, methodArguments)
	}

	return fmt.Sprintf(`
			payload := %[1]s{}
`, *updateObjectName)
}

func (h updateFuncHelpers) resourceIdParser() string {
	return fmt.Sprintf(`
			id, err := %[1]s(metadata.ResourceData.Id())
			if err != nil {
				return err
			}
`, h.resourceIdParseFuncName)
}

func (h updateFuncHelpers) update() string {
	methodName := methodNameToCallForOperation(h.updateMethod, h.updateMethodName)
	methodArguments := argumentsForApiOperationMethod(h.updateMethod, h.sdkResourceName, h.updateMethodName, true)
	return fmt.Sprintf(`
			if err := client.%[1]s(%[2]s); err != nil {
				return fmt.Errorf("updating %%s: %%+v", *id, err)
			}
`, methodName, methodArguments)
}
