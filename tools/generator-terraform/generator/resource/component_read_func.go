package resource

import (
	"fmt"
	"sort"
	"strings"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"

	"github.com/hashicorp/pandora/tools/generator-terraform/generator/models"
)

type readFunctionComponents struct {
	idParseLine     string
	models          map[string]resourcemanager.ModelDetails
	readMethod      resourcemanager.MethodDefinition
	readOperation   resourcemanager.ApiOperation
	resourceId      resourcemanager.ResourceIdDefinition
	schemaModelName string
	sdkResourceName string
	terraformModel  resourcemanager.TerraformSchemaModelDefinition
	topLevelModel   resourcemanager.ModelDetails
}

func readFunctionForResource(input models.ResourceInput) (*string, error) {
	if !input.Details.ReadMethod.Generate {
		return nil, nil
	}

	readOperation, ok := input.Operations[input.Details.ReadMethod.MethodName]
	if !ok {
		return nil, fmt.Errorf("couldn't find read operation named %q", input.Details.ReadMethod.MethodName)
	}

	idParseLine, err := input.ParseResourceIdFuncName()
	if err != nil {
		return nil, fmt.Errorf("determining Parse function name for Resource ID: %+v", err)
	}

	terraformModel, ok := input.SchemaModels[input.SchemaModelName]
	if !ok {
		return nil, fmt.Errorf("the Schema Model named %q was not found", input.SchemaModelName)
	}

	resourceId, ok := input.ResourceIds[input.Details.ResourceIdName]
	if !ok {
		return nil, fmt.Errorf("the Resource ID named %q was not found", input.Details.ResourceIdName)
	}

	// at this point we only support References being returned, so this is safe
	topLevelModel, ok := input.Models[*readOperation.ResponseObject.ReferenceName]
	if !ok {
		return nil, fmt.Errorf("the top-level model %q used in the response was not found", *readOperation.ResponseObject.ReferenceName)
	}

	helper := readFunctionComponents{
		idParseLine:     *idParseLine,
		readMethod:      input.Details.ReadMethod,
		readOperation:   readOperation,
		resourceId:      resourceId,
		schemaModelName: input.SchemaModelName,
		sdkResourceName: input.SdkResourceName,
		terraformModel:  terraformModel,
		topLevelModel:   topLevelModel,
	}
	components := []func() (*string, error){
		helper.codeForIDParser,
		helper.codeForGet,
		helper.codeForModelAssignments,
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
func (r %[1]sResource) Read() sdk.ResourceFunc {
	return sdk.ResourceFunc{
		Timeout: %[2]d * time.Minute,
		Func: func(ctx context.Context, metadata sdk.ResourceMetaData) error {
			client := metadata.Client.%[3]s.%[4]s
			schema := %[5]s{}

			%[6]s

			return metadata.Encode(&schema)
		},
	}
}
`, input.ResourceTypeName, input.Details.ReadMethod.TimeoutInMinutes, input.ServiceName, input.SdkResourceName, input.SchemaModelName, strings.Join(lines, "\n\n"))
	return &output, nil
}

func (c readFunctionComponents) codeForIDParser() (*string, error) {
	output := fmt.Sprintf(`
			id, err := %[1]s(metadata.ResourceData.Id())
			if err != nil {
				return err
			}
`, c.idParseLine)
	return &output, nil
}

func (c readFunctionComponents) codeForGet() (*string, error) {
	methodArguments := argumentsForApiOperationMethod(c.readOperation, c.sdkResourceName, c.readMethod.MethodName, true)
	output := fmt.Sprintf(`
			resp, err := client.%[1]s(%[2]s)
			if err != nil {
				if response.WasNotFound(resp.HttpResponse) {
					return metadata.MarkAsGone(*id)
				}
				return fmt.Errorf("retrieving %%s: %%+v", *id, err)
			}
`, c.readMethod.MethodName, methodArguments)
	return &output, nil
}

func (c readFunctionComponents) codeForModelAssignments() (*string, error) {
	// TODO: tests for this

	// first map all of the Resource ID segments across
	resourceIdMappings, err := c.codeForResourceIdMappings()
	if err != nil {
		return nil, fmt.Errorf("building code for resource id mappings: %+v", err)
	}
	// then output the top-level mappings, which'll call into nested items as required
	topLevelMappings, err := c.codeForTopLevelMappings()
	if err != nil {
		return nil, fmt.Errorf("building code for top-level field mappings: %+v", err)
	}
	output := fmt.Sprintf(`
			if model := resp.Model; model != nil {
				%[1]s

				%[2]s
			}
`, *resourceIdMappings, *topLevelMappings)
	return &output, nil
}

func (c readFunctionComponents) codeForResourceIdMappings() (*string, error) {
	// TODO: tests for this
	lines := make([]string, 0)

	// TODO: note that when there's a parent ID field present we'll need to call `parent.NewParentID(..).ID()`
	// to get the right URI
	for _, v := range c.resourceId.Segments {
		if v.Type == resourcemanager.ResourceProviderSegment || v.Type == resourcemanager.StaticSegment {
			continue
		}
		// Subscription ID is a special-case that isn't output
		if v.Type == resourcemanager.SubscriptionIdSegment {
			continue
		}

		topLevelFieldForResourceIdSegment, err := findTopLevelFieldForResourceIdSegment(v.Name, c.terraformModel)
		if err != nil {
			return nil, fmt.Errorf("finding mapping for resource id segment %q: %+v", v.Name, err)
		}

		lines = append(lines, fmt.Sprintf("schema.%s = id.%s", *topLevelFieldForResourceIdSegment, strings.Title(v.Name)))
	}
	sort.Strings(lines)

	output := strings.Join(lines, "\n")
	return &output, nil
}

func (c readFunctionComponents) codeForTopLevelMappings() (*string, error) {
	// TODO: tests for this
	mappings := make([]string, 0)

	// ensure these are output alphabetically for consistency purposes across re-generations
	orderedFieldNames := make([]string, 0)
	for fieldName := range c.terraformModel.Fields {
		orderedFieldNames = append(orderedFieldNames, fieldName)
	}
	sort.Strings(orderedFieldNames)

	for _, tfFieldName := range orderedFieldNames {
		tfField := c.terraformModel.Fields[tfFieldName]
		if tfField.Mappings.SdkPathForRead == nil {
			continue
		}

		assignmentVariable := fmt.Sprintf("schema.%s", tfFieldName)
		codeForMapping, err := flattenAssignmentCodeForField(assignmentVariable, tfFieldName, tfField, c.topLevelModel, c.models)
		if err != nil {
			return nil, fmt.Errorf("building flatten assignment code for field %q: %+v", tfFieldName, err)
		}

		mappings = append(mappings, *codeForMapping)
	}

	sort.Strings(mappings)
	output := strings.Join(mappings, "\n")
	return &output, nil
}
