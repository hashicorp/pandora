// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package pipeline

import (
	"fmt"
	"strings"

	"github.com/getkin/kin-openapi/openapi3"
)

/* ===================
   openapi3 cheatsheet
   ===================
   Schemas is a map[string]*SchemaRef
   SchemaRef is a struct{Ref, Value} where Ref is a string, Value is a *Schema
   The Ref string (after trimming) indicates a Schemas map key to follow/inherit
   Schema has Properties which is a nested Schemas
   Schema has AllOf and/or AnyOf which are SchemaRefs
   SchemaRefs is a []*SchemaRef
   Schemas is a model
   SchemaRefs, SchemaRef lead to a Schema or other another SchemaRef
   Schema leads to SchemaRefs and Schemas
*/

const refPrefix = "#/components/schemas/"

type Models map[string]*Model

// Found returns true when the provided modelName was found in the Models map
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
	Prefix string
}

func (m *Model) IsValid() bool {
	// Several constants are presented as models, these have no fields and are of no use
	if m == nil || len(m.Fields) == 0 {
		return false
	}
	return true
}

type ModelField struct {
	Title        string
	Type         *DataType
	Description  string
	Default      interface{}
	Enum         []string
	ItemType     *DataType
	ConstantName *string
	ModelName    *string
	JsonField    string
}

// CSType returns a string containing the C# type name for the ModelField, either describing it as a literal type, a
// specific model type, or a collection of either.
func (f ModelField) CSType(models Models) *string {
	if f.Type == nil {
		return nil
	}

	switch *f.Type {
	case DataTypeModel:
		if f.ModelName == nil {
			return nil
		}

		if models.Found(*f.ModelName) && models[*f.ModelName].IsValid() {
			return pointerTo(fmt.Sprintf("%sModel", *f.ModelName))
		}

	case DataTypeArray:
		if f.ModelName != nil {
			if models.Found(*f.ModelName) && models[*f.ModelName].IsValid() {
				return pointerTo(fmt.Sprintf("List<%sModel>", *f.ModelName))
			}
		}

		if f.ConstantName != nil {
			return pointerTo(fmt.Sprintf("List<%sConstant>", *f.ConstantName))
		}

		if f.ItemType != nil {
			if itemCSType := f.ItemType.CSType(); itemCSType != nil {
				return pointerTo(fmt.Sprintf("List<%s>", *itemCSType))
			}
		}

		return nil

	case DataTypeString:
		if f.ConstantName != nil {
			return pointerTo(fmt.Sprintf("%sConstant", *f.ConstantName))
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

// CSType returns a string containing the C# type name for the DataType. We intentionally consolidate
// some of these (ints and floats all the same size) to ease downstream implementation.
func (ft DataType) CSType() *string {
	csType := ""
	switch ft {
	case DataTypeString, DataTypeBase64, DataTypeDuration, DataTypeUuid:
		csType = "string"
	case DataTypeInteger64, DataTypeInteger32, DataTypeInteger16, DataTypeInteger8:
		csType = "int"
	case DataTypeIntegerUnsigned64, DataTypeIntegerUnsigned32, DataTypeIntegerUnsigned16, DataTypeIntegerUnsigned8:
		csType = "uint"
	case DataTypeFloat64, DataTypeFloat32:
		csType = "float"
	case DataTypeBool:
		csType = "bool"
	case DataTypeDate, DataTypeDateTime, DataTypeTime:
		csType = "DateTime"
	case DataTypeBinary:
		csType = "RawFile"
	}

	// Fall back to string where the type is not known
	if csType == "" {
		csType = "string"
	}

	return &csType
}

// fieldType parses the schemaType and schemaFormat from the OpenAPI spec for a given field, and returns the appropriate DataType
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

func parseCommonModels(schemas openapi3.Schemas) (models Models, err error) {
	models = make(Models)
	for modelName, schemaRef := range schemas {
		name := cleanName(modelName)
		if schemaRef.Value != nil {
			var f *flattenedSchema
			if f, _ = flattenSchemaRef(schemaRef, nil); f != nil {
				models = parseSchemas(*f, name, models, true)
			}
		}
	}

	return
}

type flattenedSchema struct {
	Schemas openapi3.Schemas
	Prefix  string
	Title   string
	Type    string
	Format  string
	Enum    []interface{}
}

// flattenSchemaRef attempts to recursively parse and flatten the provided *openapi3.Schema and returns a flattenedSchema
// which is much more convenient to inspect for types. The returned map[string]bool is used when recursing to track
// Refs which have been observed in order to avoid infinite recursion, and is usually not interesting to the caller.
func flattenSchemaRef(schemaRef *openapi3.SchemaRef, seenRefs map[string]bool) (*flattenedSchema, map[string]bool) {
	if seenRefs == nil {
		seenRefs = make(map[string]bool)
	}

	if schemaRef.Value == nil {
		return nil, seenRefs
	}

	prefix := ""
	title := ""
	titleFromRef := false
	if strings.HasPrefix(schemaRef.Ref, refPrefix) {
		ref := schemaRef.Ref[len(refPrefix):]
		if i := strings.LastIndex(ref, "."); i > 0 {
			prefix = strings.Title(cleanName(ref[0:i]))
		}
		title = strings.Title(cleanName(ref))
		titleFromRef = true
	}
	schema := schemaRef.Value
	schemas := make(openapi3.Schemas, 0)
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
			if title == "" && strings.HasPrefix(r.Ref, refPrefix) {
				ref := r.Ref[len(refPrefix):]
				if i := strings.LastIndex(ref, "."); i > 0 {
					prefix = strings.Title(cleanName(ref[0:i]))
				}
				title = strings.Title(cleanName(ref))
			}
		}

		if r.Value != nil {
			var result *flattenedSchema
			result, seenRefs = flattenSchemaRef(r, seenRefs)
			if title == "" && result.Title != "" {
				title = strings.Title(cleanName(result.Title))
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
					if !titleFromRef && strings.HasPrefix(r.Ref, refPrefix) {
						ref := r.Ref[len(refPrefix):]
						if i := strings.LastIndex(ref, "."); i > 0 {
							prefix = strings.Title(cleanName(ref[0:i]))
						}
						title = strings.Title(cleanName(ref))
						titleFromRef = true
					}
				}

				if r.Value != nil {
					var result *flattenedSchema
					result, seenRefs = flattenSchemaRef(r, seenRefs)
					if !titleFromRef && result.Title != "" {
						title = strings.Title(cleanName(result.Title))
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
					if !titleFromRef && strings.HasPrefix(r.Ref, refPrefix) {
						ref := r.Ref[len(refPrefix):]
						if i := strings.LastIndex(ref, "."); i > 0 {
							prefix = strings.Title(cleanName(ref[0:i]))
						}
						title = strings.Title(cleanName(ref))
						titleFromRef = true
					}
				}

				if r.Value != nil {
					var result *flattenedSchema
					result, seenRefs = flattenSchemaRef(r, seenRefs)
					if !titleFromRef && result.Title != "" {
						title = strings.Title(cleanName(result.Title))
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

	// TODO: may need to prefer innermost title
	if schema.Title != "" {
		title = strings.Title(cleanName(schema.Title))
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

	return &flattenedSchema{
		Schemas: schemas,
		Prefix:  prefix,
		Title:   title,
		Type:    typ,
		Format:  format,
		Enum:    enum,
	}, seenRefs
}

// parseSchemas inspects the provided flattenedSchema to parse out the fields for the provided modelName, optionally
// marking it as a common model. The provided Models (map[string]Model) is mutated to append the new model and its fields.
// Fields having the type of another model are parsed recursively to extract all known models that may not be directly
// referenced in the root schema.
func parseSchemas(input flattenedSchema, modelName string, models Models, common bool) Models {
	if _, ok := models[modelName]; ok {
		return models
	}

	model := Model{
		Fields: make(map[string]*ModelField),
		Common: common,
		Prefix: input.Prefix,
	}

	// Add to models map before descending, to prevent recursion
	models[modelName] = &model

	for jsonField, schemaRef := range input.Schemas {
		if schema := schemaRef.Value; schema != nil {
			field := ModelField{
				Title:       strings.Title(jsonField),
				Description: schema.Description,
				Default:     schema.Default,
				Enum:        parseEnum(schema.Enum),
				JsonField:   jsonField,
			}

			if field.Title == "" {
				continue
			}

			result, _ := flattenSchemaRef(schemaRef, nil)

			if result != nil && len(result.Enum) > 0 && len(field.Enum) == 0 {
				field.Enum = parseEnum(result.Enum)
			}

			if result != nil && result.Title != "" && result.Schemas != nil {
				if _, ok := models[result.Title]; !ok {
					models = parseSchemas(*result, result.Title, models, common)
				}
				field.ModelName = &result.Title
			}

			if schema.Items != nil && schema.Items.Value != nil && schema.Items.Value.Type != "" {
				field.ItemType = fieldType(schema.Items.Value.Type, schema.Items.Value.Format, field.ModelName != nil)
			}

			if result != nil && schema.Type == "" && schema.Format == "" && (result.Type != "" || result.Format != "") {
				field.Type = fieldType(result.Type, result.Format, field.ModelName != nil)
			} else {
				field.Type = fieldType(schema.Type, schema.Format, field.ModelName != nil)
			}

			if result != nil && field.Type != nil && *field.Type == DataTypeArray && len(field.Enum) > 0 && (result.Type != "" || result.Format != "") {
				field.ItemType = fieldType(result.Type, result.Format, field.ModelName != nil)
			}

			if ((field.Type != nil && *field.Type == DataTypeString) || (field.ItemType != nil && *field.ItemType == DataTypeString)) && len(field.Enum) > 0 {
				field.ConstantName = pointerTo(modelName + field.Title)
			}

			model.Fields[cleanName(jsonField)] = &field
		}
	}

	return models
}

// parseEnum returns a slice of sanitized enum values (which are always strings)
func parseEnum(input []interface{}) []string {
	out := make([]string, 0)
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
