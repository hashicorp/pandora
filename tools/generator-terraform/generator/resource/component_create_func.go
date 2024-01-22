// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package resource

import (
	"fmt"
	"github.com/hashicorp/pandora/tools/generator-terraform/generator/helpers"
	"strings"

	"github.com/hashicorp/pandora/tools/generator-terraform/generator/models"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

type createFunctionComponents struct {
	createMethod     resourcemanager.ApiOperation
	createMethodName string

	readMethod     resourcemanager.ApiOperation
	readMethodName string

	resourceTypeName       string
	sdkResourceName        string
	sdkResourceNameLowered string

	models                map[string]resourcemanager.ModelDetails
	mappings              resourcemanager.MappingDefinition
	newResourceIdFuncName string
	resourceId            resourcemanager.ResourceIdDefinition

	terraformModel     resourcemanager.TerraformSchemaModelDefinition
	terraformModelName string
	topLevelModel      resourcemanager.ModelDetails
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

	// we only support References, which have to have a ReferenceName so this isn't a panic
	topLevelModelName := *createOperation.RequestObject.ReferenceName
	topLevelModel, ok := input.Models[topLevelModelName]
	if !ok {
		return nil, fmt.Errorf("internal-error: top level model named %q was not found", *createOperation.RequestObject.ReferenceName)
	}

	helper := createFunctionComponents{
		createMethod:           createOperation,
		createMethodName:       input.Details.CreateMethod.MethodName,
		readMethod:             readOperation,
		readMethodName:         input.Details.ReadMethod.MethodName,
		resourceTypeName:       input.ResourceTypeName,
		sdkResourceName:        input.SdkResourceName,
		sdkResourceNameLowered: strings.ToLower(input.SdkResourceName),
		mappings:               input.Details.Mappings,
		models:                 input.Models,
		newResourceIdFuncName:  *newResourceIdFuncName,
		resourceId:             resourceId,
		terraformModel:         terraformModel,
		terraformModelName:     input.SchemaModelName,
		topLevelModel:          topLevelModel,
	}
	components := []func() (*string, error){
		helper.schemaDeserialization,
		helper.idDefinitionAndMapping,
		helper.requiresImport,
		helper.payloadDefinition,
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
			client := metadata.Client.%[3]s.%[4]s.%[5]s

			%[6]s

			metadata.SetID(id)
			return nil
		},
	}
}
`, input.ResourceTypeName, input.Details.CreateMethod.TimeoutInMinutes, input.ServiceName, strings.Title(helpers.NamespaceForApiVersion(input.SdkApiVersion)), input.SdkResourceName, strings.Join(lines, "\n"))
	return &output, nil
}

func (h createFunctionComponents) create() (*string, error) {
	methodName := methodNameToCallForOperation(h.createMethod, h.createMethodName)
	methodArguments := argumentsForApiOperationMethod(h.createMethod, h.sdkResourceNameLowered, h.createMethodName, false)
	variablesForMethod := "err"
	if !h.createMethod.LongRunning {
		variablesForMethod = "_, err"
	}

	output := fmt.Sprintf(`
			if %[3]s := client.%[1]s(%[2]s); err != nil {
				return fmt.Errorf("creating %%s: %%+v", id, err)
			}
`, methodName, methodArguments, variablesForMethod)
	return &output, nil
}

func (h createFunctionComponents) idDefinitionAndMapping() (*string, error) {
	newIdFuncName := h.newResourceIdFuncName
	segments := make([]string, 0)
	parseParentId := ""

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
				// find the associated mapping and output the relevant field to output the ID
				for _, resourceIdMapping := range h.mappings.ResourceId {
					if resourceIdMapping.SegmentName != v.Name {
						continue
					}

					if v.ConstantReference != nil {
						constantTypeName := fmt.Sprintf("%s.%s", h.sdkResourceNameLowered, *v.ConstantReference)
						segments = append(segments, fmt.Sprintf("%s(config.%s)", constantTypeName, resourceIdMapping.SchemaFieldName))
					} else if resourceIdMapping.ParsedFromParentID {
						if !strings.EqualFold(v.Name, "resourceGroupName") && parseParentId == "" {
							parentResource := strings.Replace(resourceIdMapping.SchemaFieldName, "Id", "", -1)
							parseParentId = fmt.Sprintf(`
								%[1]sId, err := commonids.Parse%[2]sID(config.%[3]s)
								if err != nil {
									return err
								}
							`, helpers.CamelCasedName(parentResource), parentResource, resourceIdMapping.SchemaFieldName)
						}
						segments = append(segments, fmt.Sprintf("%s.%s", helpers.CamelCasedName(resourceIdMapping.SchemaFieldName), strings.Title(resourceIdMapping.SegmentName)))
					} else {
						segments = append(segments, fmt.Sprintf("config.%s", resourceIdMapping.SchemaFieldName))
					}
					break
				}
			}
		}
	}

	output := fmt.Sprintf(`
%[1]s
%[2]s
id := %[3]s(%[4]s)
`, subscriptionIdDefinition, parseParentId, newIdFuncName, strings.Join(segments, ", "))
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
			var payload %[1]s
			if err := r.map%[2]sTo%[3]s(config, &payload); err != nil {
				return fmt.Errorf("mapping schema model to sdk model: %%+v", err)
			}
`, *createObjectName, h.terraformModelName, *h.createMethod.RequestObject.ReferenceName)
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
`, h.terraformModelName)
	return &output, nil
}
