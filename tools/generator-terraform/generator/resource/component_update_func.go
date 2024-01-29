// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package resource

import (
	"fmt"
	"strings"

	"github.com/hashicorp/pandora/tools/generator-terraform/generator/helpers"
	"github.com/hashicorp/pandora/tools/generator-terraform/generator/models"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func updateFuncForResource(input models.ResourceInput) (*string, error) {
	if input.Details.UpdateMethod == nil || !input.Details.UpdateMethod.Generate {
		return nil, nil
	}

	idParseLine, err := input.ParseResourceIdFuncName()
	if err != nil {
		return nil, fmt.Errorf("determining Parse function name for Resource ID: %+v", err)
	}

	updateOperation, ok := input.Operations[input.Details.UpdateMethod.MethodName]
	if !ok {
		return nil, fmt.Errorf("couldn't find update operation named %q", input.Details.UpdateMethod.MethodName)
	}

	createOperation, ok := input.Operations[input.Details.CreateMethod.MethodName]
	if !ok {
		return nil, fmt.Errorf("couldn't find create operation named %q for update operation", input.Details.CreateMethod.MethodName)
	}

	readOperation, ok := input.Operations[input.Details.ReadMethod.MethodName]
	if !ok {
		return nil, fmt.Errorf("couldn't find read operation named %q for update operation", input.Details.ReadMethod.MethodName)
	}

	terraformModel, ok := input.SchemaModels[input.SchemaModelName]
	if !ok {
		return nil, fmt.Errorf("internal-error: schema model %q was not found", input.SchemaModelName)
	}

	// we only support References, which have to have a ReferenceName so this isn't a panic
	topLevelModel, ok := input.Models[*updateOperation.RequestObject.ReferenceName]
	if !ok {
		return nil, fmt.Errorf("internal-error: top level model named %q was not found", *updateOperation.RequestObject.ReferenceName)
	}

	updateHelpers := updateFuncHelpers{
		schemaModelName:         input.SchemaModelName,
		sdkResourceNameLowered:  strings.ToLower(input.SdkResourceName),
		createMethod:            createOperation,
		createMethodName:        input.Details.CreateMethod.MethodName,
		updateMethod:            updateOperation,
		updateMethodName:        input.Details.UpdateMethod.MethodName,
		readMethod:              readOperation,
		readMethodName:          input.Details.ReadMethod.MethodName,
		resourceIdParseFuncName: *idParseLine,
		resourceTypeName:        input.ResourceTypeName,
		models:                  input.Models,
		topLevelModel:           topLevelModel,
		terraformModel:          terraformModel,
	}
	components := []func() (*string, error){
		updateHelpers.resourceIdParser,
		updateHelpers.modelDecode,
		updateHelpers.payloadDefinition,
		updateHelpers.update,
	}

	lines := make([]string, 0)
	for i, component := range components {
		result, err := component()
		if err != nil {
			return nil, fmt.Errorf("running component %d: %+v", i, err)
		}
		lines = append(lines, *result)
	}

	output := fmt.Sprintf(`
func (r %[1]sResource) Update() sdk.ResourceFunc {
	return sdk.ResourceFunc{
		Timeout: %[2]d * time.Minute,
		Func: func(ctx context.Context, metadata sdk.ResourceMetaData) error {
			client := metadata.Client.%[3]s.%[6]s.%[4]s

			%[5]s

			return nil
		},
	}
}
`, input.ResourceTypeName, input.Details.UpdateMethod.TimeoutInMinutes, input.ServiceName, input.SdkResourceName, strings.Join(lines, "\n"), strings.Title(helpers.NamespaceForApiVersion(input.SdkApiVersion)))
	return &output, nil
}

type updateFuncHelpers struct {
	schemaModelName        string
	sdkResourceNameLowered string

	createMethod     resourcemanager.ApiOperation
	createMethodName string

	updateMethod     resourcemanager.ApiOperation
	updateMethodName string

	readMethod     resourcemanager.ApiOperation
	readMethodName string

	resourceIdParseFuncName string
	resourceTypeName        string

	terraformModel resourcemanager.TerraformSchemaModelDefinition
	topLevelModel  resourcemanager.ModelDetails
	models         map[string]resourcemanager.ModelDetails
}

func (h updateFuncHelpers) modelDecode() (*string, error) {
	output := fmt.Sprintf(`
			var config %[1]s
			if err := metadata.Decode(&config); err != nil {
				return fmt.Errorf("decoding: %%+v", err)
			}
`, h.schemaModelName)
	return &output, nil
}

func (h updateFuncHelpers) payloadDefinition() (*string, error) {
	updateObjectName, err := h.updateMethod.RequestObject.GolangTypeName(&h.sdkResourceNameLowered)
	if err != nil {
		return nil, fmt.Errorf("determining Golang Type name for Update Request Object: %+v", err)
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
		methodArguments := argumentsForApiOperationMethod(h.readMethod, h.sdkResourceNameLowered, h.readMethodName, true)
		output := fmt.Sprintf(`
			existing, err := client.%[1]s(%[2]s)
			if err != nil {
				return fmt.Errorf("retrieving existing %%s: %%+v", *id, err)
			}
			if existing.Model == nil {
				return fmt.Errorf("retrieving existing %%s: properties was nil", *id)
			}
			payload := *existing.Model

			if err := r.map%[3]sTo%[4]s(config, &payload); err != nil {
				return fmt.Errorf("mapping schema model to sdk model: %%+v", err)
			}
`, methodName, methodArguments, h.schemaModelName, *h.updateMethod.RequestObject.ReferenceName)
		return &output, nil
	}

	output := fmt.Sprintf(`
			var payload %[1]s
			if err := r.map%[2]sTo%[3]s(config, &payload); err != nil {
				return fmt.Errorf("mapping schema model to sdk model: %%+v", err)
			}
`, *updateObjectName, h.schemaModelName, *h.updateMethod.RequestObject.ReferenceName)
	return &output, nil
}

func (h updateFuncHelpers) resourceIdParser() (*string, error) {
	output := fmt.Sprintf(`
			id, err := %[1]s(metadata.ResourceData.Id())
			if err != nil {
				return err
			}
`, h.resourceIdParseFuncName)
	return &output, nil
}

func (h updateFuncHelpers) update() (*string, error) {
	methodName := methodNameToCallForOperation(h.updateMethod, h.updateMethodName)
	methodArguments := argumentsForApiOperationMethod(h.updateMethod, h.sdkResourceNameLowered, h.updateMethodName, true)
	variablesForMethod := "err"
	if !h.createMethod.LongRunning {
		variablesForMethod = "_, err"
	}

	output := fmt.Sprintf(`
			if %[3]s := client.%[1]s(%[2]s); err != nil {
				return fmt.Errorf("updating %%s: %%+v", *id, err)
			}
`, methodName, methodArguments, variablesForMethod)
	return &output, nil
}
