package generator

import (
	"fmt"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
	"strings"
)

type readmeTemplater struct {
	sortedOperationNames []string
	operations           map[string]resourcemanager.ApiOperation
}

func (r readmeTemplater) template(data ServiceGeneratorData) (*string, error) {
	summary := r.packageSummary(data.servicePackageName, data.apiVersion, data.packageName)
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

func (r readmeTemplater) packageSummary(serviceName, apiVersion, resourceName string) string {
	return fmt.Sprintf(`
## SDK: 'github.com/hashicorp/go-azure-sdk/resource-manager/%[1]s/%[2]s/%[3]s'

The '%[3]s' SDK allows for interaction with the Azure Resource Manager Service '%[1]s' (API Version '%[2]s').

This readme covers example usages, but further information on [using this SDK can be found in the project root](https://github.com/hashicorp/go-azure-sdk/tree/main/docs).
`, serviceName, apiVersion, resourceName)
}

func (r readmeTemplater) clientInitialization(packageName, clientName string) string {
	return fmt.Sprintf(`
## Client Initialization

'''go
client := %[1]s.New%[2]sClientWithBaseURI("https://management.azure.com")
client.Client.Authorizer = authorizer
if err != nil {
	// handle the error
}
'''
`, packageName, clientName)
}

func (r readmeTemplater) exampleUsages(data ServiceGeneratorData) (*string, error) {
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

func (r readmeTemplater) exampleUsageForOperation(packageName, clientName, operationName string, operation resourcemanager.ApiOperation, data ServiceGeneratorData) (*string, error) {
	if operation.FieldContainingPaginationDetails != nil {
		return r.exampleUsageForListOperation(packageName, clientName, operationName, operation, data)
	}

	if operation.LongRunning {
		return r.exampleUsageForLongRunningOperation(packageName, clientName, operationName, operation, data)
	}

	return r.exampleUsageForRegularOperation(packageName, clientName, operationName, operation, data)
}

func (r readmeTemplater) resourceIdInitialization(operation resourcemanager.ApiOperation, data ServiceGeneratorData) (*string, error) {
	resourceId, ok := data.resourceIds[*operation.ResourceIdName]
	if !ok {
		return nil, fmt.Errorf("resource id %q was not found", *operation.ResourceIdName)
	}

	components := make([]string, 0)
	for _, v := range resourceId.Segments {
		if v.Type == resourcemanager.StaticSegment {
			continue
		}
		components = append(components, fmt.Sprintf("%q", v.ExampleValue))
	}
	out := fmt.Sprintf(`id := %[1]s.New%[2]sID(%[3]s)`, data.packageName, *operation.ResourceIdName, strings.Join(components, ", "))
	return &out, nil
}

func (r readmeTemplater) exampleUsageForRegularOperation(packageName, clientName, operationName string, operation resourcemanager.ApiOperation, data ServiceGeneratorData) (*string, error) {
	lines := make([]string, 0)

	methodArgs := []string{
		"ctx",
	}
	if operation.ResourceIdName != nil {
		resourceId, err := r.resourceIdInitialization(operation, data)
		if err != nil {
			return nil, fmt.Errorf("building resource id initialization: %+v", err)
		}

		methodArgs = append(methodArgs, "id")
		lines = append(lines, *resourceId)
	}
	if operation.RequestObject != nil {
		methodArgs = append(methodArgs, "payload")
		if operation.RequestObject.Type == resourcemanager.ReferenceApiObjectDefinitionType {
			lines = append(lines, fmt.Sprintf(`
payload := %[1]s.%[2]s{
	// ...
}
`, packageName, *operation.RequestObject.ReferenceName))
		} else {
			// for simplicities sake
			typeName, err := golangTypeNameForObjectDefinition(*operation.RequestObject)
			if err != nil {
				return nil, fmt.Errorf("determining golang type name for request object: %+v", err)
			}
			lines = append(lines, fmt.Sprintf("var payload %s", *typeName))
		}
	}
	if operation.Options != nil {
		methodArgs = append(methodArgs, fmt.Sprintf("%[1]s.Default%[2]sOperationOptions()", packageName, operationName))
	}

	out := fmt.Sprintf(`
### Example Usage: '%[1]sClient.%[2]s'

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

func (r readmeTemplater) exampleUsageForListOperation(packageName, clientName, operationName string, operation resourcemanager.ApiOperation, data ServiceGeneratorData) (*string, error) {
	lines := make([]string, 0)

	methodArgs := []string{
		"ctx",
	}
	if operation.ResourceIdName != nil {
		resourceId, err := r.resourceIdInitialization(operation, data)
		if err != nil {
			return nil, fmt.Errorf("building resource id initialization: %+v", err)
		}

		methodArgs = append(methodArgs, "id")
		lines = append(lines, *resourceId)
	}
	if operation.RequestObject != nil {
		methodArgs = append(methodArgs, "payload")
		if operation.RequestObject.Type == resourcemanager.ReferenceApiObjectDefinitionType {
			lines = append(lines, fmt.Sprintf(`
payload := %[1]s.%[2]s{
	// ...
}
`, packageName, *operation.RequestObject.ReferenceName))
		} else {
			// for simplicities sake
			typeName, err := golangTypeNameForObjectDefinition(*operation.RequestObject)
			if err != nil {
				return nil, fmt.Errorf("determining golang type name for request object: %+v", err)
			}
			lines = append(lines, fmt.Sprintf("var payload %s", *typeName))
		}
	}
	if operation.Options != nil {
		methodArgs = append(methodArgs, fmt.Sprintf("%[1]s.Default%[2]sOperationOptions()", packageName, operationName))
	}

	out := fmt.Sprintf(`
### Example Usage: '%[1]sClient.%[2]s'

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

func (r readmeTemplater) exampleUsageForLongRunningOperation(packageName, clientName, operationName string, operation resourcemanager.ApiOperation, data ServiceGeneratorData) (*string, error) {
	lines := make([]string, 0)

	methodArgs := []string{
		"ctx",
	}
	if operation.ResourceIdName != nil {
		resourceId, err := r.resourceIdInitialization(operation, data)
		if err != nil {
			return nil, fmt.Errorf("building resource id initialization: %+v", err)
		}

		methodArgs = append(methodArgs, "id")
		lines = append(lines, *resourceId)
	}
	if operation.RequestObject != nil {
		methodArgs = append(methodArgs, "payload")
		if operation.RequestObject.Type == resourcemanager.ReferenceApiObjectDefinitionType {
			lines = append(lines, fmt.Sprintf(`
payload := %[1]s.%[2]s{
	// ...
}
`, packageName, *operation.RequestObject.ReferenceName))
		} else {
			// for simplicities sake
			typeName, err := golangTypeNameForObjectDefinition(*operation.RequestObject)
			if err != nil {
				return nil, fmt.Errorf("determining golang type name for request object: %+v", err)
			}
			lines = append(lines, fmt.Sprintf("var payload %s", *typeName))
		}
	}
	if operation.Options != nil {
		methodArgs = append(methodArgs, fmt.Sprintf("%[1]s.Default%[2]sOperationOptions()", packageName, operationName))
	}

	out := fmt.Sprintf(`
### Example Usage: '%[1]sClient.%[2]s'

'''go
ctx := context.TODO()
%[3]s
future, err := client.%[2]s(%[4]s)
if err != nil {
	// handle the error
}
if err := future.Poller.PollUntilDone(); err != nil {
	// handle the error
}
'''
`, clientName, operationName, strings.Join(lines, "\n"), strings.Join(methodArgs, ", "))

	return &out, nil
}

/*
## SDK: `github.com/hashicorp/go-azure-sdk/resource-manager/{service}/{apiVersion}/{resource}`

The `%q` SDK allows for interaction with the Azure Resource Manager Service `%q` (API Version `%q`).

This readme covers example usages, but further information on [using this SDK can be found in the project root](https://github.com/hashicorp/go-azure-sdk/tree/main/docs).

## Client Initialization

```go
client := signalr.NewSignalRClientWithBaseURI("https://management.azure.com")
client.Client.Authorizer = authorizer
if err != nil {
	// handle the error
}
```

### Example Usage: 'SomeClient.Blah'

```go
future, err := client.Name(ctx, someId)
if err != nil {
	// handle the error
}
if err := future.WaitForState(); err != nil {
	// handle the error
}
```

*/
