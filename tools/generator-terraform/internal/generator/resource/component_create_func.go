// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package resource

import (
	"fmt"
	"strings"

	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/helpers"
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	generatorHelpers "github.com/hashicorp/pandora/tools/generator-terraform/internal/generator/helpers"
	generatorModels "github.com/hashicorp/pandora/tools/generator-terraform/internal/generator/models"
)

type createFunctionComponents struct {
	createMethod     models.SDKOperation
	createMethodName string

	readMethod     models.SDKOperation
	readMethodName string

	resourceTypeName       string
	sdkResourceName        string
	sdkResourceNameLowered string

	models                map[string]models.SDKModel
	mappings              models.TerraformMappingDefinition
	newResourceIdFuncName string
	resourceId            models.ResourceID

	terraformModel     models.TerraformSchemaModel
	terraformModelName string
	topLevelModel      models.SDKModel
}

func createFunctionForResource(input generatorModels.ResourceInput) (*string, error) {
	if !input.Details.CreateMethod.Generate {
		return nil, nil
	}

	createOperation, ok := input.Operations[input.Details.CreateMethod.SDKOperationName]
	if !ok {
		return nil, fmt.Errorf("couldn't find create operation named %q", input.Details.CreateMethod.SDKOperationName)
	}

	readOperation, ok := input.Operations[input.Details.ReadMethod.SDKOperationName]
	if !ok {
		return nil, fmt.Errorf("couldn't find Read operation for create operation named %q", input.Details.ReadMethod.SDKOperationName)
	}

	resourceId, ok := input.ResourceIds[input.Details.ResourceIDName]
	if !ok {
		return nil, fmt.Errorf("couldn't find Resource ID %q for Create Method", input.Details.ResourceIDName)
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
		createMethodName:       input.Details.CreateMethod.SDKOperationName,
		readMethod:             readOperation,
		readMethodName:         input.Details.ReadMethod.SDKOperationName,
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
`, input.ResourceTypeName, input.Details.CreateMethod.TimeoutInMinutes, input.ServiceName, strings.Title(generatorHelpers.NamespaceForApiVersion(input.SdkApiVersion)), input.SdkResourceName, strings.Join(lines, "\n"))
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
		if v.Type == models.ResourceProviderResourceIDSegmentType || v.Type == models.StaticResourceIDSegmentType {
			continue
		}

		switch v.Type {
		case models.SubscriptionIDResourceIDSegmentType:
			{
				segments = append(segments, "subscriptionId")
				subscriptionIdDefinition = "subscriptionId := metadata.Client.Account.SubscriptionId"
				continue
			}

		default:
			{
				// find the associated mapping and output the relevant field to output the ID
				for _, resourceIdMapping := range h.mappings.ResourceID {
					if resourceIdMapping.SegmentName != v.Name {
						continue
					}

					if v.ConstantReference != nil {
						constantTypeName := fmt.Sprintf("%s.%s", h.sdkResourceNameLowered, *v.ConstantReference)
						segments = append(segments, fmt.Sprintf("%s(config.%s)", constantTypeName, resourceIdMapping.TerraformSchemaFieldName))
					} else if resourceIdMapping.ParsedFromParentID {
						if !strings.EqualFold(v.Name, "resourceGroupName") && parseParentId == "" {
							parentResource := strings.Replace(resourceIdMapping.TerraformSchemaFieldName, "Id", "", -1)
							parseParentId = fmt.Sprintf(`
								%[1]sId, err := commonids.Parse%[2]sID(config.%[3]s)
								if err != nil {
									return err
								}
							`, generatorHelpers.CamelCasedName(parentResource), parentResource, resourceIdMapping.TerraformSchemaFieldName)
						}
						segments = append(segments, fmt.Sprintf("%s.%s", generatorHelpers.CamelCasedName(resourceIdMapping.TerraformSchemaFieldName), strings.Title(resourceIdMapping.SegmentName)))
					} else {
						segments = append(segments, fmt.Sprintf("config.%s", resourceIdMapping.TerraformSchemaFieldName))
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
	createObjectName, err := helpers.GolangTypeForSDKObjectDefinition(*h.createMethod.RequestObject, &h.sdkResourceNameLowered, nil)
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
