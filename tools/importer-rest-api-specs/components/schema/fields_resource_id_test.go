package schema

import (
	"testing"

	"github.com/hashicorp/go-hclog"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func TestTopLevelFieldsWithinResourceId_NoSegmentsShouldError(t *testing.T) {
	input := resourcemanager.ResourceIdDefinition{
		Segments: []resourcemanager.ResourceIdSegment{
			// intentionally none
		},
	}
	inputMappings := resourcemanager.MappingDefinition{
		Create:     []resourcemanager.FieldMappingDefinition{},
		Read:       []resourcemanager.FieldMappingDefinition{},
		Update:     &[]resourcemanager.FieldMappingDefinition{},
		ResourceId: []resourcemanager.ResourceIdMappingDefinition{},
	}
	actualFields, actualMappings, err := Builder{}.identityTopLevelFieldsWithinResourceID(input, &inputMappings, "Nothing", hclog.New(hclog.DefaultOptions))
	if err == nil {
		t.Fatalf("expected an error but didn't get one")
	}
	if actualFields != nil {
		t.Fatalf("expected actualFields to be nil when an error is returned but got %+v", *actualFields)
	}
	if actualMappings != nil {
		t.Fatalf("expected actualMappings to be nil when an error is returned but got %+v", *actualMappings)
	}
}

func TestTopLevelFieldsWithinResourceId_ResourceGroup(t *testing.T) {
	input := resourcemanager.ResourceIdDefinition{
		Segments: []resourcemanager.ResourceIdSegment{
			{
				FixedValue: stringPointer("subscriptions"),
				Name:       "subscriptions",
				Type:       resourcemanager.StaticSegment,
			},
			{
				Name: "subscriptionId",
				Type: resourcemanager.SubscriptionIdSegment,
			},
			{
				FixedValue: stringPointer("resourceGroups"),
				Name:       "resourceGroups",
				Type:       resourcemanager.StaticSegment,
			},
			{
				Name: "resourceGroupName",
				Type: resourcemanager.ResourceGroupSegment,
			},
		},
	}
	inputMappings := resourcemanager.MappingDefinition{
		Create:     []resourcemanager.FieldMappingDefinition{},
		Read:       []resourcemanager.FieldMappingDefinition{},
		Update:     &[]resourcemanager.FieldMappingDefinition{},
		ResourceId: []resourcemanager.ResourceIdMappingDefinition{},
	}
	actualFields, actualMappings, err := Builder{}.identityTopLevelFieldsWithinResourceID(input, &inputMappings, "Resource Group", hclog.New(hclog.DefaultOptions))
	if err != nil {
		t.Fatalf("error: %+v", err)
	}

	// first check we've mapped the field across
	if actualFields == nil {
		t.Fatalf("expected actualFields to be non-nil but was nil")
	}
	if len(*actualFields) != 1 {
		t.Fatalf("expcted actualFields to contain 1 item but got %d", len(*actualFields))
	}
	name, ok := (*actualFields)["Name"]
	if !ok {
		t.Fatalf("expected there to be a field called `Name` but there wasn't")
	}
	if !name.Required {
		t.Fatalf("expected the field Name to be Required but it wasn't")
	}
	if !name.ForceNew {
		t.Fatalf("expected the field Name to be ForceNew but it wasn't")
	}
	if name.ObjectDefinition.Type != resourcemanager.TerraformSchemaFieldTypeResourceGroup {
		t.Fatalf("expected Name to be a Resource Group Field but got %q", string(name.ObjectDefinition.Type))
	}
	if name.Documentation.Markdown != "Specifies the name of this Resource Group." {
		t.Fatalf("expected the description for `Name` to be `Specifies the name of this Resource Group.` but got %q", name.Documentation.Markdown)
	}

	// then check the mappings
	if actualMappings == nil {
		t.Fatalf("expected actualMappings to be non-nil but was nil")
	}
	if len(actualMappings.Create) > 0 {
		t.Fatalf("expected no create mappings but got %d", len(actualMappings.Create))
	}
	if actualMappings.Update != nil && len(*actualMappings.Update) > 0 {
		t.Fatalf("expected no update mappings but got %d", len(*actualMappings.Update))
	}
	if len(actualMappings.Read) > 0 {
		t.Fatalf("expected no read mappings but got %d", len(actualMappings.Read))
	}
	if len(actualMappings.ResourceId) != 1 {
		t.Fatalf("expected there to be 1 ResourceId mapping but got %d", len(actualMappings.ResourceId))
	}
	checkResourceIdMappingExistsBetween(t, actualMappings.ResourceId, "Name", "resourceGroupName")
}

func TestTopLevelFieldsWithinResourceId_VirtualMachine(t *testing.T) {
	input := resourcemanager.ResourceIdDefinition{
		Segments: []resourcemanager.ResourceIdSegment{
			{
				FixedValue: stringPointer("subscriptions"),
				Name:       "subscriptions",
				Type:       resourcemanager.StaticSegment,
			},
			{
				Name: "subscriptionId",
				Type: resourcemanager.SubscriptionIdSegment,
			},
			{
				FixedValue: stringPointer("resourceGroups"),
				Name:       "resourceGroups",
				Type:       resourcemanager.StaticSegment,
			},
			{
				Name: "resourceGroupName",
				Type: resourcemanager.ResourceGroupSegment,
			},
			{
				FixedValue: stringPointer("providers"),
				Name:       "providers",
				Type:       resourcemanager.StaticSegment,
			},
			{
				FixedValue: stringPointer("Microsoft.Compute"),
				Name:       "staticMicrosoftCompute",
				Type:       resourcemanager.ResourceProviderSegment,
			},
			{
				FixedValue: stringPointer("virtualMachines"),
				Name:       "virtualMachines",
				Type:       resourcemanager.StaticSegment,
			},
			{
				Name: "virtualMachineName",
				Type: resourcemanager.UserSpecifiedSegment,
			},
		},
	}
	inputMappings := resourcemanager.MappingDefinition{
		Create:     []resourcemanager.FieldMappingDefinition{},
		Read:       []resourcemanager.FieldMappingDefinition{},
		Update:     &[]resourcemanager.FieldMappingDefinition{},
		ResourceId: []resourcemanager.ResourceIdMappingDefinition{},
	}
	actualFields, actualMappings, err := Builder{}.identityTopLevelFieldsWithinResourceID(input, &inputMappings, "Virtual Machine", hclog.New(hclog.DefaultOptions))
	if err != nil {
		t.Fatalf("error: %+v", err)
	}

	// first check we've mapped the field across
	if actualFields == nil {
		t.Fatalf("expected actualFields to be non-nil but was nil")
	}
	if len(*actualFields) != 2 {
		t.Fatalf("expcted actualFields to contain 2 items but got %d", len(*actualFields))
	}
	resourceGroupName, ok := (*actualFields)["ResourceGroupName"]
	if !ok {
		t.Fatalf("expected there to be a field called `ResourceGroupName` but there wasn't")
	}
	if !resourceGroupName.Required {
		t.Fatalf("expected the field ResourceGroupName to be Required but it wasn't")
	}
	if !resourceGroupName.ForceNew {
		t.Fatalf("expected the field ResourceGroupName to be ForceNew but it wasn't")
	}
	if resourceGroupName.ObjectDefinition.Type != resourcemanager.TerraformSchemaFieldTypeResourceGroup {
		t.Fatalf("expected ResourceGroupName to be a Resource Group Field but got %q", string(resourceGroupName.ObjectDefinition.Type))
	}
	if resourceGroupName.Documentation.Markdown != "Specifies the name of the Resource Group within which this Virtual Machine should exist." {
		t.Fatalf("expected the description for `ResourceGroupName` to be `Specifies the name of the Resource Group within which this Virtual Machine should exist.` but got %q", resourceGroupName.Documentation.Markdown)
	}

	name, ok := (*actualFields)["Name"]
	if !ok {
		t.Fatalf("expected there to be a field called `Name` but there wasn't")
	}
	if !name.Required {
		t.Fatalf("expected the field Name to be Required but it wasn't")
	}
	if !name.ForceNew {
		t.Fatalf("expected the field Name to be ForceNew but it wasn't")
	}
	if name.ObjectDefinition.Type != resourcemanager.TerraformSchemaFieldTypeString {
		t.Fatalf("expected Name to be a String Field but got %q", string(name.ObjectDefinition.Type))
	}
	if name.Documentation.Markdown != "Specifies the name of this Virtual Machine." {
		t.Fatalf("expected the description for `Name` to be `Specifies the name of this Virtual Machine.` but got %q", name.Documentation.Markdown)
	}

	// then check the mappings
	if actualMappings == nil {
		t.Fatalf("expected actualMappings to be non-nil but was nil")
	}
	if len(actualMappings.Create) > 0 {
		t.Fatalf("expected no create mappings but got %d", len(actualMappings.Create))
	}
	if actualMappings.Update != nil && len(*actualMappings.Update) > 0 {
		t.Fatalf("expected no update mappings but got %d", len(*actualMappings.Update))
	}
	if len(actualMappings.Read) > 0 {
		t.Fatalf("expected no read mappings but got %d", len(actualMappings.Read))
	}
	if len(actualMappings.ResourceId) != 2 {
		t.Fatalf("expected there to be 2 ResourceId mappings but got %d", len(actualMappings.ResourceId))
	}
	checkResourceIdMappingExistsBetween(t, actualMappings.ResourceId, "ResourceGroupName", "resourceGroupName")
	checkResourceIdMappingExistsBetween(t, actualMappings.ResourceId, "Name", "virtualMachineName")
}

func TestTopLevelFieldsWithinResourceId_VirtualMachineExtension(t *testing.T) {
	input := resourcemanager.ResourceIdDefinition{
		Segments: []resourcemanager.ResourceIdSegment{
			{
				FixedValue: stringPointer("subscriptions"),
				Name:       "subscriptions",
				Type:       resourcemanager.StaticSegment,
			},
			{
				Name: "subscriptionId",
				Type: resourcemanager.SubscriptionIdSegment,
			},
			{
				FixedValue: stringPointer("resourceGroups"),
				Name:       "resourceGroups",
				Type:       resourcemanager.StaticSegment,
			},
			{
				Name: "resourceGroupName",
				Type: resourcemanager.ResourceGroupSegment,
			},
			{
				FixedValue: stringPointer("providers"),
				Name:       "providers",
				Type:       resourcemanager.StaticSegment,
			},
			{
				FixedValue: stringPointer("Microsoft.Compute"),
				Name:       "staticMicrosoftCompute",
				Type:       resourcemanager.ResourceProviderSegment,
			},
			{
				FixedValue: stringPointer("virtualMachines"),
				Name:       "virtualMachines",
				Type:       resourcemanager.StaticSegment,
			},
			{
				Name: "virtualMachineName",
				Type: resourcemanager.UserSpecifiedSegment,
			},
			{
				FixedValue: stringPointer("extensions"),
				Name:       "extensions",
				Type:       resourcemanager.StaticSegment,
			},
			{
				Name: "extensionsName",
				Type: resourcemanager.UserSpecifiedSegment,
			},
		},
	}
	inputMappings := resourcemanager.MappingDefinition{
		Create:     []resourcemanager.FieldMappingDefinition{},
		Read:       []resourcemanager.FieldMappingDefinition{},
		Update:     &[]resourcemanager.FieldMappingDefinition{},
		ResourceId: []resourcemanager.ResourceIdMappingDefinition{},
	}
	actualFields, actualMappings, err := Builder{}.identityTopLevelFieldsWithinResourceID(input, &inputMappings, "Virtual Machine Extension", hclog.New(hclog.DefaultOptions))
	if err != nil {
		t.Fatalf("error: %+v", err)
	}

	// first check we've mapped the field across
	if actualFields == nil {
		t.Fatalf("expected actualFields to be non-nil but was nil")
	}
	if len(*actualFields) != 3 {
		t.Fatalf("expcted actualFields to contain 3 items but got %d", len(*actualFields))
	}
	resourceGroupName, ok := (*actualFields)["ResourceGroupName"]
	if !ok {
		t.Fatalf("expected there to be a field called `ResourceGroupName` but there wasn't")
	}
	if !resourceGroupName.Required {
		t.Fatalf("expected the field ResourceGroupName to be Required but it wasn't")
	}
	if !resourceGroupName.ForceNew {
		t.Fatalf("expected the field ResourceGroupName to be ForceNew but it wasn't")
	}
	if resourceGroupName.ObjectDefinition.Type != resourcemanager.TerraformSchemaFieldTypeResourceGroup {
		t.Fatalf("expected ResourceGroupName to be a Resource Group Field but got %q", string(resourceGroupName.ObjectDefinition.Type))
	}
	if resourceGroupName.Documentation.Markdown != "Specifies the name of the Resource Group within which this Virtual Machine Extension should exist." {
		t.Fatalf("expected the description for `ResourceGroupName` to be `Specifies the name of the Resource Group within which this Virtual Machine Extension should exist.` but got %q", resourceGroupName.Documentation.Markdown)
	}

	virtualMachineName, ok := (*actualFields)["VirtualMachineName"]
	if !ok {
		t.Fatalf("expected there to be a field called `VirtualMachineName` but there wasn't")
	}
	if !virtualMachineName.Required {
		t.Fatalf("expected the field VirtualMachineName to be Required but it wasn't")
	}
	if !virtualMachineName.ForceNew {
		t.Fatalf("expected the field VirtualMachineName to be ForceNew but it wasn't")
	}
	if virtualMachineName.ObjectDefinition.Type != resourcemanager.TerraformSchemaFieldTypeString {
		t.Fatalf("expected VirtualMachineName to be a String Field but got %q", string(virtualMachineName.ObjectDefinition.Type))
	}
	if virtualMachineName.Documentation.Markdown != "Specifies the name of the Virtual Machine within which this Virtual Machine Extension should exist." {
		t.Fatalf("expected the description for `VirtualMachineName` to be `Specifies the name of the Virtual Machine within which this Virtual Machine Extension should exist.` but got %q", resourceGroupName.Documentation.Markdown)
	}

	name, ok := (*actualFields)["Name"]
	if !ok {
		t.Fatalf("expected there to be a field called `Name` but there wasn't")
	}
	if !name.Required {
		t.Fatalf("expected the field Name to be Required but it wasn't")
	}
	if !name.ForceNew {
		t.Fatalf("expected the field Name to be ForceNew but it wasn't")
	}
	if name.ObjectDefinition.Type != resourcemanager.TerraformSchemaFieldTypeString {
		t.Fatalf("expected Name to be a String Field but got %q", string(name.ObjectDefinition.Type))
	}
	if name.Documentation.Markdown != "Specifies the name of this Virtual Machine Extension." {
		t.Fatalf("expected the description for `Name` to be `Specifies the name of this Virtual Machine Extension.` but got %q", name.Documentation.Markdown)
	}

	// then check the mappings
	if actualMappings == nil {
		t.Fatalf("expected actualMappings to be non-nil but was nil")
	}
	if len(actualMappings.Create) > 0 {
		t.Fatalf("expected no create mappings but got %d", len(actualMappings.Create))
	}
	if actualMappings.Update != nil && len(*actualMappings.Update) > 0 {
		t.Fatalf("expected no update mappings but got %d", len(*actualMappings.Update))
	}
	if len(actualMappings.Read) > 0 {
		t.Fatalf("expected no read mappings but got %d", len(actualMappings.Read))
	}
	if len(actualMappings.ResourceId) != 3 {
		t.Fatalf("expected there to be 3 ResourceId mappings but got %d", len(actualMappings.ResourceId))
	}
	checkResourceIdMappingExistsBetween(t, actualMappings.ResourceId, "ResourceGroupName", "resourceGroupName")
	checkResourceIdMappingExistsBetween(t, actualMappings.ResourceId, "VirtualMachineName", "virtualMachineName")
	checkResourceIdMappingExistsBetween(t, actualMappings.ResourceId, "Name", "extensionName")
}

func checkResourceIdMappingExistsBetween(t *testing.T, mappings []resourcemanager.ResourceIdMappingDefinition, schemaFieldName, segmentName string) {
	found := false
	for _, item := range mappings {
		if item.SchemaFieldName != schemaFieldName && item.SegmentName != segmentName {
			continue
		}

		found = true
		break
	}
	if !found {
		t.Fatalf("expected there to be a Resource ID Mapping from Schema Field %q to Segment Name %q but there wasn't", schemaFieldName, segmentName)
	}
}
