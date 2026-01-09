// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package identification

import (
	"fmt"
	"strings"

	sdkHelpers "github.com/hashicorp/pandora/tools/data-api-sdk/v1/helpers"
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/logging"
	"github.com/hashicorp/pandora/tools/sdk/config/definitions"
)

type methodsForResource struct {
	createMethod *sdkModels.TerraformMethodDefinition
	deleteMethod *sdkModels.TerraformMethodDefinition
	getMethod    *sdkModels.TerraformMethodDefinition
	updateMethod *sdkModels.TerraformMethodDefinition
}

func identifyMethodsForAPIResource(input sdkModels.APIResource, resourceMetaData definitions.ResourceDefinition, resourceIdName string) (*methodsForResource, error) {
	methods := methodsForResource{}

	for operationName, operation := range input.Operations {
		logging.Tracef("Processing Candidate Operation %q (%q)", operationName, operation.Method)

		// if it's an operation on just a suffix we're not interested
		if operation.ResourceIDName == nil {
			logging.Trace("ResourceIDName was nil for this Operation, skipping")
			continue
		}
		if *operation.ResourceIDName != resourceIdName {
			logging.Tracef("ResourceIDName differed for this Operation (%q vs %q), skipping", *operation.ResourceIDName, resourceIdName)
			continue
		}

		if (strings.EqualFold(operation.Method, "POST") || strings.EqualFold(operation.Method, "PUT")) && operation.URISuffix == nil && operation.RequestObject != nil {
			methods.createMethod = &sdkModels.TerraformMethodDefinition{
				Generate:         resourceMetaData.GenerateCreate,
				SDKOperationName: operationName,
				TimeoutInMinutes: 30,
			}
		}
		if strings.EqualFold(operation.Method, "PATCH") && operation.URISuffix == nil && operation.RequestObject != nil {
			v := strings.ToLower(operationName)
			// if this is UpdateTags etc, ignore it since the model will be totally unrelated
			if v != "update" && strings.HasPrefix(v, "update") {
				continue
			}
			objectDefinition := sdkHelpers.InnerMostSDKObjectDefinition(*operation.RequestObject)
			if objectDefinition.Type != sdkModels.ReferenceSDKObjectDefinitionType {
				continue
			}
			model, ok := input.Models[*objectDefinition.ReferenceName]
			if !ok {
				return nil, fmt.Errorf("the request model %q for operation %q was not found", *objectDefinition.ReferenceName, operationName)
			}
			_, hasPropertiesField := model.Fields["Properties"]
			if !hasPropertiesField {
				continue
			}

			methods.updateMethod = &sdkModels.TerraformMethodDefinition{
				Generate:         resourceMetaData.GenerateUpdate,
				SDKOperationName: operationName,
				TimeoutInMinutes: 30,
			}
		}
		if strings.EqualFold(operation.Method, "GET") && operation.URISuffix == nil && operation.ResponseObject != nil {
			if operation.URISuffix == nil {
				methods.getMethod = &sdkModels.TerraformMethodDefinition{
					Generate:         resourceMetaData.GenerateRead,
					SDKOperationName: operationName,
					TimeoutInMinutes: 5,
				}
			}
		}
		if strings.EqualFold(operation.Method, "DELETE") && operation.URISuffix == nil {
			methods.deleteMethod = &sdkModels.TerraformMethodDefinition{
				Generate:         resourceMetaData.GenerateDelete,
				SDKOperationName: operationName,
				TimeoutInMinutes: 30,
			}
		}
		// TODO: determine if we're concerned with these in the future (e.g. ListKeys etc)
		// if operation.URISuffix != nil && !strings.EqualFold(operation.Method, "GET") {
		//	hasSuffixedMethods = true
		// }
	}

	// once we've been over all the methods, check if the Create method is actually CreateOrUpdate
	if methods.updateMethod == nil && methods.createMethod != nil {
		// handle CreateOrUpdate, but only when there's no Update method
		if strings.Contains(strings.ToLower(methods.createMethod.SDKOperationName), "update") {
			methods.updateMethod = &sdkModels.TerraformMethodDefinition{
				Generate:         resourceMetaData.GenerateUpdate,
				SDKOperationName: methods.createMethod.SDKOperationName,
				TimeoutInMinutes: 30,
			}
		}
	}

	return &methods, nil
}
