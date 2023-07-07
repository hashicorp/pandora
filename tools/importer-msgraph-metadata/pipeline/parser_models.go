package pipeline

import (
	"fmt"
	"strings"

	"github.com/getkin/kin-openapi/openapi3"
)

type Models map[string]*Model

func (m Models) Found(modelName string) bool {
	// Safety check, don't allow an empty model name
	if modelName == "" {
		return false
	}

	if model, ok := m[modelName]; ok && model != nil {
		return true
	}

	return false
}

// MergeDependants inspects the named model in m, then traverses allModels and appends any dependant models to m, recursively
func (m Models) MergeDependants(allModels Models, modelName string) error {
	if !allModels.Found(modelName) {
		return fmt.Errorf("model not found: %q", modelName)
	}

	if _, ok := m[modelName]; !ok {
		m[modelName] = allModels[modelName]
	}

	for _, field := range allModels[modelName].Fields {
		if field.ModelName == nil {
			continue
		}

		if _, ok := m[*field.ModelName]; ok {
			continue
		}

		if !allModels.Found(*field.ModelName) {
			return fmt.Errorf("dependant model not found: %q", modelName)
		}

		if err := m.MergeDependants(allModels, *field.ModelName); err != nil {
			return err
		}
	}

	return nil
}

func (m Models) Merge(m2 Models) {
	if m2 == nil {
		return
	}
	for modelName, model := range m2 {
		m[modelName] = model
	}
}

type Model struct {
	Fields map[string]*ModelField
	Common bool
}

type ModelField struct {
	Title       string
	Type        *DataType
	Description string
	Default     interface{}
	Enum        []string
	ItemType    *DataType
	ModelName   *string
	JsonField   string
}

func (f ModelField) CSType() *string {
	if f.Type == nil {
		return nil
	}

	switch *f.Type {
	case DataTypeModel:
		if f.ModelName == nil {
			return nil
		}

		return pointerTo(fmt.Sprintf("%sModel", *f.ModelName))

	case DataTypeArray:
		if f.ModelName != nil {
			return pointerTo(fmt.Sprintf("List<%sModel>", *f.ModelName))
		}

		if f.Title != "" && len(f.Enum) > 0 {
			return pointerTo(fmt.Sprintf("List<%sConstant>", f.Title))
		}

		if f.ItemType != nil {
			if itemCSType := f.ItemType.CSType(); itemCSType != nil {
				return pointerTo(fmt.Sprintf("List<%s>", *itemCSType))
			}
		}

		return nil

	case DataTypeString:
		if f.Title != "" && len(f.Enum) > 0 {
			return pointerTo(fmt.Sprintf("%sConstant", f.Title))
		}
	}

	return f.Type.CSType()
}

type DataType uint8

const (
	DataTypeUnknown DataType = iota
	DataTypeModel
	DataTypeArray
	DataTypeString
	DataTypeInteger64
	DataTypeIntegerUnsigned64
	DataTypeInteger32
	DataTypeIntegerUnsigned32
	DataTypeInteger16
	DataTypeIntegerUnsigned16
	DataTypeInteger8
	DataTypeIntegerUnsigned8
	DataTypeFloat32
	DataTypeFloat64
	DataTypeBool
	DataTypeBase64
	DataTypeDate
	DataTypeDateTime
	DataTypeDuration
	DataTypeTime
	DataTypeUuid
	DataTypeBinary
)

func (ft DataType) CSType() *string {
	csType := ""
	switch ft {
	case DataTypeString:
		csType = "string"
	case DataTypeInteger64:
		csType = "long"
	case DataTypeIntegerUnsigned64:
		csType = "ulong"
	case DataTypeInteger32:
		csType = "int"
	case DataTypeIntegerUnsigned32:
		csType = "uint"
	case DataTypeInteger16:
		csType = "short"
	case DataTypeIntegerUnsigned16:
		csType = "ushort"
	case DataTypeInteger8:
		csType = "sbyte"
	case DataTypeIntegerUnsigned8:
		csType = "byte"
	case DataTypeFloat32:
		csType = "float"
	case DataTypeFloat64:
		csType = "double"
	case DataTypeBool:
		csType = "bool"
	case DataTypeBase64:
		csType = "string"
	case DataTypeDate:
		csType = "DateTime"
	case DataTypeDateTime:
		csType = "DateTime"
	case DataTypeDuration:
		csType = "string"
	case DataTypeTime:
		csType = "DateTime"
	case DataTypeUuid:
		csType = "string"
	case DataTypeBinary:
		csType = "RawFile"
	}
	if csType == "" {
		return nil
	}
	return &csType
}

func fieldType(schemaType, schemaFormat string, hasModel bool) *DataType {
	var ret DataType

	switch strings.ToLower(schemaFormat) {
	case "int64":
		ret = DataTypeInteger64
	case "uint64":
		ret = DataTypeIntegerUnsigned64
	case "int32":
		ret = DataTypeInteger32
	case "uint32":
		ret = DataTypeIntegerUnsigned32
	case "int16":
		ret = DataTypeInteger16
	case "uint16":
		ret = DataTypeIntegerUnsigned16
	case "int8":
		ret = DataTypeInteger8
	case "uint8":
		ret = DataTypeIntegerUnsigned8
	case "float":
		ret = DataTypeFloat32
	case "double":
		ret = DataTypeFloat64
	case "decimal":
		ret = DataTypeFloat32
	case "base64url":
		ret = DataTypeBase64
	case "date":
		ret = DataTypeDate
	case "date-time":
		ret = DataTypeDateTime
	case "duration":
		ret = DataTypeDuration
	case "time":
		ret = DataTypeTime
	case "uuid":
		ret = DataTypeUuid
	case "string":
		ret = DataTypeString
	}
	if ret > 0 {
		return &ret
	}

	switch strings.ToLower(schemaType) {
	case "array":
		ret = DataTypeArray
	case "boolean":
		ret = DataTypeBool
	case "integer":
		ret = DataTypeInteger64
	case "string":
		ret = DataTypeString
	}
	if ret > 0 {
		return &ret
	}

	if hasModel {
		ret = DataTypeModel
		return &ret
	}

	return nil
}

// Schemas is a map[string]*SchemaRef
// SchemaRef is a struct{Ref, Value} where Ref is a string, Value is a *Schema
// The Ref string (after trimming) indicates a Schemas map key to follow/inherit
// Schema has Properties which is a nested Schemas
// Schema has AllOf which is a SchemaRefs
// SchemaRefs is a []*SchemaRef

// Schemas is a model
// SchemaRefs, SchemaRef lead to a Schema or other another SchemaRef
// Schema leads to SchemaRefs and Schemas

func parseCommonModels(schemas openapi3.Schemas) (models Models, err error) {
	models = make(Models)
	for modelName, schemaRef := range schemas {
		name := cleanName(modelName)
		if schema := parseSchemaRef(schemaRef); schema != nil {
			var f flattenedSchema
			f, _ = flattenSchema(schema, nil)
			models = parseSchemas(f, name, models, true)
		}
	}

	return
}

type flattenedSchema struct {
	Schemas openapi3.Schemas
	Title   string
	Type    string
	Format  string
	Enum    []interface{}
}

func flattenSchema(schema *openapi3.Schema, seenRefs map[string]bool) (flattenedSchema, map[string]bool) {
	if seenRefs == nil {
		seenRefs = make(map[string]bool)
	}

	schemas := make(openapi3.Schemas, 0)
	title := ""
	typ := ""
	format := ""
	enum := make([]interface{}, 0)

	if r := schema.Items; r != nil {
		if r.Ref != "" {
			for s := range seenRefs {
				if s == r.Ref {
					continue
				}
			}
			seenRefs[r.Ref] = true
		}

		if s := parseSchemaRef(r); s != nil {
			var result flattenedSchema
			result, seenRefs = flattenSchema(s, seenRefs)
			if result.Title != "" {
				title = result.Title
			}
			if result.Type != "" {
				typ = result.Type
			}
			if result.Format != "" {
				format = result.Format
			}
			if len(result.Enum) > 0 {
				enum = result.Enum
			}
			for k, v := range result.Schemas {
				schemas[k] = v
			}
		}
	} else {
		if schema.AllOf != nil {
			for _, r := range schema.AllOf {
				if r.Ref != "" {
					for s := range seenRefs {
						if s == r.Ref {
							continue
						}
					}
					seenRefs[r.Ref] = true
				}
				if s := parseSchemaRef(r); s != nil {
					var result flattenedSchema
					result, seenRefs = flattenSchema(s, seenRefs)
					if result.Title != "" {
						title = result.Title
					}
					if typ == "" && result.Type != "" {
						typ = result.Type
					}
					if format == "" && result.Format != "" {
						format = result.Format
					}
					if len(result.Enum) > 0 {
						enum = result.Enum
					}
					for k, v := range result.Schemas {
						schemas[k] = v
					}
				}
			}
		}

		if schema.AnyOf != nil {
			for _, r := range schema.AnyOf {
				if r.Ref != "" {
					for s := range seenRefs {
						if s == r.Ref {
							continue
						}
					}
					seenRefs[r.Ref] = true
				}

				if s := parseSchemaRef(r); s != nil {
					var result flattenedSchema
					result, seenRefs = flattenSchema(s, seenRefs)
					if result.Title != "" {
						title = result.Title
					}
					if typ == "" && result.Type != "" {
						typ = result.Type
					}
					if format == "" && result.Format != "" {
						format = result.Format
					}
					if len(result.Enum) > 0 {
						enum = result.Enum
					}
					for k, v := range result.Schemas {
						schemas[k] = v
					}
				}
			}
		}
	}

	if schema.Title != "" {
		title = schema.Title
	}

	// prefer the innermost type
	if typ == "" && schema.Type != "" {
		typ = schema.Type
	}

	// prefer the innermost format
	if format == "" && schema.Format != "" {
		format = schema.Format
	}

	if len(schema.Enum) > 0 {
		enum = schema.Enum
	}

	if schema.Properties != nil {
		for k, v := range schema.Properties {
			schemas[k] = v
		}
	}

	if len(schemas) == 0 {
		schemas = nil
	}

	return flattenedSchema{
		Schemas: schemas,
		Title:   title,
		Type:    typ,
		Format:  format,
		Enum:    enum,
	}, seenRefs
}

func parseSchemaRef(schemaRef *openapi3.SchemaRef) *openapi3.Schema {
	if schemaRef.Value != nil {
		return schemaRef.Value
	}
	return nil
}

func parseSchemas(input flattenedSchema, modelName string, models Models, common bool) Models {
	if _, ok := models[modelName]; ok {
		return models
	}
	model := Model{
		Fields: make(map[string]*ModelField),
		Common: common,
	}
	models[modelName] = &model

	for k, v := range input.Schemas {
		schema := parseSchemaRef(v)
		result, _ := flattenSchema(schema, nil)
		title := ""

		if result.Title != "" {
			title = strings.Title(result.Title)
		} else {
			title = strings.Title(k)
		}

		field := ModelField{
			Title:       title,
			Description: schema.Description,
			Default:     schema.Default,
			Enum:        parseEnum(schema.Enum),
			JsonField:   k,
		}

		if len(field.Enum) == 0 && len(result.Enum) > 0 {
			field.Enum = parseEnum(result.Enum)
		}

		if result.Schemas != nil {
			if _, ok := models[title]; !ok {
				models = parseSchemas(result, title, models, common)
			}
			field.ModelName = &title
		}

		if schema.Items != nil && schema.Items.Value != nil && schema.Items.Value.Type != "" {
			field.ItemType = fieldType(schema.Items.Value.Type, schema.Items.Value.Format, field.ModelName != nil)
		}

		if schema.Type == "" && schema.Format == "" && (result.Type != "" || result.Format != "") {
			field.Type = fieldType(result.Type, result.Format, field.ModelName != nil)
		} else {
			field.Type = fieldType(schema.Type, schema.Format, field.ModelName != nil)
		}

		if field.Type != nil && *field.Type == DataTypeArray && len(field.Enum) > 0 && (result.Type != "" || result.Format != "") {
			field.ItemType = fieldType(result.Type, result.Format, field.ModelName != nil)
		}

		model.Fields[cleanName(k)] = &field
	}

	return models
}

func parseEnum(input []interface{}) []string {
	out := make([]string, 0, len(input))
	for _, raw := range input {
		if v, ok := raw.(string); ok {
			if strings.EqualFold(v, "unknownFutureValue") {
				continue
			}
			out = append(out, v)
		}
	}
	return out
}
