package pipeline

import (
	"fmt"
	"strings"

	"github.com/getkin/kin-openapi/openapi3"
)

type Models map[string]*Model

func (m Models) Found(modelName string) bool {
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
		if field.ModelName == "" {
			continue
		}

		if _, ok := m[field.ModelName]; ok {
			continue
		}

		if !allModels.Found(field.ModelName) {
			return fmt.Errorf("dependant model not found: %q", modelName)
		}

		if err := m.MergeDependants(allModels, field.ModelName); err != nil {
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

func (m Model) Merge(m2 Model) {
	// TODO maybe implement this
}

type ModelField struct {
	Title       string
	Type        FieldType
	Description string
	Default     interface{}
	Enum        []string
	ItemType    FieldType
	ModelName   string
	JsonField   string
}

func (f ModelField) CSType() *string {
	switch f.Type {
	case FieldTypeUnknown:
		panic("unknown field") // TODO
	case FieldTypeModel:
		if f.ModelName == "" {
			panic("model not found") // TODO
		}
		return pointerTo(fmt.Sprintf("%sModel", f.ModelName))
	case FieldTypeArray:
		if f.ModelName == "" {
			if len(f.Enum) > 0 {
				return pointerTo(fmt.Sprintf("List<%sConstant>", f.Title))
			}
			if f.ItemType > 0 {
				itemType := f.ItemType.CSType()
				if itemType == nil {
					return nil
				}
				return pointerTo(fmt.Sprintf("List<%s>", *itemType))
			}
			panic("model for array not found") // TODO
		}
		return pointerTo(fmt.Sprintf("List<%sModel>", f.ModelName))
	case FieldTypeString:
		if len(f.Enum) > 0 {
			return pointerTo(fmt.Sprintf("%sConstant", f.Title))
		}
		return pointerTo("string")
	default:
		return f.Type.CSType()
	}

	return nil
}

type FieldType uint8

const (
	FieldTypeUnknown FieldType = iota
	FieldTypeInterface
	FieldTypeModel
	FieldTypeArray
	FieldTypeString
	FieldTypeInteger64
	FieldTypeIntegerUnsigned64
	FieldTypeInteger32
	FieldTypeIntegerUnsigned32
	FieldTypeInteger16
	FieldTypeIntegerUnsigned16
	FieldTypeInteger8
	FieldTypeIntegerUnsigned8
	FieldTypeFloat32
	FieldTypeFloat64
	FieldTypeBool
	FieldTypeBase64
	FieldTypeDate
	FieldTypeDateTime
	FieldTypeDuration
	FieldTypeTime
	FieldTypeUuid
)

func (ft FieldType) CSType() *string {
	csType := ""
	switch ft {
	case FieldTypeString:
		csType = "string"
	case FieldTypeInteger64:
		csType = "long"
	case FieldTypeIntegerUnsigned64:
		csType = "ulong"
	case FieldTypeInteger32:
		csType = "int"
	case FieldTypeIntegerUnsigned32:
		csType = "uint"
	case FieldTypeInteger16:
		csType = "short"
	case FieldTypeIntegerUnsigned16:
		csType = "ushort"
	case FieldTypeInteger8:
		csType = "sbyte"
	case FieldTypeIntegerUnsigned8:
		csType = "byte"
	case FieldTypeFloat32:
		csType = "float"
	case FieldTypeFloat64:
		csType = "double"
	case FieldTypeBool:
		csType = "bool"
	case FieldTypeInterface:
		csType = "string" // TODO: unknown things can just be strings
	case FieldTypeBase64:
		//csType = "byte[]" // TODO: byte arrays not yet supported
	case FieldTypeDate:
		csType = "DateTime" // TODO: date
	case FieldTypeDateTime:
		csType = "DateTime"
	case FieldTypeDuration:
		csType = "string" // TODO: ISO8601 duration
	case FieldTypeTime:
		csType = "DateTime" // TODO: time
	case FieldTypeUuid:
		csType = "string"
	}
	if csType == "" {
		return nil
	}
	return &csType
}

func fieldType(schemaType, schemaFormat string, hasModel bool) FieldType {
	switch strings.ToLower(schemaFormat) {
	case "int64":
		return FieldTypeInteger64
	case "uint64":
		return FieldTypeIntegerUnsigned64
	case "int32":
		return FieldTypeInteger32
	case "uint32":
		return FieldTypeIntegerUnsigned32
	case "int16":
		return FieldTypeInteger16
	case "uint16":
		return FieldTypeIntegerUnsigned16
	case "int8":
		return FieldTypeInteger8
	case "uint8":
		return FieldTypeIntegerUnsigned8
	case "float":
		return FieldTypeFloat32
	case "double":
		return FieldTypeFloat64
	case "decimal":
		return FieldTypeFloat32 // TODO: custom decimal type
	case "base64url":
		return FieldTypeBase64
	case "date":
		return FieldTypeDate
	case "date-time":
		return FieldTypeDateTime
	case "duration":
		return FieldTypeDuration
	case "time":
		return FieldTypeTime
	case "uuid":
		return FieldTypeUuid
	}
	switch strings.ToLower(schemaType) {
	case "object":
		return FieldTypeModel
	case "array":
		return FieldTypeArray
	case "boolean":
		return FieldTypeBool
	case "integer":
		return FieldTypeInteger64
	case "string":
		return FieldTypeString
	}
	if hasModel {
		return FieldTypeModel
	} else {
		return FieldTypeInterface
	}
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
			field.ModelName = title
		}

		if schema.Items != nil && schema.Items.Value != nil && schema.Items.Value.Type != "" {
			field.ItemType = fieldType(schema.Items.Value.Type, schema.Items.Value.Format, field.ModelName != "")
		}

		if schema.Type == "" && schema.Format == "" && (result.Type != "" || result.Format != "") {
			field.Type = fieldType(result.Type, result.Format, field.ModelName != "")
		} else {
			field.Type = fieldType(schema.Type, schema.Format, field.ModelName != "")
		}

		if field.Type == FieldTypeArray && len(field.Enum) > 0 && (result.Type != "" || result.Format != "") {
			field.ItemType = fieldType(result.Type, result.Format, field.ModelName != "")
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
