package resourcemanager

func DirectAssignmentMappingBetween(fromModel string, fromField string, toModel string, toField string) FieldMappingDefinition {
	return FieldMappingDefinition{
		Type: DirectAssignmentMappingDefinitionType,
		DirectAssignment: &FieldMappingDirectAssignmentDefinition{
			SchemaModelName: fromModel,
			SchemaFieldPath: fromField,
			SdkModelName:    toModel,
			SdkFieldPath:    toField,
		},
	}
}

func ModelToModelMappingBetween(fromModel string, toModel string, toField string) FieldMappingDefinition {
	return FieldMappingDefinition{
		Type: ModelToModelMappingDefinitionType,
		ModelToModel: &FieldMappingModelToModelDefinition{
			SchemaModelName: fromModel,
			SdkModelName:    toModel,
			SdkFieldName:    toField,
		},
	}
}
