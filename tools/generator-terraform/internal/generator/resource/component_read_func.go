// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package resource

import (
	"fmt"
	"sort"
	"strings"

	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/generator-terraform/internal/generator/helpers"
	generatorModels "github.com/hashicorp/pandora/tools/generator-terraform/internal/generator/models"
)

type readFunctionComponents struct {
	constants       map[string]models.SDKConstant
	idParseLine     string
	mappings        models.TerraformMappingDefinition
	parentResource  string
	parentSegment   string
	readMethod      models.TerraformMethodDefinition
	readOperation   models.SDKOperation
	resourceId      models.ResourceID
	schemaModelName string
	sdkResourceName string
	terraformModel  models.TerraformSchemaModel
	topLevelModel   models.SDKModel
}

func readFunctionForResource(input generatorModels.ResourceInput) (*string, error) {
	if !input.Details.ReadMethod.Generate {
		return nil, nil
	}

	readOperation, ok := input.Operations[input.Details.ReadMethod.SDKOperationName]
	if !ok {
		return nil, fmt.Errorf("couldn't find read operation named %q", input.Details.ReadMethod.SDKOperationName)
	}

	idParseLine, err := input.ParseResourceIdFuncName()
	if err != nil {
		return nil, fmt.Errorf("determining Parse function name for Resource ID: %+v", err)
	}

	parentResource := ""
	parentSegment := ""

	for _, m := range input.Details.Mappings.ResourceID {
		if m.ParsedFromParentID {
			// TODO this relies on the fact that the resource ID mappings are output in a certain order
			// for now it's okay but we should make this more robust
			parentResource = m.TerraformSchemaFieldName
			parentSegment = m.SegmentName
			break
		}
	}

	terraformModel, ok := input.SchemaModels[input.SchemaModelName]
	if !ok {
		return nil, fmt.Errorf("the Schema Model named %q was not found", input.SchemaModelName)
	}

	resourceId, ok := input.ResourceIds[input.Details.ResourceIDName]
	if !ok {
		return nil, fmt.Errorf("the Resource ID named %q was not found", input.Details.ResourceIDName)
	}

	// at this point we only support References being returned, so this is safe
	topLevelModel, ok := input.Models[*readOperation.ResponseObject.ReferenceName]
	if !ok {
		return nil, fmt.Errorf("the top-level model %q used in the response was not found", *readOperation.ResponseObject.ReferenceName)
	}

	helper := readFunctionComponents{
		constants:       input.Constants,
		idParseLine:     *idParseLine,
		mappings:        input.Details.Mappings,
		parentResource:  parentResource,
		parentSegment:   parentSegment,
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
			client := metadata.Client.%[3]s.%[7]s.%[4]s
			schema := %[5]s{}

			%[6]s

			return metadata.Encode(&schema)
		},
	}
}
`, input.ResourceTypeName, input.Details.ReadMethod.TimeoutInMinutes, input.ServiceName, input.SdkResourceName, input.SchemaModelName, strings.Join(lines, "\n\n"), strings.Title(helpers.NamespaceForApiVersion(input.SdkApiVersion)))
	return &output, nil
}

func (c readFunctionComponents) codeForIDParser() (*string, error) {
	output := fmt.Sprintf(`
			id, err := %[1]s(metadata.ResourceData.Id())
			if err != nil {
				return err
			}
`, c.idParseLine)

	if c.parentResource != "" && c.parentSegment != "" {
		output += fmt.Sprintf("\t\t\n%s := commonids.New%s(id.SubscriptionId, id.ResourceGroupName, id.%s)", helpers.CamelCasedName(c.parentResource), strings.Replace(c.parentResource, "Id", "ID", -1), strings.Title(c.parentSegment))
	}

	return &output, nil
}

func (c readFunctionComponents) codeForGet() (*string, error) {
	methodArguments := argumentsForApiOperationMethod(c.readOperation, c.sdkResourceName, c.readMethod.SDKOperationName, true)
	output := fmt.Sprintf(`
			resp, err := client.%[1]s(%[2]s)
			if err != nil {
				if response.WasNotFound(resp.HttpResponse) {
					return metadata.MarkAsGone(*id)
				}
				return fmt.Errorf("retrieving %%s: %%+v", *id, err)
			}
`, c.readMethod.SDKOperationName, methodArguments)
	return &output, nil
}

func (c readFunctionComponents) codeForModelAssignments() (*string, error) {
	// first map all the Resource ID segments across
	resourceIdMappings, err := c.codeForResourceIdMappings()
	if err != nil {
		return nil, fmt.Errorf("building code for resource id mappings: %+v", err)
	}

	output := fmt.Sprintf(`
			if model := resp.Model; model != nil {
				%[1]s
				if err := r.map%[2]sTo%[3]s(*model, &schema); err != nil {
					return fmt.Errorf("flattening model: %%+v", err)
				}
			}
`, *resourceIdMappings, *c.readOperation.ResponseObject.ReferenceName, c.schemaModelName)
	return &output, nil
}

func (c readFunctionComponents) codeForResourceIdMappings() (*string, error) {
	lines := make([]string, 0)

	for _, v := range c.resourceId.Segments {
		if v.Type == models.StaticResourceIDSegmentType || v.Type == models.SubscriptionIDResourceIDSegmentType {
			continue
		}

		for _, resourceIdMapping := range c.mappings.ResourceID {
			if resourceIdMapping.SegmentName != v.Name {
				continue
			}

			if v.Type == models.ResourceGroupResourceIDSegmentType && c.parentResource != "" {
				continue
			}
			// Constants are output into the Schema as their native types (e.g. int/float/string) so we need to convert prior to assigning
			if v.ConstantReference != nil {
				constant, ok := c.constants[*v.ConstantReference]
				if !ok {
					return nil, fmt.Errorf("the constant %q referenced in Resource ID Segment %q was not found", *v.ConstantReference, v.Name)
				}
				constantGoTypeName, err := helpers.GolangFieldTypeFromConstantType(constant.Type)
				if err != nil {
					return nil, fmt.Errorf("determining Golang Type name for Constant Type %q: %+v", string(constant.Type), err)
				}
				lines = append(lines, fmt.Sprintf("schema.%s = %s(id.%s)", resourceIdMapping.TerraformSchemaFieldName, *constantGoTypeName, strings.Title(resourceIdMapping.SegmentName)))
			} else if c.parentResource != "" && v.Name == c.parentSegment {
				lines = append(lines, fmt.Sprintf("schema.%s = %s.ID()", c.parentResource, helpers.CamelCasedName(c.parentResource)))
			} else {
				lines = append(lines, fmt.Sprintf("schema.%s = id.%s", resourceIdMapping.TerraformSchemaFieldName, strings.Title(resourceIdMapping.SegmentName)))
			}
			break
		}
	}

	sort.Strings(lines)

	output := strings.Join(lines, "\n")
	return &output, nil
}
