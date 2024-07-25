// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package generator

import (
	"fmt"
	"sort"
	"strings"

	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/helpers"
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

type readmeTemplater struct {
	sortedOperationNames []string
	operations           map[string]models.SDKOperation
}

func (r readmeTemplater) template(data GeneratorData) (*string, error) {
	summary := r.packageSummary(data)
	clientInit := r.clientInitialization(data.packageName, data.serviceClientName)
	examples, err := r.exampleUsages(data)
	if err != nil {
		return nil, fmt.Errorf("building examples: %+v", err)
	}
	out := strings.Join([]string{
		summary,
		clientInit,
		*examples,
	}, "\n")
	out = strings.ReplaceAll(out, "'", "`")
	return &out, nil
}

func (r readmeTemplater) packageSummary(data GeneratorData) string {
	importLines := []string{
		fmt.Sprintf(`import "github.com/hashicorp/go-azure-sdk/%[1]s/%[2]s/%[3]s/%[4]s"`, data.sourceType, data.servicePackageName, data.apiVersion, data.packageName),
	}
	containsCommonId := false
	for _, resourceId := range data.resourceIds {
		if resourceId.CommonIDAlias != nil {
			containsCommonId = true
			break
		}
	}
	if containsCommonId {
		importLines = append(importLines, `import "github.com/hashicorp/go-azure-helpers/resourcemanager/commonids"`)
	}
	sort.Strings(importLines)

	return fmt.Sprintf(`
## 'github.com/hashicorp/go-azure-sdk/%[1]s/%[2]s/%[3]s/%[4]s' Documentation

The '%[4]s' SDK allows for interaction with the Azure Resource Manager Service '%[2]s' (API Version '%[3]s').

This readme covers example usages, but further information on [using this SDK can be found in the project root](https://github.com/hashicorp/go-azure-sdk/tree/main/docs).

### Import Path

'''go
%[5]s
'''
`, data.sourceType, data.servicePackageName, data.apiVersion, data.packageName, strings.Join(importLines, "\n"))
}

func (r readmeTemplater) clientInitialization(packageName, clientName string) string {
	return fmt.Sprintf(`
### Client Initialization

'''go
client := %[1]s.New%[2]sWithBaseURI("https://management.azure.com")
client.Client.Authorizer = authorizer
'''
`, packageName, clientName)
}

func (r readmeTemplater) exampleUsages(data GeneratorData) (*string, error) {
	examples := make([]string, 0)

	for _, operationName := range r.sortedOperationNames {
		operation, ok := r.operations[operationName]
		if !ok {
			return nil, fmt.Errorf("operation %q was not found", operationName)
		}

		example, err := r.exampleUsageForOperation(data.packageName, data.serviceClientName, operationName, operation, data)
		if err != nil {
			return nil, fmt.Errorf("building example usage for operation %q: %+v", operationName, err)
		}

		examples = append(examples, *example)
	}

	out := strings.Join(examples, "\n")
	return &out, nil
}

func (r readmeTemplater) exampleUsageForOperation(packageName, clientName, operationName string, operation models.SDKOperation, data GeneratorData) (*string, error) {
	if operation.FieldContainingPaginationDetails != nil {
		return r.exampleUsageForListOperation(packageName, clientName, operationName, operation, data)
	}

	if operation.LongRunning {
		return r.exampleUsageForLongRunningOperation(packageName, clientName, operationName, operation, data)
	}

	return r.exampleUsageForRegularOperation(packageName, clientName, operationName, operation, data)
}

func (r readmeTemplater) resourceIdInitialization(operation models.SDKOperation, data GeneratorData) (*string, error) {
	resourceId, ok := data.resourceIds[*operation.ResourceIDName]
	if !ok {
		return nil, fmt.Errorf("resource id %q was not found", *operation.ResourceIDName)
	}

	resourceIdPackageName := data.packageName
	resourceIdTypeName := strings.TrimSuffix(*operation.ResourceIDName, "Id")
	if resourceId.CommonIDAlias != nil {
		resourceIdPackageName = "commonids"
		resourceIdTypeName = *resourceId.CommonIDAlias // NOTE: CommonIds aren't output with an `Id` suffix
	}

	components := make([]string, 0)
	for _, v := range resourceId.Segments {
		if v.Type == models.StaticResourceIDSegmentType || v.Type == models.ResourceProviderResourceIDSegmentType {
			continue
		}
		components = append(components, fmt.Sprintf("%q", v.ExampleValue))
	}
	out := fmt.Sprintf(`id := %[1]s.New%[2]sID(%[3]s)`, resourceIdPackageName, resourceIdTypeName, strings.Join(components, ", "))
	return &out, nil
}

func (r readmeTemplater) exampleUsageForRegularOperation(packageName, clientName, operationName string, operation models.SDKOperation, data GeneratorData) (*string, error) {
	lines := make([]string, 0)

	methodArgs := []string{
		"ctx",
	}
	if operation.ResourceIDName != nil {
		resourceId, err := r.resourceIdInitialization(operation, data)
		if err != nil {
			return nil, fmt.Errorf("building resource id initialization: %+v", err)
		}

		methodArgs = append(methodArgs, "id")
		lines = append(lines, *resourceId)
	}
	if operation.RequestObject != nil {
		methodArgs = append(methodArgs, "payload")
		if operation.RequestObject.Type == models.ReferenceSDKObjectDefinitionType {
			lines = append(lines, fmt.Sprintf(`
payload := %[1]s.%[2]s{
	// ...
}
`, packageName, *operation.RequestObject.ReferenceName))
		} else {
			// for simplicities sake
			typeName, err := helpers.GolangTypeForSDKObjectDefinition(*operation.RequestObject, nil, nil, nil)
			if err != nil {
				return nil, fmt.Errorf("determining golang type name for request object: %+v", err)
			}
			lines = append(lines, fmt.Sprintf("var payload %s", *typeName))
		}
	}
	if len(operation.Options) > 0 {
		methodArgs = append(methodArgs, fmt.Sprintf("%[1]s.Default%[2]sOperationOptions()", packageName, operationName))
	}

	out := fmt.Sprintf(`
### Example Usage: '%[1]s.%[2]s'

'''go
ctx := context.TODO()
%[3]s

read, err := client.%[2]s(%[4]s)
if err != nil {
	// handle the error
}
if model := read.Model; model != nil {
	// do something with the model/response object
}
'''
`, clientName, operationName, strings.Join(lines, "\n"), strings.Join(methodArgs, ", "))

	return &out, nil
}

func (r readmeTemplater) exampleUsageForListOperation(packageName, clientName, operationName string, operation models.SDKOperation, data GeneratorData) (*string, error) {
	lines := make([]string, 0)

	methodArgs := []string{
		"ctx",
	}
	if operation.ResourceIDName != nil {
		resourceId, err := r.resourceIdInitialization(operation, data)
		if err != nil {
			return nil, fmt.Errorf("building resource id initialization: %+v", err)
		}

		methodArgs = append(methodArgs, "id")
		lines = append(lines, *resourceId)
	}
	if operation.RequestObject != nil {
		methodArgs = append(methodArgs, "payload")
		if operation.RequestObject.Type == models.ReferenceSDKObjectDefinitionType {
			lines = append(lines, fmt.Sprintf(`
payload := %[1]s.%[2]s{
	// ...
}
`, packageName, *operation.RequestObject.ReferenceName))
		} else {
			// for simplicities sake
			typeName, err := helpers.GolangTypeForSDKObjectDefinition(*operation.RequestObject, nil, nil, nil)
			if err != nil {
				return nil, fmt.Errorf("determining golang type name for request object: %+v", err)
			}
			lines = append(lines, fmt.Sprintf("var payload %s", *typeName))
		}
	}
	if len(operation.Options) > 0 {
		methodArgs = append(methodArgs, fmt.Sprintf("%[1]s.Default%[2]sOperationOptions()", packageName, operationName))
	}

	out := fmt.Sprintf(`
### Example Usage: '%[1]s.%[2]s'

'''go
ctx := context.TODO()
%[3]s

// alternatively 'client.%[2]s(%[4]s)' can be used to do batched pagination
items, err := client.%[2]sComplete(%[4]s)
if err != nil {
	// handle the error
}
for _, item := range items {
	// do something
}
'''
`, clientName, operationName, strings.Join(lines, "\n"), strings.Join(methodArgs, ", "))

	return &out, nil
}

func (r readmeTemplater) exampleUsageForLongRunningOperation(packageName, clientName, operationName string, operation models.SDKOperation, data GeneratorData) (*string, error) {
	lines := make([]string, 0)

	methodArgs := []string{
		"ctx",
	}
	if operation.ResourceIDName != nil {
		resourceId, err := r.resourceIdInitialization(operation, data)
		if err != nil {
			return nil, fmt.Errorf("building resource id initialization: %+v", err)
		}

		methodArgs = append(methodArgs, "id")
		lines = append(lines, *resourceId)
	}
	if operation.RequestObject != nil {
		methodArgs = append(methodArgs, "payload")
		if operation.RequestObject.Type == models.ReferenceSDKObjectDefinitionType {
			lines = append(lines, fmt.Sprintf(`
payload := %[1]s.%[2]s{
	// ...
}
`, packageName, *operation.RequestObject.ReferenceName))
		} else {
			// for simplicities sake
			typeName, err := helpers.GolangTypeForSDKObjectDefinition(*operation.RequestObject, nil, nil, nil)
			if err != nil {
				return nil, fmt.Errorf("determining golang type name for request object: %+v", err)
			}
			lines = append(lines, fmt.Sprintf("var payload %s", *typeName))
		}
	}
	if len(operation.Options) > 0 {
		methodArgs = append(methodArgs, fmt.Sprintf("%[1]s.Default%[2]sOperationOptions()", packageName, operationName))
	}

	out := fmt.Sprintf(`
### Example Usage: '%[1]s.%[2]s'

'''go
ctx := context.TODO()
%[3]s

if err := client.%[2]sThenPoll(%[4]s); err != nil {
	// handle the error
}
'''
`, clientName, operationName, strings.Join(lines, "\n"), strings.Join(methodArgs, ", "))

	return &out, nil
}
