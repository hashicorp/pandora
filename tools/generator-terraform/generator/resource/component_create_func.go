package resource

import (
	"fmt"
	"strings"

	"github.com/hashicorp/pandora/tools/generator-terraform/generator/models"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

type createFunctionComponents struct {
	readMethod             resourcemanager.ApiOperation
	readMethodName         string
	createMethod           resourcemanager.ApiOperation
	createMethodName       string
	resourceTypeName       string
	schemaModelName        string
	sdkResourceNameLowered string
	newResourceIdFuncName  string
	resourceId             resourcemanager.ResourceIdDefinition
	terraformModel         resourcemanager.TerraformSchemaModelDefinition
}

func createFunctionForResource(input models.ResourceInput) (*string, error) {
	if !input.Details.CreateMethod.Generate {
		return nil, nil
	}

	createOperation, ok := input.Operations[input.Details.CreateMethod.MethodName]
	if !ok {
		return nil, fmt.Errorf("couldn't find create operation named %q", input.Details.CreateMethod.MethodName)
	}

	readOperation, ok := input.Operations[input.Details.ReadMethod.MethodName]
	if !ok {
		return nil, fmt.Errorf("couldn't find Read operation for create operation named %q", input.Details.ReadMethod.MethodName)
	}

	resourceId, ok := input.ResourceIds[input.Details.ResourceIdName]
	if !ok {
		return nil, fmt.Errorf("couldn't find Resource ID %q for Create Method", input.Details.ResourceIdName)
	}

	newResourceIdFuncName, err := input.NewResourceIdFuncName()
	if err != nil {
		return nil, fmt.Errorf("obtaining New Resource ID Function for Create Method: %+v", err)
	}

	terraformModel, ok := input.SchemaModels[input.SchemaModelName]
	if !ok {
		return nil, fmt.Errorf("internal-error: schema model %q was not found", input.SchemaModelName)
	}

	helper := createFunctionComponents{
		readMethod:             readOperation,
		readMethodName:         input.Details.ReadMethod.MethodName,
		createMethod:           createOperation,
		createMethodName:       input.Details.CreateMethod.MethodName,
		resourceTypeName:       input.ResourceTypeName,
		schemaModelName:        input.SchemaModelName,
		sdkResourceNameLowered: strings.ToLower(input.SdkResourceName),
		newResourceIdFuncName:  *newResourceIdFuncName,
		resourceId:             resourceId,
		terraformModel:         terraformModel,
	}
	components := []func() (*string, error){
		helper.schemaDeserialization,
		helper.idDefinitionAndMapping,
		helper.requiresImport,
		helper.payloadDefinition,
		helper.mappingsFromSchema,
		helper.create,
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
func (r %[1]sResource) Create() sdk.ResourceFunc {
	return sdk.ResourceFunc{
		Timeout: %[2]d * time.Minute,
		Func: func(ctx context.Context, metadata sdk.ResourceMetaData) error {
			client := metadata.Client.%[3]s.%[1]s

			%[4]s

			metadata.SetID(id)
			return nil
		},
	}
}
`, input.ResourceTypeName, input.Details.CreateMethod.TimeoutInMinutes, input.ServiceName, strings.Join(lines, "\n"))
	return &output, nil
}

func (h createFunctionComponents) create() (*string, error) {
	methodName := methodNameToCallForOperation(h.createMethod, h.createMethodName)
	methodArguments := argumentsForApiOperationMethod(h.createMethod, h.sdkResourceNameLowered, h.createMethodName, false)
	output := fmt.Sprintf(`
			if err := client.%[1]s(%[2]s); err != nil {
				return fmt.Errorf("creating %%s: %%+v", id, err)
			}
`, methodName, methodArguments)
	return &output, nil
}

func (h createFunctionComponents) idDefinitionAndMapping() (*string, error) {
	newIdFuncName := h.newResourceIdFuncName
	segments := make([]string, 0)

	subscriptionIdDefinition := ""
	for _, v := range h.resourceId.Segments {
		if v.Type == resourcemanager.ResourceProviderSegment || v.Type == resourcemanager.StaticSegment {
			continue
		}

		switch v.Type {
		case resourcemanager.SubscriptionIdSegment:
			{
				segments = append(segments, "subscriptionId")
				subscriptionIdDefinition = "subscriptionId := metadata.Client.Account.SubscriptionId"
				continue
			}

		default:
			{
				topLevelFieldForResourceIdSegment, err := findTopLevelFieldForResourceIdSegment(v.Name, h.terraformModel)
				if err != nil {
					return nil, fmt.Errorf("finding mapping for resource id segment %q: %+v", v.Name, err)
				}

				if topLevelFieldForResourceIdSegment != nil {
					segments = append(segments, fmt.Sprintf("config.%s", *topLevelFieldForResourceIdSegment))
				}
			}
		}
	}

	output := fmt.Sprintf(`
%[3]s
id := %[1]s(%[2]s)
`, newIdFuncName, strings.Join(segments, ", "), subscriptionIdDefinition)
	return &output, nil
}

func (h createFunctionComponents) payloadDefinition() (*string, error) {
	// NOTE: whilst Payload is _technically_ optional in the API endpoint it's not, else it
	// wouldn't be a Create method
	createObjectName, err := h.createMethod.RequestObject.GolangTypeName(&h.sdkResourceNameLowered)
	if err != nil {
		return nil, fmt.Errorf("determining Golang Type name for Create Request Object: %+v", err)
	}

	output := fmt.Sprintf(`
			payload := %[1]s{}
`, *createObjectName)
	return &output, nil
}

func (h createFunctionComponents) mappingsFromSchema() (*string, error) {
	output := `
			// TODO: mapping from the Schema -> Payload
`
	return &output, nil
}

func (h createFunctionComponents) requiresImport() (*string, error) {
	readMethodArguments := argumentsForApiOperationMethod(h.readMethod, h.sdkResourceNameLowered, h.readMethodName, false)
	output := fmt.Sprintf(`
			existing, err := client.%[1]s(%[2]s)
			if err != nil {
				if !response.WasNotFound(existing.HttpResponse) {
					return fmt.Errorf("checking for the presence of an existing %%s: %%+v", id, err)
				}
			}
			if !response.WasNotFound(existing.HttpResponse) {
				return metadata.ResourceRequiresImport(r.ResourceType(), id)
			}
`, h.readMethodName, readMethodArguments)
	return &output, nil
}

func (h createFunctionComponents) schemaDeserialization() (*string, error) {
	output := fmt.Sprintf(`
			var config %[1]s
			if err := metadata.Decode(&config); err != nil {
				return fmt.Errorf("decoding: %%+v", err)
			}
`, h.schemaModelName)
	return &output, nil
}
