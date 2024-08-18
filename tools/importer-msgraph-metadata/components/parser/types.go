// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package parser

import (
	"fmt"
	"strings"

	"github.com/getkin/kin-openapi/openapi3"
	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/importer-msgraph-metadata/components/normalize"
	"github.com/hashicorp/pandora/tools/importer-msgraph-metadata/internal/logging"
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

const RefPrefix = "#/components/schemas/"

type Constants map[string]*Constant
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
func (m Models) MergeDependants(allModels Models, modelName string, includeCommon bool) error {
	if !allModels.Found(modelName) {
		return fmt.Errorf("model not found: %q", modelName)
	}

	if _, ok := m[modelName]; !ok {
		if !includeCommon && allModels[modelName].Common {
			return nil
		}
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

		if err := m.MergeDependants(allModels, *field.ModelName, includeCommon); err != nil {
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

type Constant struct {
	Enum []string
	Type *DataType
}

type Model struct {
	Fields          map[string]*ModelField
	Common          bool
	Prefix          string
	TypeField       *string
	TypeValue       *string
	ParentModelName *string
}

func (m *Model) IsValid() bool {
	// Several constants are presented as models, these have no fields and are of no use
	if m == nil || len(m.Fields) == 0 {
		return false
	}
	return true
}

func (m *Model) DataApiSdkModel(models Models) (*sdkModels.SDKModel, error) {
	sdkFields := make(map[string]sdkModels.SDKField)
	for fieldName, field := range m.Fields {
		objectDefinition, err := field.DataApiSdkObjectDefinition(models)
		if err != nil {
			return nil, err
		}

		if objectDefinition == nil {
			logging.Warnf("Could not determine SDKObjectDefinition for field %q, skipping", fieldName)
			continue
		}

		optional := true
		required := false
		if field.Required {
			optional = false
			required = true
		}

		sdkFields[fieldName] = sdkModels.SDKField{
			ContainsDiscriminatedValue: field.DiscriminatedValue,
			DateFormat:                 nil,
			Description:                field.Description,
			JsonName:                   field.JsonField,
			ObjectDefinition:           *objectDefinition,

			Optional:  optional,
			ReadOnly:  field.ReadOnly,
			Required:  required,
			Sensitive: false,
		}
	}

	if len(sdkFields) == 0 {
		return nil, nil
	}

	return &sdkModels.SDKModel{
		DiscriminatedValue:                    m.TypeValue,
		FieldNameContainingDiscriminatedValue: m.TypeField,
		Fields:                                sdkFields,
		ParentTypeName:                        m.ParentModelName,
	}, nil
}

type ModelField struct {
	Title              string
	Type               *DataType
	Description        string
	Default            interface{}
	Required           bool
	ReadOnly           bool
	WriteOnly          bool
	Nullable           bool
	AllowEmptyValue    bool
	DiscriminatedValue bool
	ItemType           *DataType
	ConstantName       *string
	ModelName          *string
	JsonField          string
}

func (f ModelField) DataApiSdkObjectDefinition(models Models) (*sdkModels.SDKObjectDefinition, error) {
	if f.Type == nil {
		return nil, fmt.Errorf("field %q has no Type", f.Title)
	}

	switch *f.Type {
	case DataTypeModel:
		if f.ModelName == nil {
			return nil, fmt.Errorf("field type Model encountered without model name")
		}

		if !models.Found(*f.ModelName) {
			return nil, fmt.Errorf("field type Model encountered with unknown referenced model")
		}

		if !models[*f.ModelName].IsValid() {
			logging.Warnf("Skipping field %q with type Model as the referenced model %q is invalid", f.Title, *f.ModelName)
		}

		return &sdkModels.SDKObjectDefinition{
			Nullable:                  f.Nullable,
			ReferenceName:             f.ModelName,
			ReferenceNameIsCommonType: pointer.To(models[*f.ModelName].Common),
			Type:                      sdkModels.ReferenceSDKObjectDefinitionType,
		}, nil

	case DataTypeArray:
		if f.ModelName != nil {
			if !models.Found(*f.ModelName) {
				return nil, fmt.Errorf("field type Array[Model] encountered with unknown referenced model")
			}

			if !models[*f.ModelName].IsValid() {
				logging.Warnf("Skipping field %q with type Array[Model] as the referenced model %q is invalid", f.Title, *f.ModelName)
			}

			return &sdkModels.SDKObjectDefinition{
				NestedItem: &sdkModels.SDKObjectDefinition{
					ReferenceName:             f.ModelName,
					ReferenceNameIsCommonType: pointer.To(models[*f.ModelName].Common),
					Type:                      sdkModels.ReferenceSDKObjectDefinitionType,
				},
				Nullable:      f.Nullable,
				ReferenceName: nil,
				Type:          sdkModels.ListSDKObjectDefinitionType,
			}, nil
		}

		if f.ConstantName != nil {
			// TODO validate constant exists
			return &sdkModels.SDKObjectDefinition{
				NestedItem: &sdkModels.SDKObjectDefinition{
					ReferenceName: f.ConstantName,
					Type:          sdkModels.ReferenceSDKObjectDefinitionType,
				},
				Nullable: f.Nullable,
				Type:     sdkModels.ListSDKObjectDefinitionType,
			}, nil
		}

		if f.ItemType != nil {
			return &sdkModels.SDKObjectDefinition{
				NestedItem: &sdkModels.SDKObjectDefinition{
					Type: f.ItemType.DataApiSdkObjectDefinitionType(),
				},
				Nullable: f.Nullable,
				Type:     sdkModels.ListSDKObjectDefinitionType,
			}, nil
		}

		// Unknown types should be []interface{}
		return &sdkModels.SDKObjectDefinition{
			NestedItem: &sdkModels.SDKObjectDefinition{
				Type: sdkModels.RawObjectSDKObjectDefinitionType,
			},
			Nullable: f.Nullable,
			Type:     sdkModels.ListSDKObjectDefinitionType,
		}, nil
	}

	if f.ConstantName != nil {
		return &sdkModels.SDKObjectDefinition{
			Nullable:      f.Nullable,
			ReferenceName: f.ConstantName,
			Type:          sdkModels.ReferenceSDKObjectDefinitionType,
		}, nil
	}

	return &sdkModels.SDKObjectDefinition{
		Nullable: f.Nullable,
		Type:     f.Type.DataApiSdkObjectDefinitionType(),
	}, nil
}

type DataType uint8

const (
	DataTypeUnknown DataType = iota // zero value is used for comparisons, don't remove
	DataTypeArray
	DataTypeBase64
	DataTypeBinary
	DataTypeBool
	DataTypeCsv
	DataTypeDate
	DataTypeDateTime
	DataTypeDuration
	DataTypeFloat32
	DataTypeFloat64
	DataTypeInteger16
	DataTypeInteger32
	DataTypeInteger64
	DataTypeInteger8
	DataTypeIntegerUnsigned16
	DataTypeIntegerUnsigned32
	DataTypeIntegerUnsigned64
	DataTypeIntegerUnsigned8
	DataTypeModel
	DataTypeString
	DataTypeTime
	DataTypeUuid
)

func (ft DataType) DataApiSdkObjectDefinitionType() sdkModels.SDKObjectDefinitionType {
	switch ft {
	case DataTypeString, DataTypeBase64, DataTypeDuration, DataTypeUuid:
		return sdkModels.StringSDKObjectDefinitionType
	case DataTypeInteger64, DataTypeInteger32, DataTypeInteger16, DataTypeInteger8, DataTypeIntegerUnsigned64,
		DataTypeIntegerUnsigned32, DataTypeIntegerUnsigned16, DataTypeIntegerUnsigned8:
		return sdkModels.IntegerSDKObjectDefinitionType
	case DataTypeFloat64, DataTypeFloat32:
		return sdkModels.FloatSDKObjectDefinitionType
	case DataTypeBool:
		return sdkModels.BooleanSDKObjectDefinitionType
	case DataTypeCsv:
		return sdkModels.CSVSDKObjectDefinitionType
	case DataTypeDate, DataTypeDateTime, DataTypeTime:
		return sdkModels.DateTimeSDKObjectDefinitionType
	case DataTypeBinary:
		return sdkModels.RawFileSDKObjectDefinitionType
	}

	// Fall back to `interface{}` where the type is not known
	return sdkModels.RawObjectSDKObjectDefinitionType
}

func (ft DataType) DataApiSdkOperationOptionObjectDefinitionType() sdkModels.SDKOperationOptionObjectDefinitionType {
	switch ft {
	case DataTypeString, DataTypeBase64, DataTypeDuration, DataTypeUuid:
		return sdkModels.StringSDKOperationOptionObjectDefinitionType
	case DataTypeInteger64, DataTypeInteger32, DataTypeInteger16, DataTypeInteger8, DataTypeIntegerUnsigned64,
		DataTypeIntegerUnsigned32, DataTypeIntegerUnsigned16, DataTypeIntegerUnsigned8:
		return sdkModels.IntegerSDKOperationOptionObjectDefinitionType
	case DataTypeFloat64, DataTypeFloat32:
		return sdkModels.FloatSDKOperationOptionObjectDefinitionType
	case DataTypeBool:
		return sdkModels.BooleanSDKOperationOptionObjectDefinitionType
	case DataTypeCsv:
		return sdkModels.CSVSDKOperationOptionObjectDefinitionType
	case DataTypeDate, DataTypeDateTime, DataTypeTime:
		return sdkModels.StringSDKOperationOptionObjectDefinitionType
	case DataTypeBinary:
		return sdkModels.StringSDKOperationOptionObjectDefinitionType
	}

	// Fall back to string where the type is not known
	return sdkModels.StringSDKOperationOptionObjectDefinitionType
}

// FieldType parses the schemaType and schemaFormat from the OpenAPI spec for a given field, and returns the appropriate DataType
func FieldType(schemaType, schemaFormat string, hasModel bool) *DataType {
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

func Common(schemas openapi3.Schemas) (models Models, constants Constants, err error) {
	models = make(Models)
	constants = make(Constants)
	for modelName, schemaRef := range schemas {
		name := normalize.CleanName(modelName)
		if schemaRef.Value != nil {
			var f *flattenedSchema
			if f, _ = FlattenSchemaRef(schemaRef, nil); f != nil {
				models, constants = Schemas(*f, name, models, constants, true)
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

// FlattenSchemaRef attempts to recursively parse and flatten the provided *openapi3.Schema and returns a flattenedSchema
// which is much more convenient to inspect for types. The returned map[string]bool is used when recursing to track
// Refs which have been observed in order to avoid infinite recursion, and is usually not interesting to the caller.
func FlattenSchemaRef(schemaRef *openapi3.SchemaRef, seenRefs map[string]bool) (*flattenedSchema, map[string]bool) {
	if seenRefs == nil {
		seenRefs = make(map[string]bool)
	}

	if schemaRef.Value == nil {
		return nil, seenRefs
	}

	prefix := ""
	title := ""
	titleFromRef := false
	if strings.HasPrefix(schemaRef.Ref, RefPrefix) {
		ref := schemaRef.Ref[len(RefPrefix):]
		if i := strings.LastIndex(ref, "."); i > 0 {
			prefix = normalize.CleanName(ref[0:i])
		}
		title = normalize.CleanName(ref)
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
			if title == "" && strings.HasPrefix(r.Ref, RefPrefix) {
				ref := r.Ref[len(RefPrefix):]
				if i := strings.LastIndex(ref, "."); i > 0 {
					prefix = normalize.CleanName(ref[0:i])
				}
				title = normalize.CleanName(ref)
			}
		}

		if r.Value != nil {
			var result *flattenedSchema
			result, seenRefs = FlattenSchemaRef(r, seenRefs)
			if title == "" && result.Title != "" {
				title = normalize.CleanName(result.Title)
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
					if !titleFromRef && strings.HasPrefix(r.Ref, RefPrefix) {
						ref := r.Ref[len(RefPrefix):]
						if i := strings.LastIndex(ref, "."); i > 0 {
							prefix = normalize.CleanName(ref[0:i])
						}
						title = normalize.CleanName(ref)
						titleFromRef = true
					}
				}

				if r.Value != nil {
					var result *flattenedSchema
					result, seenRefs = FlattenSchemaRef(r, seenRefs)
					if !titleFromRef && result.Title != "" {
						title = normalize.CleanName(result.Title)
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
					if !titleFromRef && strings.HasPrefix(r.Ref, RefPrefix) {
						ref := r.Ref[len(RefPrefix):]
						if i := strings.LastIndex(ref, "."); i > 0 {
							prefix = normalize.CleanName(ref[0:i])
						}
						title = normalize.CleanName(ref)
						titleFromRef = true
					}
				}

				if r.Value != nil {
					var result *flattenedSchema
					result, seenRefs = FlattenSchemaRef(r, seenRefs)
					if !titleFromRef && result.Title != "" {
						title = normalize.CleanName(result.Title)
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

		if schema.OneOf != nil {
			for _, r := range schema.OneOf {
				if r.Ref != "" {
					for s := range seenRefs {
						if s == r.Ref {
							continue
						}
					}
					seenRefs[r.Ref] = true
					if !titleFromRef && strings.HasPrefix(r.Ref, RefPrefix) {
						ref := r.Ref[len(RefPrefix):]
						if i := strings.LastIndex(ref, "."); i > 0 {
							prefix = normalize.CleanName(ref[0:i])
						}
						title = normalize.CleanName(ref)
						titleFromRef = true
					}
				}

				if r.Value != nil {
					var result *flattenedSchema
					result, seenRefs = FlattenSchemaRef(r, seenRefs)
					if !titleFromRef && result.Title != "" {
						title = normalize.CleanName(result.Title)
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
		title = normalize.CleanName(schema.Title)
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

// Schemas inspects the provided flattenedSchema to parse out the fields for the provided modelName, optionally
// marking it as a common model. The provided Models (map[string]Model) is mutated to append the new model and its fields.
// Fields having the type of another model are parsed recursively to extract all known models that may not be directly
// referenced in the root schema.
func Schemas(input flattenedSchema, name string, models Models, constants Constants, common bool) (Models, Constants) {
	if _, ok := models[name]; ok {
		return models, constants
	}

	// Check if this is a constant
	if input.Schemas == nil && len(input.Enum) > 0 {
		constant := Constant{
			Enum: parseEnum(input.Enum),
			Type: FieldType(input.Type, input.Format, false),
		}

		constants[name] = &constant
		return models, constants
	}

	// If there are no schemas, this is not a valid model and is likely a custom type which we don't currently use, e.g. ODataCountResponse
	if input.Schemas == nil {
		return models, constants
	}

	// Add an explicit ODataId and ODataType field to each model, since it is inconsistently defined in the API specs.
	// This won't be valid for every model, but it's impossible to tell which models support them, and it's effectively
	// harmless to leave these in so long as they have the `omitempty` struct tag in the generated SDK.
	model := Model{
		Fields: map[string]*ModelField{
			"ODataId": {
				Title:       "ODataId",
				Description: "The OData ID of this entity",
				Type:        pointer.To(DataTypeString),
				Default:     "",
				JsonField:   "@odata.id",
			},
			"ODataType": {
				Title:       "ODataType",
				Description: "The OData Type of this entity",
				Type:        pointer.To(DataTypeString),
				Default:     "",
				JsonField:   "@odata.type",
			},
		},
		Common: common,
		Prefix: input.Prefix,
	}

	// Add to models map before descending, to prevent recursion
	models[name] = &model

	for jsonField, schemaRef := range input.Schemas {
		// maintainer note: this is a good place to add a breakpoint for inspecting model fields and constants as they are processed
		// example breakpoint condition: name=="AdministrativeUnit"
		schema := schemaRef.Value
		if schema == nil {
			continue
		}

		field := ModelField{
			Title:           normalize.CleanName(jsonField),
			Description:     schema.Description,
			Default:         schema.Default,
			ReadOnly:        schemaRef.Value.ReadOnly,
			WriteOnly:       schemaRef.Value.WriteOnly,
			Nullable:        schemaRef.Value.Nullable,
			AllowEmptyValue: schemaRef.Value.AllowEmptyValue,
			JsonField:       jsonField,
		}

		// Detect nullable, read-only and requried fields from the description
		if (strings.HasPrefix(schema.Description, "Nullable.") || strings.Contains(schema.Description, " Nullable.")) && !strings.Contains(strings.ToLower(schema.Description), "not nullable.") {
			field.Nullable = true
		}
		if strings.HasPrefix(schema.Description, "Read-only.") || strings.Contains(schema.Description, " Read-only.") {
			field.ReadOnly = true
		}
		if strings.HasPrefix(schema.Description, "Required.") || strings.Contains(schema.Description, " Required.") {
			field.Required = true
		}

		if field.Title == "" {
			continue
		}

		result, _ := FlattenSchemaRef(schemaRef, nil)

		// Determine any enumeration for the field
		enum := parseEnum(schema.Enum)
		if result != nil && len(result.Enum) > 0 && len(enum) == 0 {
			enum = parseEnum(result.Enum)
		}

		// Find the corresponding model when the field refers to it, and set the model name for the field
		if result != nil && result.Title != "" && result.Schemas != nil {
			if _, ok := models[result.Title]; !ok {
				models, constants = Schemas(*result, result.Title, models, constants, common)
			}
			field.ModelName = &result.Title
		}

		// Handle items for collections
		if schema.Items != nil && schema.Items.Value != nil {
			itemsResult, _ := FlattenSchemaRef(schema.Items, nil)

			// Determine any type for the items
			if schema.Items.Value.Type != "" || schema.Items.Value.Format != "" {
				field.ItemType = FieldType(schema.Items.Value.Type, schema.Items.Value.Format, field.ModelName != nil)
			}

			// Find the corresponding model when the field (items) refers to it, and set the model name for the field items
			if itemsResult != nil && itemsResult.Title != "" && itemsResult.Type == "object" {
				if _, ok := models[result.Title]; !ok {
					models, constants = Schemas(*result, result.Title, models, constants, common)
				}
				field.ModelName = &result.Title
			}
		}

		// Match the field type to the referenced object, or set a basic type
		if result != nil && schema.Type == "" && schema.Format == "" && (result.Type != "" || result.Format != "") {
			field.Type = FieldType(result.Type, result.Format, field.ModelName != nil)
		} else {
			field.Type = FieldType(schema.Type, schema.Format, field.ModelName != nil)
		}

		// Set the field type for enums; typically strings for constants, but could be any valid type
		if result != nil && field.Type != nil && *field.Type == DataTypeArray && len(enum) > 0 && (result.Type != "" || result.Format != "") {
			field.ItemType = FieldType(result.Type, result.Format, field.ModelName != nil)
		}

		if ((field.Type != nil && *field.Type == DataTypeString) || (field.ItemType != nil && *field.ItemType == DataTypeString)) && len(enum) > 0 {
			// Despite being "fully qualified", type names are not unique in MS Graph, so we prefix them with the model name to provide some namespacing.
			// Though we attempt to de-duplicate, this does lead to some excessively long constant names, it is what it is.
			constantName := name
			if result.Title != "" {
				// use provided ref name if present
				constantName += result.Title
			} else {
				// otherwise use the field name
				constantName += field.Title
			}
			constantName = normalize.DeDuplicateName(constantName)
			constantName = normalize.Singularize(constantName)

			field.ConstantName = pointer.To(constantName)

			// Add the enumeration as a constant
			constants[constantName] = &Constant{
				Enum: enum,
				Type: field.Type,
			}
		}

		if field.Type == nil {
			logging.Warnf("Skipping field %q in model %q because Type is nil", name, field.Title)
			continue
		}

		// Insert an "@odata.bind" field where a field or collection refers to a DirectoryObject. The MS Graph
		// OpenAPI spec unfortunately does not document relationships between entities.
		if field.ModelName != nil && strings.EqualFold(*field.ModelName, "DirectoryObject") {
			bindFieldName := fmt.Sprintf("%s_ODataBind", normalize.CleanName(jsonField))

			description := ""
			if *field.Type == DataTypeArray {
				description = fmt.Sprintf("List of OData IDs for `%s` to bind to this entity", normalize.CleanName(jsonField))
			} else {
				description = fmt.Sprintf("OData ID for `%s` to bind to this entity", normalize.CleanName(jsonField))
			}

			var fieldType, itemType *DataType

			fieldType = pointer.To(DataTypeString)
			if *field.Type == DataTypeArray {
				fieldType = pointer.To(DataTypeArray)
				itemType = pointer.To(DataTypeString)
			}

			model.Fields[bindFieldName] = &ModelField{
				Title:       bindFieldName,
				Description: description,
				Type:        fieldType,
				ItemType:    itemType,
				JsonField:   fmt.Sprintf("%s@odata.bind", jsonField),
			}
		}

		model.Fields[normalize.CleanName(jsonField)] = &field
	}

	return models, constants
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
