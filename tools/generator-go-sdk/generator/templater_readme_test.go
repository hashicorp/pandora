package generator

import (
	"strings"
	"testing"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func TestReadmeTemplater_NoOperations(t *testing.T) {
	// whilst not strictly a real-world example, specifically tests the basics
	expected := strings.ReplaceAll(`
## 'github.com/hashicorp/go-azure-sdk/resource-manager/compute/2022-02-01/disks' Documentation

The 'disks' SDK allows for interaction with the Azure Resource Manager Service 'compute' (API Version '2022-02-01').

This readme covers example usages, but further information on [using this SDK can be found in the project root](https://github.com/hashicorp/go-azure-sdk/tree/main/docs).

### Import Path

'''go
import "github.com/hashicorp/go-azure-sdk/resource-manager/compute/2022-02-01/disks"
'''

### Client Initialization

'''go
client := disks.NewDisksClientWithBaseURI("https://management.azure.com")
client.Client.Authorizer = authorizer
'''
`, "'", "`")
	actual, err := readmeTemplater{
		sortedOperationNames: []string{},
		operations:           map[string]resourcemanager.ApiOperation{},
	}.template(ServiceGeneratorData{
		packageName:        "disks",
		apiVersion:         "2022-02-01",
		servicePackageName: "compute",
		serviceClientName:  "DisksClient",
	})
	if err != nil {
		t.Fatalf("generating readme: %+v", err)
	}
	assertTemplatedCodeMatches(t, expected, *actual)
}

func TestReadmeTemplater_GetOperationWithResourceID(t *testing.T) {
	expected := strings.ReplaceAll(`
## 'github.com/hashicorp/go-azure-sdk/resource-manager/compute/2022-02-01/disks' Documentation

The 'disks' SDK allows for interaction with the Azure Resource Manager Service 'compute' (API Version '2022-02-01').

This readme covers example usages, but further information on [using this SDK can be found in the project root](https://github.com/hashicorp/go-azure-sdk/tree/main/docs).

### Import Path

'''go
import "github.com/hashicorp/go-azure-sdk/resource-manager/compute/2022-02-01/disks"
'''

### Client Initialization

'''go
client := disks.NewDisksClientWithBaseURI("https://management.azure.com")
client.Client.Authorizer = authorizer
'''

### Example Usage: 'DisksClient.Get'

'''go
ctx := context.TODO()
id := disks.NewDiskID("my-disk")
read, err := client.Get(ctx, id)
if err != nil {
	// handle the error
}
if model := read.Model; model != nil {
	// do something with the model/response object
}
'''
`, "'", "`")
	actual, err := readmeTemplater{
		sortedOperationNames: []string{
			"Get",
		},
		operations: map[string]resourcemanager.ApiOperation{
			"Get": {
				LongRunning:    false,
				ResourceIdName: stringPointer("Disk"),
			},
		},
	}.template(ServiceGeneratorData{
		packageName:        "disks",
		apiVersion:         "2022-02-01",
		servicePackageName: "compute",
		serviceClientName:  "DisksClient",
		resourceIds: map[string]resourcemanager.ResourceIdDefinition{
			"Disk": {
				Segments: []resourcemanager.ResourceIdSegment{
					{
						Type:       resourcemanager.StaticSegment,
						Name:       "disks",
						FixedValue: stringPointer("disks"),
					},
					{
						Type:         resourcemanager.UserSpecifiedSegment,
						Name:         "diskName",
						ExampleValue: "my-disk",
					},
				},
			},
		},
	})
	if err != nil {
		t.Fatalf("generating readme: %+v", err)
	}
	assertTemplatedCodeMatches(t, expected, *actual)
}

func TestReadmeTemplater_GetOperationWithResourceIDAndPayload(t *testing.T) {
	expected := strings.ReplaceAll(`
## 'github.com/hashicorp/go-azure-sdk/resource-manager/compute/2022-02-01/disks' Documentation

The 'disks' SDK allows for interaction with the Azure Resource Manager Service 'compute' (API Version '2022-02-01').

This readme covers example usages, but further information on [using this SDK can be found in the project root](https://github.com/hashicorp/go-azure-sdk/tree/main/docs).

### Import Path

'''go
import "github.com/hashicorp/go-azure-sdk/resource-manager/compute/2022-02-01/disks"
'''

### Client Initialization

'''go
client := disks.NewDisksClientWithBaseURI("https://management.azure.com")
client.Client.Authorizer = authorizer
'''

### Example Usage: 'DisksClient.Get'

'''go
ctx := context.TODO()
id := disks.NewDiskID("my-disk")
payload := disks.SomeModel{
	// ...
}
read, err := client.Get(ctx, id, payload)
if err != nil {
	// handle the error
}
if model := read.Model; model != nil {
	// do something with the model/response object
}
'''
`, "'", "`")
	actual, err := readmeTemplater{
		sortedOperationNames: []string{
			"Get",
		},
		operations: map[string]resourcemanager.ApiOperation{
			"Get": {
				LongRunning:    false,
				ResourceIdName: stringPointer("Disk"),
				RequestObject: &resourcemanager.ApiObjectDefinition{
					Type:          resourcemanager.ReferenceApiObjectDefinitionType,
					ReferenceName: stringPointer("SomeModel"),
				},
			},
		},
	}.template(ServiceGeneratorData{
		packageName:        "disks",
		apiVersion:         "2022-02-01",
		servicePackageName: "compute",
		serviceClientName:  "DisksClient",
		resourceIds: map[string]resourcemanager.ResourceIdDefinition{
			"Disk": {
				Segments: []resourcemanager.ResourceIdSegment{
					{
						Type:       resourcemanager.StaticSegment,
						Name:       "disks",
						FixedValue: stringPointer("disks"),
					},
					{
						Type:         resourcemanager.UserSpecifiedSegment,
						Name:         "diskName",
						ExampleValue: "my-disk",
					},
				},
			},
		},
		models: map[string]resourcemanager.ModelDetails{
			"SomeModel": {
				Fields: map[string]resourcemanager.FieldDetails{
					// doesn't matter for this test
				},
			},
		},
	})
	if err != nil {
		t.Fatalf("generating readme: %+v", err)
	}
	assertTemplatedCodeMatches(t, expected, *actual)
}

func TestReadmeTemplater_GetOperationWithResourceIDAndPayloadAndOptions(t *testing.T) {
	expected := strings.ReplaceAll(`
## 'github.com/hashicorp/go-azure-sdk/resource-manager/compute/2022-02-01/disks' Documentation

The 'disks' SDK allows for interaction with the Azure Resource Manager Service 'compute' (API Version '2022-02-01').

This readme covers example usages, but further information on [using this SDK can be found in the project root](https://github.com/hashicorp/go-azure-sdk/tree/main/docs).

### Import Path

'''go
import "github.com/hashicorp/go-azure-sdk/resource-manager/compute/2022-02-01/disks"
'''

### Client Initialization

'''go
client := disks.NewDisksClientWithBaseURI("https://management.azure.com")
client.Client.Authorizer = authorizer
'''

### Example Usage: 'DisksClient.Get'

'''go
ctx := context.TODO()
id := disks.NewDiskID("my-disk")
payload := disks.SomeModel{
	// ...
}
read, err := client.Get(ctx, id, payload, disks.DefaultGetOperationOptions())
if err != nil {
	// handle the error
}
if model := read.Model; model != nil {
	// do something with the model/response object
}
'''
`, "'", "`")
	actual, err := readmeTemplater{
		sortedOperationNames: []string{
			"Get",
		},
		operations: map[string]resourcemanager.ApiOperation{
			"Get": {
				LongRunning:    false,
				ResourceIdName: stringPointer("Disk"),
				RequestObject: &resourcemanager.ApiObjectDefinition{
					Type:          resourcemanager.ReferenceApiObjectDefinitionType,
					ReferenceName: stringPointer("SomeModel"),
				},
				Options: map[string]resourcemanager.ApiOperationOption{
					"Example": {
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.StringApiObjectDefinitionType,
						},
						Required: false,
					},
				},
			},
		},
	}.template(ServiceGeneratorData{
		packageName:        "disks",
		apiVersion:         "2022-02-01",
		servicePackageName: "compute",
		serviceClientName:  "DisksClient",
		resourceIds: map[string]resourcemanager.ResourceIdDefinition{
			"Disk": {
				Segments: []resourcemanager.ResourceIdSegment{
					{
						Type:       resourcemanager.StaticSegment,
						Name:       "disks",
						FixedValue: stringPointer("disks"),
					},
					{
						Type:         resourcemanager.UserSpecifiedSegment,
						Name:         "diskName",
						ExampleValue: "my-disk",
					},
				},
			},
		},
		models: map[string]resourcemanager.ModelDetails{
			"SomeModel": {
				Fields: map[string]resourcemanager.FieldDetails{
					// doesn't matter for this test
				},
			},
		},
	})
	if err != nil {
		t.Fatalf("generating readme: %+v", err)
	}
	assertTemplatedCodeMatches(t, expected, *actual)
}

func TestReadmeTemplater_GetOperationWithResourceIDAndOptions(t *testing.T) {
	expected := strings.ReplaceAll(`
## 'github.com/hashicorp/go-azure-sdk/resource-manager/compute/2022-02-01/disks' Documentation

The 'disks' SDK allows for interaction with the Azure Resource Manager Service 'compute' (API Version '2022-02-01').

This readme covers example usages, but further information on [using this SDK can be found in the project root](https://github.com/hashicorp/go-azure-sdk/tree/main/docs).

### Import Path

'''go
import "github.com/hashicorp/go-azure-sdk/resource-manager/compute/2022-02-01/disks"
'''

### Client Initialization

'''go
client := disks.NewDisksClientWithBaseURI("https://management.azure.com")
client.Client.Authorizer = authorizer
'''

### Example Usage: 'DisksClient.Get'

'''go
ctx := context.TODO()
id := disks.NewDiskID("my-disk")
read, err := client.Get(ctx, id, disks.DefaultGetOperationOptions())
if err != nil {
	// handle the error
}
if model := read.Model; model != nil {
	// do something with the model/response object
}
'''
`, "'", "`")
	actual, err := readmeTemplater{
		sortedOperationNames: []string{
			"Get",
		},
		operations: map[string]resourcemanager.ApiOperation{
			"Get": {
				LongRunning:    false,
				ResourceIdName: stringPointer("Disk"),
				Options: map[string]resourcemanager.ApiOperationOption{
					"Example": {
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.StringApiObjectDefinitionType,
						},
						Required: false,
					},
				},
			},
		},
	}.template(ServiceGeneratorData{
		packageName:        "disks",
		apiVersion:         "2022-02-01",
		servicePackageName: "compute",
		serviceClientName:  "DisksClient",
		resourceIds: map[string]resourcemanager.ResourceIdDefinition{
			"Disk": {
				Segments: []resourcemanager.ResourceIdSegment{
					{
						Type:       resourcemanager.StaticSegment,
						Name:       "disks",
						FixedValue: stringPointer("disks"),
					},
					{
						Type:         resourcemanager.UserSpecifiedSegment,
						Name:         "diskName",
						ExampleValue: "my-disk",
					},
				},
			},
		},
	})
	if err != nil {
		t.Fatalf("generating readme: %+v", err)
	}
	assertTemplatedCodeMatches(t, expected, *actual)
}

func TestReadmeTemplater_GetOperationWithoutResourceID(t *testing.T) {
	expected := strings.ReplaceAll(`
## 'github.com/hashicorp/go-azure-sdk/resource-manager/compute/2022-02-01/disks' Documentation

The 'disks' SDK allows for interaction with the Azure Resource Manager Service 'compute' (API Version '2022-02-01').

This readme covers example usages, but further information on [using this SDK can be found in the project root](https://github.com/hashicorp/go-azure-sdk/tree/main/docs).

### Import Path

'''go
import "github.com/hashicorp/go-azure-sdk/resource-manager/compute/2022-02-01/disks"
'''

### Client Initialization

'''go
client := disks.NewDisksClientWithBaseURI("https://management.azure.com")
client.Client.Authorizer = authorizer
'''

### Example Usage: 'DisksClient.Get'

'''go
ctx := context.TODO()
read, err := client.Get(ctx)
if err != nil {
	// handle the error
}
if model := read.Model; model != nil {
	// do something with the model/response object
}
'''
`, "'", "`")
	actual, err := readmeTemplater{
		sortedOperationNames: []string{
			"Get",
		},
		operations: map[string]resourcemanager.ApiOperation{
			"Get": {
				LongRunning:    false,
				ResourceIdName: nil,
			},
		},
	}.template(ServiceGeneratorData{
		packageName:        "disks",
		apiVersion:         "2022-02-01",
		servicePackageName: "compute",
		serviceClientName:  "DisksClient",
		resourceIds:        map[string]resourcemanager.ResourceIdDefinition{},
	})
	if err != nil {
		t.Fatalf("generating readme: %+v", err)
	}
	assertTemplatedCodeMatches(t, expected, *actual)
}

func TestReadmeTemplater_GetOperationWithoutResourceIDWithOptions(t *testing.T) {
	expected := strings.ReplaceAll(`
## 'github.com/hashicorp/go-azure-sdk/resource-manager/compute/2022-02-01/disks' Documentation

The 'disks' SDK allows for interaction with the Azure Resource Manager Service 'compute' (API Version '2022-02-01').

This readme covers example usages, but further information on [using this SDK can be found in the project root](https://github.com/hashicorp/go-azure-sdk/tree/main/docs).

### Import Path

'''go
import "github.com/hashicorp/go-azure-sdk/resource-manager/compute/2022-02-01/disks"
'''

### Client Initialization

'''go
client := disks.NewDisksClientWithBaseURI("https://management.azure.com")
client.Client.Authorizer = authorizer
'''

### Example Usage: 'DisksClient.Get'

'''go
ctx := context.TODO()
read, err := client.Get(ctx, disks.DefaultGetOperationOptions())
if err != nil {
	// handle the error
}
if model := read.Model; model != nil {
	// do something with the model/response object
}
'''
`, "'", "`")
	actual, err := readmeTemplater{
		sortedOperationNames: []string{
			"Get",
		},
		operations: map[string]resourcemanager.ApiOperation{
			"Get": {
				LongRunning:    false,
				ResourceIdName: nil,
				Options: map[string]resourcemanager.ApiOperationOption{
					"Example": {
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.StringApiObjectDefinitionType,
						},
						Required: false,
					},
				},
			},
		},
	}.template(ServiceGeneratorData{
		packageName:        "disks",
		apiVersion:         "2022-02-01",
		servicePackageName: "compute",
		serviceClientName:  "DisksClient",
		resourceIds:        map[string]resourcemanager.ResourceIdDefinition{},
	})
	if err != nil {
		t.Fatalf("generating readme: %+v", err)
	}
	assertTemplatedCodeMatches(t, expected, *actual)
}

func TestReadmeTemplater_ListOperationWithResourceID(t *testing.T) {
	expected := strings.ReplaceAll(`
## 'github.com/hashicorp/go-azure-sdk/resource-manager/compute/2022-02-01/disks' Documentation

The 'disks' SDK allows for interaction with the Azure Resource Manager Service 'compute' (API Version '2022-02-01').

This readme covers example usages, but further information on [using this SDK can be found in the project root](https://github.com/hashicorp/go-azure-sdk/tree/main/docs).

### Import Path

'''go
import "github.com/hashicorp/go-azure-sdk/resource-manager/compute/2022-02-01/disks"
'''

### Client Initialization

'''go
client := disks.NewDisksClientWithBaseURI("https://management.azure.com")
client.Client.Authorizer = authorizer
'''

### Example Usage: 'DisksClient.ListSomething'

'''go
ctx := context.TODO()
id := disks.NewDiskID("my-disk")
// alternatively 'client.ListSomething(ctx, id)' can be used to do batched pagination
items, err := client.ListSomethingComplete(ctx, id)
if err != nil {
	// handle the error
}
for _, item := range items {
	// do something
}
'''
`, "'", "`")
	actual, err := readmeTemplater{
		sortedOperationNames: []string{
			"ListSomething",
		},
		operations: map[string]resourcemanager.ApiOperation{
			"ListSomething": {
				LongRunning:                      false,
				ResourceIdName:                   stringPointer("Disk"),
				FieldContainingPaginationDetails: stringPointer("SomeField"),
			},
		},
	}.template(ServiceGeneratorData{
		packageName:        "disks",
		apiVersion:         "2022-02-01",
		servicePackageName: "compute",
		serviceClientName:  "DisksClient",
		resourceIds: map[string]resourcemanager.ResourceIdDefinition{
			"Disk": {
				Segments: []resourcemanager.ResourceIdSegment{
					{
						Type:       resourcemanager.StaticSegment,
						Name:       "disks",
						FixedValue: stringPointer("disks"),
					},
					{
						Type:         resourcemanager.UserSpecifiedSegment,
						Name:         "diskName",
						ExampleValue: "my-disk",
					},
				},
			},
		},
	})
	if err != nil {
		t.Fatalf("generating readme: %+v", err)
	}
	assertTemplatedCodeMatches(t, expected, *actual)
}

func TestReadmeTemplater_ListOperationWithResourceIDAndPayload(t *testing.T) {
	expected := strings.ReplaceAll(`
## 'github.com/hashicorp/go-azure-sdk/resource-manager/compute/2022-02-01/disks' Documentation

The 'disks' SDK allows for interaction with the Azure Resource Manager Service 'compute' (API Version '2022-02-01').

This readme covers example usages, but further information on [using this SDK can be found in the project root](https://github.com/hashicorp/go-azure-sdk/tree/main/docs).

### Import Path

'''go
import "github.com/hashicorp/go-azure-sdk/resource-manager/compute/2022-02-01/disks"
'''

### Client Initialization

'''go
client := disks.NewDisksClientWithBaseURI("https://management.azure.com")
client.Client.Authorizer = authorizer
'''

### Example Usage: 'DisksClient.ListSomething'

'''go
ctx := context.TODO()
id := disks.NewDiskID("my-disk")
payload := disks.SomeModel{
	// ...
}
// alternatively 'client.ListSomething(ctx, id, payload)' can be used to do batched pagination
items, err := client.ListSomethingComplete(ctx, id, payload)
if err != nil {
	// handle the error
}
for _, item := range items {
	// do something
}
'''
`, "'", "`")
	actual, err := readmeTemplater{
		sortedOperationNames: []string{
			"ListSomething",
		},
		operations: map[string]resourcemanager.ApiOperation{
			"ListSomething": {
				LongRunning:    false,
				ResourceIdName: stringPointer("Disk"),
				RequestObject: &resourcemanager.ApiObjectDefinition{
					Type:          resourcemanager.ReferenceApiObjectDefinitionType,
					ReferenceName: stringPointer("SomeModel"),
				},
				FieldContainingPaginationDetails: stringPointer("SomeField"),
			},
		},
	}.template(ServiceGeneratorData{
		packageName:        "disks",
		apiVersion:         "2022-02-01",
		servicePackageName: "compute",
		serviceClientName:  "DisksClient",
		resourceIds: map[string]resourcemanager.ResourceIdDefinition{
			"Disk": {
				Segments: []resourcemanager.ResourceIdSegment{
					{
						Type:       resourcemanager.StaticSegment,
						Name:       "disks",
						FixedValue: stringPointer("disks"),
					},
					{
						Type:         resourcemanager.UserSpecifiedSegment,
						Name:         "diskName",
						ExampleValue: "my-disk",
					},
				},
			},
		},
		models: map[string]resourcemanager.ModelDetails{
			"SomeModel": {
				Fields: map[string]resourcemanager.FieldDetails{
					// doesn't matter for this test
				},
			},
		},
	})
	if err != nil {
		t.Fatalf("generating readme: %+v", err)
	}
	assertTemplatedCodeMatches(t, expected, *actual)
}

func TestReadmeTemplater_ListOperationWithResourceIDAndPayloadAndOptions(t *testing.T) {
	expected := strings.ReplaceAll(`
## 'github.com/hashicorp/go-azure-sdk/resource-manager/compute/2022-02-01/disks' Documentation

The 'disks' SDK allows for interaction with the Azure Resource Manager Service 'compute' (API Version '2022-02-01').

This readme covers example usages, but further information on [using this SDK can be found in the project root](https://github.com/hashicorp/go-azure-sdk/tree/main/docs).

### Import Path

'''go
import "github.com/hashicorp/go-azure-sdk/resource-manager/compute/2022-02-01/disks"
'''

### Client Initialization

'''go
client := disks.NewDisksClientWithBaseURI("https://management.azure.com")
client.Client.Authorizer = authorizer
'''

### Example Usage: 'DisksClient.ListSomething'

'''go
ctx := context.TODO()
id := disks.NewDiskID("my-disk")
payload := disks.SomeModel{
	// ...
}
// alternatively 'client.ListSomething(ctx, id, payload, disks.DefaultListSomethingOperationOptions())' can be used to do batched pagination
items, err := client.ListSomethingComplete(ctx, id, payload, disks.DefaultListSomethingOperationOptions())
if err != nil {
	// handle the error
}
for _, item := range items {
	// do something
}
'''
`, "'", "`")
	actual, err := readmeTemplater{
		sortedOperationNames: []string{
			"ListSomething",
		},
		operations: map[string]resourcemanager.ApiOperation{
			"ListSomething": {
				LongRunning:    false,
				ResourceIdName: stringPointer("Disk"),
				RequestObject: &resourcemanager.ApiObjectDefinition{
					Type:          resourcemanager.ReferenceApiObjectDefinitionType,
					ReferenceName: stringPointer("SomeModel"),
				},
				Options: map[string]resourcemanager.ApiOperationOption{
					"Example": {
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.StringApiObjectDefinitionType,
						},
						Required: false,
					},
				},
				FieldContainingPaginationDetails: stringPointer("SomeField"),
			},
		},
	}.template(ServiceGeneratorData{
		packageName:        "disks",
		apiVersion:         "2022-02-01",
		servicePackageName: "compute",
		serviceClientName:  "DisksClient",
		resourceIds: map[string]resourcemanager.ResourceIdDefinition{
			"Disk": {
				Segments: []resourcemanager.ResourceIdSegment{
					{
						Type:       resourcemanager.StaticSegment,
						Name:       "disks",
						FixedValue: stringPointer("disks"),
					},
					{
						Type:         resourcemanager.UserSpecifiedSegment,
						Name:         "diskName",
						ExampleValue: "my-disk",
					},
				},
			},
		},
		models: map[string]resourcemanager.ModelDetails{
			"SomeModel": {
				Fields: map[string]resourcemanager.FieldDetails{
					// doesn't matter for this test
				},
			},
		},
	})
	if err != nil {
		t.Fatalf("generating readme: %+v", err)
	}
	assertTemplatedCodeMatches(t, expected, *actual)
}

func TestReadmeTemplater_ListOperationWithResourceIDAndOptions(t *testing.T) {
	expected := strings.ReplaceAll(`
## 'github.com/hashicorp/go-azure-sdk/resource-manager/compute/2022-02-01/disks' Documentation

The 'disks' SDK allows for interaction with the Azure Resource Manager Service 'compute' (API Version '2022-02-01').

This readme covers example usages, but further information on [using this SDK can be found in the project root](https://github.com/hashicorp/go-azure-sdk/tree/main/docs).

### Import Path

'''go
import "github.com/hashicorp/go-azure-sdk/resource-manager/compute/2022-02-01/disks"
'''

### Client Initialization

'''go
client := disks.NewDisksClientWithBaseURI("https://management.azure.com")
client.Client.Authorizer = authorizer
'''

### Example Usage: 'DisksClient.ListSomething'

'''go
ctx := context.TODO()
id := disks.NewDiskID("my-disk")
// alternatively 'client.ListSomething(ctx, id, disks.DefaultListSomethingOperationOptions())' can be used to do batched pagination
items, err := client.ListSomethingComplete(ctx, id, disks.DefaultListSomethingOperationOptions())
if err != nil {
	// handle the error
}
for _, item := range items {
	// do something
}
'''
`, "'", "`")
	actual, err := readmeTemplater{
		sortedOperationNames: []string{
			"ListSomething",
		},
		operations: map[string]resourcemanager.ApiOperation{
			"ListSomething": {
				LongRunning:    false,
				ResourceIdName: stringPointer("Disk"),
				Options: map[string]resourcemanager.ApiOperationOption{
					"Example": {
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.StringApiObjectDefinitionType,
						},
						Required: false,
					},
				},
				FieldContainingPaginationDetails: stringPointer("SomeField"),
			},
		},
	}.template(ServiceGeneratorData{
		packageName:        "disks",
		apiVersion:         "2022-02-01",
		servicePackageName: "compute",
		serviceClientName:  "DisksClient",
		resourceIds: map[string]resourcemanager.ResourceIdDefinition{
			"Disk": {
				Segments: []resourcemanager.ResourceIdSegment{
					{
						Type:       resourcemanager.StaticSegment,
						Name:       "disks",
						FixedValue: stringPointer("disks"),
					},
					{
						Type:         resourcemanager.UserSpecifiedSegment,
						Name:         "diskName",
						ExampleValue: "my-disk",
					},
				},
			},
		},
		models: map[string]resourcemanager.ModelDetails{
			"SomeModel": {
				Fields: map[string]resourcemanager.FieldDetails{
					// doesn't matter for this test
				},
			},
		},
	})
	if err != nil {
		t.Fatalf("generating readme: %+v", err)
	}
	assertTemplatedCodeMatches(t, expected, *actual)
}

func TestReadmeTemplater_ListOperationWithoutResourceID(t *testing.T) {
	expected := strings.ReplaceAll(`
## 'github.com/hashicorp/go-azure-sdk/resource-manager/compute/2022-02-01/disks' Documentation

The 'disks' SDK allows for interaction with the Azure Resource Manager Service 'compute' (API Version '2022-02-01').

This readme covers example usages, but further information on [using this SDK can be found in the project root](https://github.com/hashicorp/go-azure-sdk/tree/main/docs).

### Import Path

'''go
import "github.com/hashicorp/go-azure-sdk/resource-manager/compute/2022-02-01/disks"
'''

### Client Initialization

'''go
client := disks.NewDisksClientWithBaseURI("https://management.azure.com")
client.Client.Authorizer = authorizer
'''

### Example Usage: 'DisksClient.ListSomething'

'''go
ctx := context.TODO()
// alternatively 'client.ListSomething(ctx)' can be used to do batched pagination
items, err := client.ListSomethingComplete(ctx)
if err != nil {
	// handle the error
}
for _, item := range items {
	// do something
}
'''
`, "'", "`")
	actual, err := readmeTemplater{
		sortedOperationNames: []string{
			"ListSomething",
		},
		operations: map[string]resourcemanager.ApiOperation{
			"ListSomething": {
				LongRunning:                      false,
				ResourceIdName:                   nil,
				FieldContainingPaginationDetails: stringPointer("SomeField"),
			},
		},
	}.template(ServiceGeneratorData{
		packageName:        "disks",
		apiVersion:         "2022-02-01",
		servicePackageName: "compute",
		serviceClientName:  "DisksClient",
		resourceIds:        map[string]resourcemanager.ResourceIdDefinition{},
	})
	if err != nil {
		t.Fatalf("generating readme: %+v", err)
	}
	assertTemplatedCodeMatches(t, expected, *actual)
}

func TestReadmeTemplater_LongRunningOperationWithResourceID(t *testing.T) {
	expected := strings.ReplaceAll(`
## 'github.com/hashicorp/go-azure-sdk/resource-manager/compute/2022-02-01/disks' Documentation

The 'disks' SDK allows for interaction with the Azure Resource Manager Service 'compute' (API Version '2022-02-01').

This readme covers example usages, but further information on [using this SDK can be found in the project root](https://github.com/hashicorp/go-azure-sdk/tree/main/docs).

### Import Path

'''go
import "github.com/hashicorp/go-azure-sdk/resource-manager/compute/2022-02-01/disks"
'''

### Client Initialization

'''go
client := disks.NewDisksClientWithBaseURI("https://management.azure.com")
client.Client.Authorizer = authorizer
'''

### Example Usage: 'DisksClient.SomeLongRunning'

'''go
ctx := context.TODO()
id := disks.NewDiskID("my-disk")

if err := client.SomeLongRunningThenPoll(ctx, id); err != nil {
	// handle the error
}
'''
`, "'", "`")
	actual, err := readmeTemplater{
		sortedOperationNames: []string{
			"SomeLongRunning",
		},
		operations: map[string]resourcemanager.ApiOperation{
			"SomeLongRunning": {
				LongRunning:    true,
				ResourceIdName: stringPointer("Disk"),
			},
		},
	}.template(ServiceGeneratorData{
		packageName:        "disks",
		apiVersion:         "2022-02-01",
		servicePackageName: "compute",
		serviceClientName:  "DisksClient",
		resourceIds: map[string]resourcemanager.ResourceIdDefinition{
			"Disk": {
				Segments: []resourcemanager.ResourceIdSegment{
					{
						Type:       resourcemanager.StaticSegment,
						Name:       "disks",
						FixedValue: stringPointer("disks"),
					},
					{
						Type:         resourcemanager.UserSpecifiedSegment,
						Name:         "diskName",
						ExampleValue: "my-disk",
					},
				},
			},
		},
	})
	if err != nil {
		t.Fatalf("generating readme: %+v", err)
	}
	assertTemplatedCodeMatches(t, expected, *actual)
}

func TestReadmeTemplater_LongRunningOperationWithResourceIDAndPayload(t *testing.T) {
	expected := strings.ReplaceAll(`
## 'github.com/hashicorp/go-azure-sdk/resource-manager/compute/2022-02-01/disks' Documentation

The 'disks' SDK allows for interaction with the Azure Resource Manager Service 'compute' (API Version '2022-02-01').

This readme covers example usages, but further information on [using this SDK can be found in the project root](https://github.com/hashicorp/go-azure-sdk/tree/main/docs).

### Import Path

'''go
import "github.com/hashicorp/go-azure-sdk/resource-manager/compute/2022-02-01/disks"
'''

### Client Initialization

'''go
client := disks.NewDisksClientWithBaseURI("https://management.azure.com")
client.Client.Authorizer = authorizer
'''

### Example Usage: 'DisksClient.SomeLongRunning'

'''go
ctx := context.TODO()
id := disks.NewDiskID("my-disk")
payload := disks.SomeModel{
	// ...
}

if err := client.SomeLongRunningThenPoll(ctx, id, payload); err != nil {
	// handle the error
}
'''
`, "'", "`")
	actual, err := readmeTemplater{
		sortedOperationNames: []string{
			"SomeLongRunning",
		},
		operations: map[string]resourcemanager.ApiOperation{
			"SomeLongRunning": {
				LongRunning:    true,
				ResourceIdName: stringPointer("Disk"),
				RequestObject: &resourcemanager.ApiObjectDefinition{
					Type:          resourcemanager.ReferenceApiObjectDefinitionType,
					ReferenceName: stringPointer("SomeModel"),
				},
			},
		},
	}.template(ServiceGeneratorData{
		packageName:        "disks",
		apiVersion:         "2022-02-01",
		servicePackageName: "compute",
		serviceClientName:  "DisksClient",
		resourceIds: map[string]resourcemanager.ResourceIdDefinition{
			"Disk": {
				Segments: []resourcemanager.ResourceIdSegment{
					{
						Type:       resourcemanager.StaticSegment,
						Name:       "disks",
						FixedValue: stringPointer("disks"),
					},
					{
						Type:         resourcemanager.UserSpecifiedSegment,
						Name:         "diskName",
						ExampleValue: "my-disk",
					},
				},
			},
		},
		models: map[string]resourcemanager.ModelDetails{
			"SomeModel": {
				Fields: map[string]resourcemanager.FieldDetails{
					// doesn't matter for this test
				},
			},
		},
	})
	if err != nil {
		t.Fatalf("generating readme: %+v", err)
	}
	assertTemplatedCodeMatches(t, expected, *actual)
}

func TestReadmeTemplater_LongRunningOperationWithResourceIDAndPayloadAndOptions(t *testing.T) {
	expected := strings.ReplaceAll(`
## 'github.com/hashicorp/go-azure-sdk/resource-manager/compute/2022-02-01/disks' Documentation

The 'disks' SDK allows for interaction with the Azure Resource Manager Service 'compute' (API Version '2022-02-01').

This readme covers example usages, but further information on [using this SDK can be found in the project root](https://github.com/hashicorp/go-azure-sdk/tree/main/docs).

### Import Path

'''go
import "github.com/hashicorp/go-azure-sdk/resource-manager/compute/2022-02-01/disks"
'''

### Client Initialization

'''go
client := disks.NewDisksClientWithBaseURI("https://management.azure.com")
client.Client.Authorizer = authorizer
'''

### Example Usage: 'DisksClient.SomeLongRunning'

'''go
ctx := context.TODO()
id := disks.NewDiskID("my-disk")
payload := disks.SomeModel{
	// ...
}

if err := client.SomeLongRunningThenPoll(ctx, id, payload, disks.DefaultSomeLongRunningOperationOptions()); err != nil {
	// handle the error
}
'''
`, "'", "`")
	actual, err := readmeTemplater{
		sortedOperationNames: []string{
			"SomeLongRunning",
		},
		operations: map[string]resourcemanager.ApiOperation{
			"SomeLongRunning": {
				LongRunning:    true,
				ResourceIdName: stringPointer("Disk"),
				RequestObject: &resourcemanager.ApiObjectDefinition{
					Type:          resourcemanager.ReferenceApiObjectDefinitionType,
					ReferenceName: stringPointer("SomeModel"),
				},
				Options: map[string]resourcemanager.ApiOperationOption{
					"Example": {
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.StringApiObjectDefinitionType,
						},
						Required: false,
					},
				},
			},
		},
	}.template(ServiceGeneratorData{
		packageName:        "disks",
		apiVersion:         "2022-02-01",
		servicePackageName: "compute",
		serviceClientName:  "DisksClient",
		resourceIds: map[string]resourcemanager.ResourceIdDefinition{
			"Disk": {
				Segments: []resourcemanager.ResourceIdSegment{
					{
						Type:       resourcemanager.StaticSegment,
						Name:       "disks",
						FixedValue: stringPointer("disks"),
					},
					{
						Type:         resourcemanager.UserSpecifiedSegment,
						Name:         "diskName",
						ExampleValue: "my-disk",
					},
				},
			},
		},
		models: map[string]resourcemanager.ModelDetails{
			"SomeModel": {
				Fields: map[string]resourcemanager.FieldDetails{
					// doesn't matter for this test
				},
			},
		},
	})
	if err != nil {
		t.Fatalf("generating readme: %+v", err)
	}
	assertTemplatedCodeMatches(t, expected, *actual)
}

func TestReadmeTemplater_LongRunningOperationWithResourceIDAndOptions(t *testing.T) {
	expected := strings.ReplaceAll(`
## 'github.com/hashicorp/go-azure-sdk/resource-manager/compute/2022-02-01/disks' Documentation

The 'disks' SDK allows for interaction with the Azure Resource Manager Service 'compute' (API Version '2022-02-01').

This readme covers example usages, but further information on [using this SDK can be found in the project root](https://github.com/hashicorp/go-azure-sdk/tree/main/docs).

### Import Path

'''go
import "github.com/hashicorp/go-azure-sdk/resource-manager/compute/2022-02-01/disks"
'''

### Client Initialization

'''go
client := disks.NewDisksClientWithBaseURI("https://management.azure.com")
client.Client.Authorizer = authorizer
'''

### Example Usage: 'DisksClient.SomeLongRunning'

'''go
ctx := context.TODO()
id := disks.NewDiskID("my-disk")
if err := client.SomeLongRunningThenPoll(ctx, id, disks.DefaultSomeLongRunningOperationOptions()); err != nil {
	// handle the error
}
'''
`, "'", "`")
	actual, err := readmeTemplater{
		sortedOperationNames: []string{
			"SomeLongRunning",
		},
		operations: map[string]resourcemanager.ApiOperation{
			"SomeLongRunning": {
				LongRunning:    true,
				ResourceIdName: stringPointer("Disk"),
				Options: map[string]resourcemanager.ApiOperationOption{
					"Example": {
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.StringApiObjectDefinitionType,
						},
						Required: false,
					},
				},
			},
		},
	}.template(ServiceGeneratorData{
		packageName:        "disks",
		apiVersion:         "2022-02-01",
		servicePackageName: "compute",
		serviceClientName:  "DisksClient",
		resourceIds: map[string]resourcemanager.ResourceIdDefinition{
			"Disk": {
				Segments: []resourcemanager.ResourceIdSegment{
					{
						Type:       resourcemanager.StaticSegment,
						Name:       "disks",
						FixedValue: stringPointer("disks"),
					},
					{
						Type:         resourcemanager.UserSpecifiedSegment,
						Name:         "diskName",
						ExampleValue: "my-disk",
					},
				},
			},
		},
		models: map[string]resourcemanager.ModelDetails{},
	})
	if err != nil {
		t.Fatalf("generating readme: %+v", err)
	}
	assertTemplatedCodeMatches(t, expected, *actual)
}

func TestReadmeTemplater_LongRunningOperationWithoutResourceID(t *testing.T) {
	expected := strings.ReplaceAll(`
## 'github.com/hashicorp/go-azure-sdk/resource-manager/compute/2022-02-01/disks' Documentation

The 'disks' SDK allows for interaction with the Azure Resource Manager Service 'compute' (API Version '2022-02-01').

This readme covers example usages, but further information on [using this SDK can be found in the project root](https://github.com/hashicorp/go-azure-sdk/tree/main/docs).

### Import Path

'''go
import "github.com/hashicorp/go-azure-sdk/resource-manager/compute/2022-02-01/disks"
'''

### Client Initialization

'''go
client := disks.NewDisksClientWithBaseURI("https://management.azure.com")
client.Client.Authorizer = authorizer
'''

### Example Usage: 'DisksClient.SomeLongRunning'

'''go
ctx := context.TODO()

if err := client.SomeLongRunningThenPoll(ctx); err != nil {
	// handle the error
}
'''
`, "'", "`")
	actual, err := readmeTemplater{
		sortedOperationNames: []string{
			"SomeLongRunning",
		},
		operations: map[string]resourcemanager.ApiOperation{
			"SomeLongRunning": {
				LongRunning:    true,
				ResourceIdName: nil,
			},
		},
	}.template(ServiceGeneratorData{
		packageName:        "disks",
		apiVersion:         "2022-02-01",
		servicePackageName: "compute",
		serviceClientName:  "DisksClient",
		resourceIds:        map[string]resourcemanager.ResourceIdDefinition{},
	})
	if err != nil {
		t.Fatalf("generating readme: %+v", err)
	}
	assertTemplatedCodeMatches(t, expected, *actual)
}

func TestReadmeTemplater_MultipleOperations(t *testing.T) {
	expected := strings.ReplaceAll(`
## 'github.com/hashicorp/go-azure-sdk/resource-manager/compute/2022-02-01/disks' Documentation

The 'disks' SDK allows for interaction with the Azure Resource Manager Service 'compute' (API Version '2022-02-01').

This readme covers example usages, but further information on [using this SDK can be found in the project root](https://github.com/hashicorp/go-azure-sdk/tree/main/docs).

### Import Path

'''go
import "github.com/hashicorp/go-azure-sdk/resource-manager/compute/2022-02-01/disks"
'''

### Client Initialization

'''go
client := disks.NewDisksClientWithBaseURI("https://management.azure.com")
client.Client.Authorizer = authorizer
'''

### Example Usage: 'DisksClient.Delete'

'''go
ctx := context.TODO()
read, err := client.Delete(ctx)
if err != nil {
	// handle the error
}
if model := read.Model; model != nil {
	// do something with the model/response object
}
'''

### Example Usage: 'DisksClient.Get'

'''go
ctx := context.TODO()
read, err := client.Get(ctx)
if err != nil {
	// handle the error
}
if model := read.Model; model != nil {
	// do something with the model/response object
}
'''
`, "'", "`")
	actual, err := readmeTemplater{
		sortedOperationNames: []string{
			"Delete",
			"Get",
		},
		operations: map[string]resourcemanager.ApiOperation{
			// intentional to double-check the ordering is used
			"Get": {
				LongRunning:    false,
				ResourceIdName: nil,
			},
			"Delete": {
				LongRunning:    false,
				ResourceIdName: nil,
			},
		},
	}.template(ServiceGeneratorData{
		packageName:        "disks",
		apiVersion:         "2022-02-01",
		servicePackageName: "compute",
		serviceClientName:  "DisksClient",
		resourceIds:        map[string]resourcemanager.ResourceIdDefinition{},
	})
	if err != nil {
		t.Fatalf("generating readme: %+v", err)
	}
	assertTemplatedCodeMatches(t, expected, *actual)
}
