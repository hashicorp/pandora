package resources

import (
	"fmt"
	"strings"

	"github.com/hashicorp/go-hclog"
	"github.com/hashicorp/pandora/tools/sdk/config/definitions"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
	"github.com/hashicorp/pandora/tools/sdk/services"
)

// FindCandidates returns a list of candidate Data Sources and Resources
// within the specified Service
func FindCandidates(input services.Resource, resourceDefinitions map[string]definitions.ResourceDefinition, apiResourceName string, logger hclog.Logger) resourcemanager.TerraformDetails {
	out := resourcemanager.TerraformDetails{
		DataSources: map[string]resourcemanager.TerraformDataSourceDetails{},
		Resources:   map[string]resourcemanager.TerraformResourceDetails{},
	}

	for resourceIdName, resourceId := range input.Schema.ResourceIds {
		// no point
		if resourceId.Segments[0].Type == resourcemanager.ScopeSegment {
			continue
		}

		hasList := false

		var createMethod *resourcemanager.MethodDefinition
		var updateMethod *resourcemanager.MethodDefinition
		var deleteMethod *resourcemanager.MethodDefinition
		var getMethod *resourcemanager.MethodDefinition

		for operationName, operation := range input.Operations.Operations {
			// if it's an operation on just a suffix we're not interested
			if operation.ResourceIdName == nil {
				continue
			}
			if *operation.ResourceIdName != resourceIdName {
				continue
			}

			if (strings.EqualFold(operation.Method, "POST") || strings.EqualFold(operation.Method, "PUT")) && operation.UriSuffix == nil && operation.RequestObject != nil {
				createMethod = &resourcemanager.MethodDefinition{
					Generate:         true,
					MethodName:       operationName,
					TimeoutInMinutes: 30,
				}
			}
			if strings.EqualFold(operation.Method, "PATCH") && operation.UriSuffix == nil && operation.RequestObject != nil {
				v := strings.ToLower(operationName)
				// if this is UpdateTags etc, ignore it since the model will be totally unrelated
				if v != "update" && strings.HasPrefix(v, "update") {
					continue
				}

				updateMethod = &resourcemanager.MethodDefinition{
					Generate:         true,
					MethodName:       operationName,
					TimeoutInMinutes: 30,
				}
			}
			if strings.EqualFold(operation.Method, "GET") && operation.UriSuffix == nil && operation.ResponseObject != nil {
				if operation.UriSuffix == nil {
					getMethod = &resourcemanager.MethodDefinition{
						Generate:         true,
						MethodName:       operationName,
						TimeoutInMinutes: 5,
					}
				}

				if operation.FieldContainingPaginationDetails != nil {
					hasList = true
				}
			}
			if strings.EqualFold(operation.Method, "DELETE") && operation.UriSuffix == nil {
				deleteMethod = &resourcemanager.MethodDefinition{
					Generate:         true,
					MethodName:       operationName,
					TimeoutInMinutes: 30,
				}
			}
			// TODO: determine if we're concerned with these in the future (e.g. ListKeys etc)
			//if operation.UriSuffix != nil && !strings.EqualFold(operation.Method, "GET") {
			//	hasSuffixedMethods = true
			//}
		}

		// once we've been over all the methods, check if the Create method is actually CreateOrUpdate
		if updateMethod == nil && createMethod != nil {
			// handle CreateOrUpdate, but only when there's no Update method
			if strings.Contains(strings.ToLower(createMethod.MethodName), "update") {
				updateMethod = &resourcemanager.MethodDefinition{
					Generate:         true,
					MethodName:       createMethod.MethodName,
					TimeoutInMinutes: 30,
				}
			}
		}

		resourceLabel, resourceMetaData := findResourceName(resourceDefinitions, resourceId.Id)
		if resourceLabel == nil || resourceMetaData == nil {
			logger.Debug(fmt.Sprintf("Identified Resource %q but not defined - skipping", resourceId.Id))
			continue
		}

		if getMethod != nil || hasList {
			out.DataSources[resourceMetaData.Name] = resourcemanager.TerraformDataSourceDetails{
				// TODO: output Singular, Plural and the other stuff..
			}
		}
		if createMethod != nil && getMethod != nil && deleteMethod != nil {
			out.Resources[*resourceLabel] = resourcemanager.TerraformResourceDetails{
				CreateMethod:         *createMethod,
				DeleteMethod:         *deleteMethod,
				DisplayName:          resourceMetaData.Name,
				Generate:             true,
				GenerateSchema:       true,
				GenerateIdValidation: true,
				ReadMethod:           *getMethod,
				Resource:             apiResourceName,
				ResourceIdName:       resourceIdName,
				ResourceName:         strings.ReplaceAll(resourceMetaData.Name, " ", ""), // TODO: maybe more later
				UpdateMethod:         updateMethod,
			}
		}
	}
	// TODO: ignore discriminated types

	return out
}

func findResourceName(definitions map[string]definitions.ResourceDefinition, resourceId string) (*string, *definitions.ResourceDefinition) {
	for k, v := range definitions {
		if v.ID == resourceId {
			return &k, &v
		}
	}

	return nil, nil
}
