package pipeline

func (p pipelineTask) parseModels() (models Models, err error) {
	models = make(Models)
	for modelName, schemaRef := range p.spec.Components.Schemas {
		name := cleanName(modelName)
		if schema := parseSchemaRef(schemaRef); schema != nil {
			var f flattenedSchema
			f, _ = flattenSchema(schema, nil)
			models = parseSchemas(f, name, models)
		}
	}

	return
}
