package pipeline

import (
	"fmt"
	"strings"

	"github.com/getkin/kin-openapi/openapi3"
)

type Models map[string]*Model

func (m Models) Found(modelName string) (ok bool) {
	_, ok = m[modelName]
	return
}

type Model struct {
	Fields map[string]*ModelField
}

func (m Model) Merge(m2 Model) {
	// TODO maybe implement this
}

type ModelField struct {
	Title       string
	Type        FieldType
	Description string
	Default     interface{}
	Enum        []interface{}
	ItemType    FieldType
	ModelName   string
	JsonField   string
}

func (f ModelField) GoTag() string {
	return fmt.Sprintf("`json:\"%s,omitempty\"`", f.JsonField)
}

func (f ModelField) CSType() string {
	switch f.Type {
	case FieldTypeUnknown:
		panic("unknown field") // TODO
	case FieldTypeModel:
		if f.ModelName == "" {
			panic("model not found") // TODO
		}
		return fmt.Sprintf("%sModel", f.ModelName)
	case FieldTypeArray:
		if f.ModelName == "" {
			if f.Enum != nil {
				return fmt.Sprintf("%sConstant[]", f.Title)
			}
			if f.ItemType > 0 {
				return fmt.Sprintf("%s[]", f.ItemType.CSType())
			}
			panic("model for array not found") // TODO
		}
		return fmt.Sprintf("%sModel[]", f.ModelName)
	case FieldTypeString:
		if f.Enum != nil {
			return fmt.Sprintf("%sConstant", f.Title)
		}
		return "string"
	default:
		return f.Type.CSType()
	}
	return ""
}

func (f ModelField) GoType() string {
	switch f.Type {
	case FieldTypeUnknown:
		return "interface{}"
	case FieldTypeModel:
		if f.ModelName == "" {
			return "interface{}" // TODO: model not found
		}
		return fmt.Sprintf("*%s", f.ModelName)
	case FieldTypeArray:
		if f.ModelName == "" {
			if f.Enum != nil {
				return fmt.Sprintf("*[]%s", f.Title)
			}
			if f.ItemType > 0 {
				return fmt.Sprintf("*[]%s", f.ItemType.GoType())
			}
			return "[]interface{}" // TODO: model not found
		}
		return fmt.Sprintf("*[]%s", f.ModelName)
	case FieldTypeString:
		if f.Enum != nil {
			return fmt.Sprintf("*%s", f.Title)
		}
		return "*string"
	default:
		return fmt.Sprintf("*%s", f.Type.GoType())
	}
	return ""
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

func (ft FieldType) CSType() string {
	switch ft {
	case FieldTypeString:
		return "string"
	case FieldTypeInteger64:
		return "long"
	case FieldTypeIntegerUnsigned64:
		return "ulong"
	case FieldTypeInteger32:
		return "int"
	case FieldTypeIntegerUnsigned32:
		return "uint"
	case FieldTypeInteger16:
		return "short"
	case FieldTypeIntegerUnsigned16:
		return "ushort"
	case FieldTypeInteger8:
		return "sbyte"
	case FieldTypeIntegerUnsigned8:
		return "byte"
	case FieldTypeFloat32:
		return "float"
	case FieldTypeFloat64:
		return "double"
	case FieldTypeBool:
		return "bool"
	case FieldTypeInterface:
		return "string" // TODO: unknown things can just be strings
	case FieldTypeBase64:
		return "byte[]"
	case FieldTypeDate:
		return "DateTime" // TODO: date
	case FieldTypeDateTime:
		return "DateTime"
	case FieldTypeDuration:
		return "string" // TODO: ISO8601 duration
	case FieldTypeTime:
		return "DateTime" // TODO: time
	case FieldTypeUuid:
		return "string"
	}
	return "string" // TODO: should never get here
}

func (ft FieldType) GoType() string {
	switch ft {
	case FieldTypeString:
		return "string"
	case FieldTypeInteger64:
		return "int"
	case FieldTypeIntegerUnsigned64:
		return "uint"
	case FieldTypeInteger32:
		return "int32"
	case FieldTypeIntegerUnsigned32:
		return "uint32"
	case FieldTypeInteger16:
		return "int16"
	case FieldTypeIntegerUnsigned16:
		return "uint16"
	case FieldTypeInteger8:
		return "int8"
	case FieldTypeIntegerUnsigned8:
		return "uint8"
	case FieldTypeFloat32:
		return "float32"
	case FieldTypeFloat64:
		return "float64"
	case FieldTypeBool:
		return "bool"
	case FieldTypeInterface:
		return "interface{}"
	case FieldTypeBase64:
		return "[]byte"
	case FieldTypeDate:
		return "time.Time" // TODO: date
	case FieldTypeDateTime:
		return "time.Time"
	case FieldTypeDuration:
		return "string" // TODO: ISO8601 duration
	case FieldTypeTime:
		return "time.Time" // TODO: time
	case FieldTypeUuid:
		return "UUID"
	}
	return "interface{}"
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

func parseModels(schemas openapi3.Schemas) Models {
	models := make(Models)
	for modelName, schemaRef := range schemas {
		name := cleanName(modelName)
		if schema := parseSchemaRef(schemaRef); schema != nil {
			var f flattenedSchema
			f, _ = flattenSchema(schema, nil)
			models = parseSchemas(f, name, models)
		}
	}

	return models
}

type flattenedSchema struct {
	Schemas openapi3.Schemas
	Title   string
	Type    string
	Format  string
	Enum    []interface{}
}

func flattenSchema(schema *openapi3.Schema, seenRefs []string) (flattenedSchema, []string) {
	if seenRefs == nil {
		seenRefs = make([]string, 0)
	}
	schemas := make(openapi3.Schemas, 0)
	title := ""
	typ := ""
	format := ""
	enum := make([]interface{}, 0)
	if r := schema.Items; r != nil {
		if r.Ref != "" {
			for _, s := range seenRefs {
				if s == r.Ref {
					continue
				}
			}
			seenRefs = append(seenRefs, r.Ref)
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
					for _, s := range seenRefs {
						if s == r.Ref {
							continue
						}
					}
					seenRefs = append(seenRefs, r.Ref)
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
					for _, s := range seenRefs {
						if s == r.Ref {
							continue
						}
					}
					seenRefs = append(seenRefs, r.Ref)
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

func parseSchemas(input flattenedSchema, modelName string, models Models) Models {
	if _, ok := models[modelName]; ok {
		return models
	}
	model := Model{
		Fields: make(map[string]*ModelField),
	}
	models[modelName] = &model
	for k, v := range input.Schemas {
		schema := parseSchemaRef(v)
		result, _ := flattenSchema(schema, nil)
		title := ""
		if result.Title != "" {
			title = strings.Title(result.Title)
		} else {
			//title = fmt.Sprintf("%s%s", strings.Title(modelName), strings.Title(k))
			title = strings.Title(k)
		}
		field := ModelField{
			Title:       title,
			Description: schema.Description,
			Default:     schema.Default,
			Enum:        schema.Enum,
			JsonField:   k,
		}
		if len(field.Enum) == 0 && len(result.Enum) > 0 {
			field.Enum = result.Enum
		}
		if result.Schemas != nil {
			if _, ok := models[title]; !ok {
				models = parseSchemas(result, title, models)
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

func findModel(resp []Response) string {
	for _, r := range resp {
		if r.ModelName != nil {
			return *r.ModelName
		}
	}
	return ""
}
