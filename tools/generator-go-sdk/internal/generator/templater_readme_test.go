// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package generator

import (
	"strings"
	"testing"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

func TestReadmeTemplater_NoOperations(t *testing.T) {
	// whilst not strictly a real-world example, specifically tests the basics
	expected := strings.ReplaceAll(`
## 'github.com/hashicorp/go-azure-sdk/resource-manager/compute/2022-02-01/disks' Documentation

The 'disks' SDK allows for interaction with Azure Resource Manager 'compute' (API Version '2022-02-01').

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
		operations:           map[string]models.SDKOperation{},
	}.template(GeneratorData{
		packageName:        "disks",
		apiVersion:         "2022-02-01",
		servicePackageName: "compute",
		serviceClientName:  "DisksClient",
		sourceType:         models.ResourceManagerSourceDataType,
	})
	if err != nil {
		t.Fatalf("generating readme: %+v", err)
	}
	assertTemplatedCodeMatches(t, expected, *actual)
}

func TestReadmeTemplater_GetOperationWithResourceID(t *testing.T) {
	expected := strings.ReplaceAll(`
## 'github.com/hashicorp/go-azure-sdk/resource-manager/compute/2022-02-01/disks' Documentation

The 'disks' SDK allows for interaction with Azure Resource Manager 'compute' (API Version '2022-02-01').

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
		operations: map[string]models.SDKOperation{
			"Get": {
				LongRunning:    false,
				ResourceIDName: stringPointer("Disk"),
			},
		},
	}.template(GeneratorData{
		packageName:        "disks",
		apiVersion:         "2022-02-01",
		servicePackageName: "compute",
		serviceClientName:  "DisksClient",
		sourceType:         models.ResourceManagerSourceDataType,
		resourceIds: map[string]models.ResourceID{
			"Disk": {
				Segments: []models.ResourceIDSegment{
					models.NewStaticValueResourceIDSegment("disks", "disks"),
					models.NewUserSpecifiedResourceIDSegment("diskName", "my-disk"),
				},
			},
		},
	})
	if err != nil {
		t.Fatalf("generating readme: %+v", err)
	}
	assertTemplatedCodeMatches(t, expected, *actual)
}

func TestReadmeTemplater_GetOperationWithResourceIDUsingACommonID(t *testing.T) {
	expected := strings.ReplaceAll(`
## 'github.com/hashicorp/go-azure-sdk/resource-manager/compute/2022-02-01/disks' Documentation

The 'disks' SDK allows for interaction with Azure Resource Manager 'compute' (API Version '2022-02-01').

This readme covers example usages, but further information on [using this SDK can be found in the project root](https://github.com/hashicorp/go-azure-sdk/tree/main/docs).

### Import Path

'''go
import "github.com/hashicorp/go-azure-helpers/resourcemanager/commonids"
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
id := commonids.NewManagedDiskID("my-disk")
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
		operations: map[string]models.SDKOperation{
			"Get": {
				LongRunning:    false,
				ResourceIDName: stringPointer("Disk"),
			},
		},
	}.template(GeneratorData{
		packageName:        "disks",
		apiVersion:         "2022-02-01",
		servicePackageName: "compute",
		serviceClientName:  "DisksClient",
		sourceType:         models.ResourceManagerSourceDataType,
		resourceIds: map[string]models.ResourceID{
			"Disk": {
				CommonIDAlias: pointer.To("ManagedDisk"),
				Segments: []models.ResourceIDSegment{
					models.NewStaticValueResourceIDSegment("disks", "disks"),
					models.NewUserSpecifiedResourceIDSegment("diskName", "my-disk"),
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

The 'disks' SDK allows for interaction with Azure Resource Manager 'compute' (API Version '2022-02-01').

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
		operations: map[string]models.SDKOperation{
			"Get": {
				LongRunning:    false,
				ResourceIDName: stringPointer("Disk"),
				RequestObject: &models.SDKObjectDefinition{
					Type:          models.ReferenceSDKObjectDefinitionType,
					ReferenceName: stringPointer("SomeModel"),
				},
			},
		},
	}.template(GeneratorData{
		packageName:        "disks",
		apiVersion:         "2022-02-01",
		servicePackageName: "compute",
		serviceClientName:  "DisksClient",
		sourceType:         models.ResourceManagerSourceDataType,
		resourceIds: map[string]models.ResourceID{
			"Disk": {
				Segments: []models.ResourceIDSegment{
					models.NewStaticValueResourceIDSegment("disks", "disks"),
					models.NewUserSpecifiedResourceIDSegment("diskName", "my-disk"),
				},
			},
		},
		models: map[string]models.SDKModel{
			"SomeModel": {
				Fields: map[string]models.SDKField{
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

The 'disks' SDK allows for interaction with Azure Resource Manager 'compute' (API Version '2022-02-01').

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
		operations: map[string]models.SDKOperation{
			"Get": {
				LongRunning:    false,
				ResourceIDName: stringPointer("Disk"),
				RequestObject: &models.SDKObjectDefinition{
					Type:          models.ReferenceSDKObjectDefinitionType,
					ReferenceName: stringPointer("SomeModel"),
				},
				Options: map[string]models.SDKOperationOption{
					"Example": {
						ObjectDefinition: models.SDKOperationOptionObjectDefinition{
							Type: models.StringSDKOperationOptionObjectDefinitionType,
						},
						Required: false,
					},
				},
			},
		},
	}.template(GeneratorData{
		packageName:        "disks",
		apiVersion:         "2022-02-01",
		servicePackageName: "compute",
		serviceClientName:  "DisksClient",
		sourceType:         models.ResourceManagerSourceDataType,
		resourceIds: map[string]models.ResourceID{
			"Disk": {
				Segments: []models.ResourceIDSegment{
					models.NewStaticValueResourceIDSegment("disks", "disks"),
					models.NewUserSpecifiedResourceIDSegment("diskName", "my-disk"),
				},
			},
		},
		models: map[string]models.SDKModel{
			"SomeModel": {
				Fields: map[string]models.SDKField{
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

The 'disks' SDK allows for interaction with Azure Resource Manager 'compute' (API Version '2022-02-01').

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
		operations: map[string]models.SDKOperation{
			"Get": {
				LongRunning:    false,
				ResourceIDName: stringPointer("Disk"),
				Options: map[string]models.SDKOperationOption{
					"Example": {
						ObjectDefinition: models.SDKOperationOptionObjectDefinition{
							Type: models.StringSDKOperationOptionObjectDefinitionType,
						},
						Required: false,
					},
				},
			},
		},
	}.template(GeneratorData{
		packageName:        "disks",
		apiVersion:         "2022-02-01",
		servicePackageName: "compute",
		serviceClientName:  "DisksClient",
		sourceType:         models.ResourceManagerSourceDataType,
		resourceIds: map[string]models.ResourceID{
			"Disk": {
				Segments: []models.ResourceIDSegment{
					models.NewStaticValueResourceIDSegment("disks", "disks"),
					models.NewUserSpecifiedResourceIDSegment("diskName", "my-disk"),
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

The 'disks' SDK allows for interaction with Azure Resource Manager 'compute' (API Version '2022-02-01').

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
		operations: map[string]models.SDKOperation{
			"Get": {
				LongRunning:    false,
				ResourceIDName: nil,
			},
		},
	}.template(GeneratorData{
		packageName:        "disks",
		apiVersion:         "2022-02-01",
		servicePackageName: "compute",
		serviceClientName:  "DisksClient",
		sourceType:         models.ResourceManagerSourceDataType,
		resourceIds:        map[string]models.ResourceID{},
	})
	if err != nil {
		t.Fatalf("generating readme: %+v", err)
	}
	assertTemplatedCodeMatches(t, expected, *actual)
}

func TestReadmeTemplater_GetOperationWithoutResourceIDWithOptions(t *testing.T) {
	expected := strings.ReplaceAll(`
## 'github.com/hashicorp/go-azure-sdk/resource-manager/compute/2022-02-01/disks' Documentation

The 'disks' SDK allows for interaction with Azure Resource Manager 'compute' (API Version '2022-02-01').

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
		operations: map[string]models.SDKOperation{
			"Get": {
				LongRunning:    false,
				ResourceIDName: nil,
				Options: map[string]models.SDKOperationOption{
					"Example": {
						ObjectDefinition: models.SDKOperationOptionObjectDefinition{
							Type: models.StringSDKOperationOptionObjectDefinitionType,
						},
						Required: false,
					},
				},
			},
		},
	}.template(GeneratorData{
		packageName:        "disks",
		apiVersion:         "2022-02-01",
		servicePackageName: "compute",
		serviceClientName:  "DisksClient",
		sourceType:         models.ResourceManagerSourceDataType,
		resourceIds:        map[string]models.ResourceID{},
	})
	if err != nil {
		t.Fatalf("generating readme: %+v", err)
	}
	assertTemplatedCodeMatches(t, expected, *actual)
}

func TestReadmeTemplater_ListOperationWithResourceID(t *testing.T) {
	expected := strings.ReplaceAll(`
## 'github.com/hashicorp/go-azure-sdk/resource-manager/compute/2022-02-01/disks' Documentation

The 'disks' SDK allows for interaction with Azure Resource Manager 'compute' (API Version '2022-02-01').

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
		operations: map[string]models.SDKOperation{
			"ListSomething": {
				FieldContainingPaginationDetails: stringPointer("SomeField"),
				LongRunning:                      false,
				ResourceIDName:                   stringPointer("Disk"),
			},
		},
	}.template(GeneratorData{
		packageName:        "disks",
		apiVersion:         "2022-02-01",
		servicePackageName: "compute",
		serviceClientName:  "DisksClient",
		sourceType:         models.ResourceManagerSourceDataType,
		resourceIds: map[string]models.ResourceID{
			"Disk": {
				Segments: []models.ResourceIDSegment{
					models.NewStaticValueResourceIDSegment("disks", "disks"),
					models.NewUserSpecifiedResourceIDSegment("diskName", "my-disk"),
				},
			},
		},
	})
	if err != nil {
		t.Fatalf("generating readme: %+v", err)
	}
	assertTemplatedCodeMatches(t, expected, *actual)
}

func TestReadmeTemplater_ListOperationWithResourceIDUsingACommonID(t *testing.T) {
	expected := strings.ReplaceAll(`
## 'github.com/hashicorp/go-azure-sdk/resource-manager/compute/2022-02-01/disks' Documentation

The 'disks' SDK allows for interaction with Azure Resource Manager 'compute' (API Version '2022-02-01').

This readme covers example usages, but further information on [using this SDK can be found in the project root](https://github.com/hashicorp/go-azure-sdk/tree/main/docs).

### Import Path

'''go
import "github.com/hashicorp/go-azure-helpers/resourcemanager/commonids"
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
id := commonids.NewManagedDiskID("my-disk")
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
		operations: map[string]models.SDKOperation{
			"ListSomething": {
				FieldContainingPaginationDetails: stringPointer("SomeField"),
				LongRunning:                      false,
				ResourceIDName:                   stringPointer("Disk"),
			},
		},
	}.template(GeneratorData{
		packageName:        "disks",
		apiVersion:         "2022-02-01",
		servicePackageName: "compute",
		serviceClientName:  "DisksClient",
		sourceType:         models.ResourceManagerSourceDataType,
		resourceIds: map[string]models.ResourceID{
			"Disk": {
				CommonIDAlias: pointer.To("ManagedDisk"),
				Segments: []models.ResourceIDSegment{
					models.NewStaticValueResourceIDSegment("disks", "disks"),
					models.NewUserSpecifiedResourceIDSegment("diskName", "my-disk"),
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

The 'disks' SDK allows for interaction with Azure Resource Manager 'compute' (API Version '2022-02-01').

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
		operations: map[string]models.SDKOperation{
			"ListSomething": {
				LongRunning:    false,
				ResourceIDName: stringPointer("Disk"),
				RequestObject: &models.SDKObjectDefinition{
					Type:          models.ReferenceSDKObjectDefinitionType,
					ReferenceName: stringPointer("SomeModel"),
				},
				FieldContainingPaginationDetails: stringPointer("SomeField"),
			},
		},
	}.template(GeneratorData{
		packageName:        "disks",
		apiVersion:         "2022-02-01",
		servicePackageName: "compute",
		serviceClientName:  "DisksClient",
		sourceType:         models.ResourceManagerSourceDataType,
		resourceIds: map[string]models.ResourceID{
			"Disk": {
				Segments: []models.ResourceIDSegment{
					models.NewStaticValueResourceIDSegment("disks", "disks"),
					models.NewUserSpecifiedResourceIDSegment("diskName", "my-disk"),
				},
			},
		},
		models: map[string]models.SDKModel{
			"SomeModel": {
				Fields: map[string]models.SDKField{
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

The 'disks' SDK allows for interaction with Azure Resource Manager 'compute' (API Version '2022-02-01').

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
		operations: map[string]models.SDKOperation{
			"ListSomething": {
				LongRunning:    false,
				ResourceIDName: stringPointer("Disk"),
				RequestObject: &models.SDKObjectDefinition{
					Type:          models.ReferenceSDKObjectDefinitionType,
					ReferenceName: stringPointer("SomeModel"),
				},
				Options: map[string]models.SDKOperationOption{
					"Example": {
						ObjectDefinition: models.SDKOperationOptionObjectDefinition{
							Type: models.StringSDKOperationOptionObjectDefinitionType,
						},
						Required: false,
					},
				},
				FieldContainingPaginationDetails: stringPointer("SomeField"),
			},
		},
	}.template(GeneratorData{
		packageName:        "disks",
		apiVersion:         "2022-02-01",
		servicePackageName: "compute",
		serviceClientName:  "DisksClient",
		sourceType:         models.ResourceManagerSourceDataType,
		resourceIds: map[string]models.ResourceID{
			"Disk": {
				Segments: []models.ResourceIDSegment{
					models.NewStaticValueResourceIDSegment("disks", "disks"),
					models.NewUserSpecifiedResourceIDSegment("diskName", "my-disk"),
				},
			},
		},
		models: map[string]models.SDKModel{
			"SomeModel": {
				Fields: map[string]models.SDKField{
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

The 'disks' SDK allows for interaction with Azure Resource Manager 'compute' (API Version '2022-02-01').

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
		operations: map[string]models.SDKOperation{
			"ListSomething": {
				LongRunning:    false,
				ResourceIDName: stringPointer("Disk"),
				Options: map[string]models.SDKOperationOption{
					"Example": {
						ObjectDefinition: models.SDKOperationOptionObjectDefinition{
							Type: models.StringSDKOperationOptionObjectDefinitionType,
						},
						Required: false,
					},
				},
				FieldContainingPaginationDetails: stringPointer("SomeField"),
			},
		},
	}.template(GeneratorData{
		packageName:        "disks",
		apiVersion:         "2022-02-01",
		servicePackageName: "compute",
		serviceClientName:  "DisksClient",
		sourceType:         models.ResourceManagerSourceDataType,
		resourceIds: map[string]models.ResourceID{
			"Disk": {
				Segments: []models.ResourceIDSegment{
					models.NewStaticValueResourceIDSegment("disks", "disks"),
					models.NewUserSpecifiedResourceIDSegment("diskName", "my-disk"),
				},
			},
		},
		models: map[string]models.SDKModel{
			"SomeModel": {
				Fields: map[string]models.SDKField{
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

The 'disks' SDK allows for interaction with Azure Resource Manager 'compute' (API Version '2022-02-01').

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
		operations: map[string]models.SDKOperation{
			"ListSomething": {
				LongRunning:                      false,
				ResourceIDName:                   nil,
				FieldContainingPaginationDetails: stringPointer("SomeField"),
			},
		},
	}.template(GeneratorData{
		packageName:        "disks",
		apiVersion:         "2022-02-01",
		servicePackageName: "compute",
		serviceClientName:  "DisksClient",
		sourceType:         models.ResourceManagerSourceDataType,
		resourceIds:        map[string]models.ResourceID{},
	})
	if err != nil {
		t.Fatalf("generating readme: %+v", err)
	}
	assertTemplatedCodeMatches(t, expected, *actual)
}

func TestReadmeTemplater_LongRunningOperationWithResourceID(t *testing.T) {
	expected := strings.ReplaceAll(`
## 'github.com/hashicorp/go-azure-sdk/resource-manager/compute/2022-02-01/disks' Documentation

The 'disks' SDK allows for interaction with Azure Resource Manager 'compute' (API Version '2022-02-01').

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
		operations: map[string]models.SDKOperation{
			"SomeLongRunning": {
				LongRunning:    true,
				ResourceIDName: stringPointer("Disk"),
			},
		},
	}.template(GeneratorData{
		packageName:        "disks",
		apiVersion:         "2022-02-01",
		servicePackageName: "compute",
		serviceClientName:  "DisksClient",
		sourceType:         models.ResourceManagerSourceDataType,
		resourceIds: map[string]models.ResourceID{
			"Disk": {
				Segments: []models.ResourceIDSegment{
					models.NewStaticValueResourceIDSegment("disks", "disks"),
					models.NewUserSpecifiedResourceIDSegment("diskName", "my-disk"),
				},
			},
		},
	})
	if err != nil {
		t.Fatalf("generating readme: %+v", err)
	}
	assertTemplatedCodeMatches(t, expected, *actual)
}

func TestReadmeTemplater_LongRunningOperationWithResourceIDUsingACommonID(t *testing.T) {
	expected := strings.ReplaceAll(`
## 'github.com/hashicorp/go-azure-sdk/resource-manager/compute/2022-02-01/disks' Documentation

The 'disks' SDK allows for interaction with Azure Resource Manager 'compute' (API Version '2022-02-01').

This readme covers example usages, but further information on [using this SDK can be found in the project root](https://github.com/hashicorp/go-azure-sdk/tree/main/docs).

### Import Path

'''go
import "github.com/hashicorp/go-azure-helpers/resourcemanager/commonids"
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
id := commonids.NewManagedDiskID("my-disk")

if err := client.SomeLongRunningThenPoll(ctx, id); err != nil {
	// handle the error
}
'''
`, "'", "`")
	actual, err := readmeTemplater{
		sortedOperationNames: []string{
			"SomeLongRunning",
		},
		operations: map[string]models.SDKOperation{
			"SomeLongRunning": {
				LongRunning:    true,
				ResourceIDName: stringPointer("Disk"),
			},
		},
	}.template(GeneratorData{
		packageName:        "disks",
		apiVersion:         "2022-02-01",
		servicePackageName: "compute",
		serviceClientName:  "DisksClient",
		sourceType:         models.ResourceManagerSourceDataType,
		resourceIds: map[string]models.ResourceID{
			"Disk": {
				CommonIDAlias: pointer.To("ManagedDisk"),
				Segments: []models.ResourceIDSegment{
					models.NewStaticValueResourceIDSegment("disks", "disks"),
					models.NewUserSpecifiedResourceIDSegment("diskName", "my-disk"),
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

The 'disks' SDK allows for interaction with Azure Resource Manager 'compute' (API Version '2022-02-01').

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
		operations: map[string]models.SDKOperation{
			"SomeLongRunning": {
				LongRunning:    true,
				ResourceIDName: stringPointer("Disk"),
				RequestObject: &models.SDKObjectDefinition{
					Type:          models.ReferenceSDKObjectDefinitionType,
					ReferenceName: stringPointer("SomeModel"),
				},
			},
		},
	}.template(GeneratorData{
		packageName:        "disks",
		apiVersion:         "2022-02-01",
		servicePackageName: "compute",
		serviceClientName:  "DisksClient",
		sourceType:         models.ResourceManagerSourceDataType,
		resourceIds: map[string]models.ResourceID{
			"Disk": {
				Segments: []models.ResourceIDSegment{
					models.NewStaticValueResourceIDSegment("disks", "disks"),
					models.NewUserSpecifiedResourceIDSegment("diskName", "my-disk"),
				},
			},
		},
		models: map[string]models.SDKModel{
			"SomeModel": {
				Fields: map[string]models.SDKField{
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

The 'disks' SDK allows for interaction with Azure Resource Manager 'compute' (API Version '2022-02-01').

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
		operations: map[string]models.SDKOperation{
			"SomeLongRunning": {
				LongRunning:    true,
				ResourceIDName: stringPointer("Disk"),
				RequestObject: &models.SDKObjectDefinition{
					Type:          models.ReferenceSDKObjectDefinitionType,
					ReferenceName: stringPointer("SomeModel"),
				},
				Options: map[string]models.SDKOperationOption{
					"Example": {
						ObjectDefinition: models.SDKOperationOptionObjectDefinition{
							Type: models.StringSDKOperationOptionObjectDefinitionType,
						},
						Required: false,
					},
				},
			},
		},
	}.template(GeneratorData{
		packageName:        "disks",
		apiVersion:         "2022-02-01",
		servicePackageName: "compute",
		serviceClientName:  "DisksClient",
		sourceType:         models.ResourceManagerSourceDataType,
		resourceIds: map[string]models.ResourceID{
			"Disk": {
				Segments: []models.ResourceIDSegment{
					models.NewStaticValueResourceIDSegment("disks", "disks"),
					models.NewUserSpecifiedResourceIDSegment("diskName", "my-disk"),
				},
			},
		},
		models: map[string]models.SDKModel{
			"SomeModel": {
				Fields: map[string]models.SDKField{
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

The 'disks' SDK allows for interaction with Azure Resource Manager 'compute' (API Version '2022-02-01').

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
		operations: map[string]models.SDKOperation{
			"SomeLongRunning": {
				LongRunning:    true,
				ResourceIDName: stringPointer("Disk"),
				Options: map[string]models.SDKOperationOption{
					"Example": {
						ObjectDefinition: models.SDKOperationOptionObjectDefinition{
							Type: models.StringSDKOperationOptionObjectDefinitionType,
						},
						Required: false,
					},
				},
			},
		},
	}.template(GeneratorData{
		packageName:        "disks",
		apiVersion:         "2022-02-01",
		servicePackageName: "compute",
		serviceClientName:  "DisksClient",
		sourceType:         models.ResourceManagerSourceDataType,
		resourceIds: map[string]models.ResourceID{
			"Disk": {
				Segments: []models.ResourceIDSegment{
					models.NewStaticValueResourceIDSegment("disks", "disks"),
					models.NewUserSpecifiedResourceIDSegment("diskName", "my-disk"),
				},
			},
		},
		models: map[string]models.SDKModel{},
	})
	if err != nil {
		t.Fatalf("generating readme: %+v", err)
	}
	assertTemplatedCodeMatches(t, expected, *actual)
}

func TestReadmeTemplater_LongRunningOperationWithoutResourceID(t *testing.T) {
	expected := strings.ReplaceAll(`
## 'github.com/hashicorp/go-azure-sdk/resource-manager/compute/2022-02-01/disks' Documentation

The 'disks' SDK allows for interaction with Azure Resource Manager 'compute' (API Version '2022-02-01').

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
		operations: map[string]models.SDKOperation{
			"SomeLongRunning": {
				LongRunning:    true,
				ResourceIDName: nil,
			},
		},
	}.template(GeneratorData{
		packageName:        "disks",
		apiVersion:         "2022-02-01",
		servicePackageName: "compute",
		serviceClientName:  "DisksClient",
		sourceType:         models.ResourceManagerSourceDataType,
		resourceIds:        map[string]models.ResourceID{},
	})
	if err != nil {
		t.Fatalf("generating readme: %+v", err)
	}
	assertTemplatedCodeMatches(t, expected, *actual)
}

func TestReadmeTemplater_MultipleOperations(t *testing.T) {
	expected := strings.ReplaceAll(`
## 'github.com/hashicorp/go-azure-sdk/resource-manager/compute/2022-02-01/disks' Documentation

The 'disks' SDK allows for interaction with Azure Resource Manager 'compute' (API Version '2022-02-01').

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
		operations: map[string]models.SDKOperation{
			// intentional to double-check the ordering is used
			"Get": {
				LongRunning:    false,
				ResourceIDName: nil,
			},
			"Delete": {
				LongRunning:    false,
				ResourceIDName: nil,
			},
		},
	}.template(GeneratorData{
		packageName:        "disks",
		apiVersion:         "2022-02-01",
		servicePackageName: "compute",
		serviceClientName:  "DisksClient",
		sourceType:         models.ResourceManagerSourceDataType,
		resourceIds:        map[string]models.ResourceID{},
	})
	if err != nil {
		t.Fatalf("generating readme: %+v", err)
	}
	assertTemplatedCodeMatches(t, expected, *actual)
}
