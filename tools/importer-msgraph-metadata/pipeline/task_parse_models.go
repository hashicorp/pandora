package pipeline

import (
	"github.com/getkin/kin-openapi/openapi3"
	"github.com/hashicorp/go-hclog"
)

func (pipelineTask) parseModels(logger hclog.Logger, schemas openapi3.Schemas) (models Models, err error) {
	models = make(Models)
	for modelName, schemaRef := range schemas {
		name := cleanName(modelName)
		if schema := parseSchemaRef(schemaRef); schema != nil {
			var f flattenedSchema
			f, _ = flattenSchema(schema, nil)
			models = parseSchemas(f, name, models)
		}
	}

	return
}
