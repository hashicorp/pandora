package mappings

import "github.com/hashicorp/pandora/tools/sdk/resourcemanager"

var directAssignmentTransforms = []directAssignmentTransform{
	directAssignmentTransformLocation{},
	directAssignmentTransformIdentitySystemAssigned{},
	directAssignmentTransformIdentitySystemAndUserAssignedMap{},
	directAssignmentTransformIdentitySystemOrUserAssignedMap{},
	directAssignmentTransformIdentityUserAssignedList{},
	directAssignmentTransformTags{},
	directAssignmentTransformZones{},
}

type directAssignmentTransformFunc = func(outputAssignment, outputVariableName, inputAssignment string) string

type directAssignmentTransform interface {
	schemaFieldType() resourcemanager.TerraformSchemaFieldType
	sdkFieldType() resourcemanager.ApiObjectDefinitionType

	requiredExpandFuncBody() directAssignmentTransformFunc
	optionalExpandFuncBody() directAssignmentTransformFunc

	requiredFlattenFuncBody() directAssignmentTransformFunc
	optionalFlattenFuncBody() directAssignmentTransformFunc
}

func findDirectAssignmentTransform(schemaFieldType resourcemanager.TerraformSchemaFieldType, sdkFieldType resourcemanager.ApiObjectDefinitionType) directAssignmentTransform {
	for _, transform := range directAssignmentTransforms {
		if transform.schemaFieldType() == schemaFieldType && transform.sdkFieldType() == sdkFieldType {
			return transform
		}
	}

	return nil
}
