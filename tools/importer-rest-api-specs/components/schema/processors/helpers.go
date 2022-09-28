package processors

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func applyFieldRenameToMappings(input resourcemanager.MappingDefinition, modelName string, oldFieldName string, updatedFieldName string) resourcemanager.MappingDefinition {
	output := resourcemanager.MappingDefinition{
		ResourceId: input.ResourceId,
	}
	for _, v := range input.Create {
		v = applyFieldRenameToFieldMapping(v, modelName, oldFieldName, updatedFieldName)
		output.Create = append(output.Create, v)
	}
	if input.Update != nil {
		output.Update = &[]resourcemanager.FieldMappingDefinition{}
		for _, v := range *input.Update {
			v = applyFieldRenameToFieldMapping(v, modelName, oldFieldName, updatedFieldName)
			updated := append(*output.Update, v)
			output.Update = &updated
		}
	}
	for _, v := range input.Read {
		v = applyFieldRenameToFieldMapping(v, modelName, oldFieldName, updatedFieldName)
		output.Read = append(output.Read, v)
	}
	return output
}

func applyFieldRenameToFieldMapping(v resourcemanager.FieldMappingDefinition, modelName string, oldFieldName string, updatedFieldName string) resourcemanager.FieldMappingDefinition {
	switch v.Type {
	case resourcemanager.DirectAssignmentMappingDefinitionType:
		{
			if v.DirectAssignment.SchemaModelName == modelName && v.DirectAssignment.SchemaFieldPath == oldFieldName {
				v.DirectAssignment.SchemaFieldPath = updatedFieldName
			}
		}
	default:
		panic(fmt.Sprintf("unimplemented: field rename for mapping type %q", string(v.Type)))
	}
	return v
}
