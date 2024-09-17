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

/* =======================
   kin-openapi3 cheatsheet
   =======================
   Schemas is a map[string]*SchemaRef
   SchemaRef is a struct{Ref, Value} where Ref is a string, Value is a *Schema
   The Ref string (after trimming) indicates a Schemas map key to follow/inherit
   Schema has Properties which is a nested Schemas
   Schema has AllOf, AnyOf or OneOf which are SchemaRefs
   SchemaRefs is a []*SchemaRef
   Schemas is a model
   SchemaRefs, SchemaRef lead to a Schema or other another SchemaRef
   Schema leads to SchemaRefs and Schemas
*/

const RefPrefix = "#/components/schemas/"

func TrimRefPrefix(ref string) string {
	if strings.HasPrefix(ref, RefPrefix) {
		return ref[len(RefPrefix):]
	}
	return ref
}

type Constants map[string]*Constant
type Models map[string]*Model

// Found returns true when the provided schemaName was found in the Constants map
func (c Constants) Found(schemaName string) bool {
	// Safety check, don't allow an empty constant name
	if schemaName == "" {
		return false
	}

	if constant, ok := c[schemaName]; ok && constant != nil {
		return true
	}

	return false
}

// Found returns true when the provided schemaName was found in the Models map
func (m Models) Found(schemaName string) bool {
	// Safety check, don't allow an empty model name
	if schemaName == "" {
		return false
	}

	if model, ok := m[schemaName]; ok && model != nil {
		return true
	}

	return false
}

type Constant struct {
	// The name of this constant from the spec (not normalized)
	Name string

	// Whether this constant is a common type
	Common bool

	// The accepted values for this constant
	Enum []string

	// The data type for this constant (currently only supports strings)
	Type *DataType
}

type Model struct {
	// The type name of this model from the spec (not normalized)
	Name string

	// Fields that comprise this model
	Fields map[string]*ModelField

	// Whether this model is a common type
	Common bool

	// Whether this model has known child models
	Parent bool

	// For parent models, the field name containing the discriminated type value
	TypeField *string

	// For child models, the type value that specifies this model
	TypeValue *string

	// For child models, the name of the parent model
	ParentModel *string
}

func (m *Model) AppendDefaultFields() {
	for jsonName, fieldDetails := range defaultModelFields() {
		if _, ok := m.Fields[jsonName]; !ok {
			m.Fields[jsonName] = fieldDetails
		}
	}
}

// DataApiSdkModel converts the internal ModelField representation to a Data API SDKModel, so it can be persisted to the Data
// API Definitions. It's necessary to provide Models and Constants so that references (both fields and model ancestry) can be resolved.
func (m *Model) DataApiSdkModel(models Models, constants Constants) (*sdkModels.SDKModel, error) {
	sdkFields := make(map[string]sdkModels.SDKField)
	for jsonName, field := range m.Fields {
		objectDefinition, err := field.DataApiSdkObjectDefinition(models, constants)
		if err != nil {
			return nil, err
		}

		if objectDefinition == nil {
			logging.Warnf("Could not determine SDKObjectDefinition for field %q, skipping", jsonName)
			continue
		}

		optional := true
		required := false
		if field.Required {
			optional = false
			required = true
		}

		sdkFields[field.Name] = sdkModels.SDKField{
			DateFormat:       nil,
			Description:      field.Description,
			JsonName:         jsonName,
			ObjectDefinition: *objectDefinition,

			ContainsDiscriminatedValue: field.DiscriminatedValue,

			Optional:  optional,
			ReadOnly:  field.ReadOnly,
			Required:  required,
			Sensitive: false,
		}
	}

	if len(sdkFields) == 0 {
		return nil, nil
	}

	var parentTypeName *string
	if m.ParentModel != nil {
		parentTypeName = pointer.To(normalize.CleanName(*m.ParentModel))
	}

	return &sdkModels.SDKModel{
		Fields: sdkFields,

		IsParent:                              m.Parent,
		DiscriminatedValue:                    m.TypeValue,
		FieldNameContainingDiscriminatedValue: m.TypeField,
		ParentTypeName:                        parentTypeName,
	}, nil
}

type ModelField struct {
	// The name of this field
	Name string

	// The internal type for this field
	Type *DataType

	// The internal type for items, when this field type is DataTypeArray
	ItemType *DataType

	// Optional description which can be added to the generated SDK model as a comment
	Description string

	// The default value for this field
	Default any

	// Whether the field is required
	Required bool

	// Read-only fields should be omitted during marshalling in the generated SDK
	ReadOnly bool

	// Whether the field value can be a JSON null
	Nullable bool

	// Whether this field contains the discriminated type for a child model
	DiscriminatedValue bool

	// The name of a referenced model or constant, noting that this should be the full type name from the spec prior to normalizing
	ReferenceName *string

	// This is parsed from the spec but otherwise currently unused
	WriteOnly       bool
	AllowEmptyValue bool
}

// DataApiSdkObjectDefinition converts the internal ModelField representation to a Data API SDKObjectDefinition, so it can be
// persisted to the Data API Definitions. It's necessary to provide Models and Constants so that references can be resolved.
func (f ModelField) DataApiSdkObjectDefinition(models Models, constants Constants) (*sdkModels.SDKObjectDefinition, error) {
	if f.Type == nil {
		return nil, fmt.Errorf("field %q has no Type", f.Name)
	}

	switch *f.Type {
	case DataTypeReference:
		if f.ReferenceName == nil {
			return nil, fmt.Errorf("field type Reference encountered without ReferenceName")
		}

		if models.Found(*f.ReferenceName) {
			return &sdkModels.SDKObjectDefinition{
				Nullable:                  f.Nullable,
				ReferenceName:             pointer.To(normalize.CleanName(*f.ReferenceName)),
				ReferenceNameIsCommonType: pointer.To(models[*f.ReferenceName].Common),
				Type:                      sdkModels.ReferenceSDKObjectDefinitionType,
			}, nil
		}

		if constants.Found(*f.ReferenceName) {
			return &sdkModels.SDKObjectDefinition{
				Nullable:                  f.Nullable,
				ReferenceName:             pointer.To(normalize.CleanName(*f.ReferenceName)),
				ReferenceNameIsCommonType: pointer.To(constants[*f.ReferenceName].Common),
				Type:                      sdkModels.ReferenceSDKObjectDefinitionType,
			}, nil
		}

		return nil, fmt.Errorf("field type Reference encountered with unknown referenced model/constant")

	case DataTypeArray:
		if f.ReferenceName != nil {
			if models.Found(*f.ReferenceName) {
				return &sdkModels.SDKObjectDefinition{
					NestedItem: &sdkModels.SDKObjectDefinition{
						ReferenceName:             pointer.To(normalize.CleanName(*f.ReferenceName)),
						ReferenceNameIsCommonType: pointer.To(models[*f.ReferenceName].Common),
						Type:                      sdkModels.ReferenceSDKObjectDefinitionType,
					},
					Nullable:      f.Nullable,
					ReferenceName: nil,
					Type:          sdkModels.ListSDKObjectDefinitionType,
				}, nil
			}

			if constants.Found(*f.ReferenceName) {
				return &sdkModels.SDKObjectDefinition{
					NestedItem: &sdkModels.SDKObjectDefinition{
						ReferenceName:             pointer.To(normalize.CleanName(*f.ReferenceName)),
						ReferenceNameIsCommonType: pointer.To(constants[*f.ReferenceName].Common),
						Type:                      sdkModels.ReferenceSDKObjectDefinitionType,
					},
					Nullable:      f.Nullable,
					ReferenceName: nil,
					Type:          sdkModels.ListSDKObjectDefinitionType,
				}, nil
			}

			return nil, fmt.Errorf("field type Array[Reference] encountered with unknown referenced model/constant")
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

	if f.ReferenceName != nil {
		return nil, fmt.Errorf("field that is not a Reference or Array[Reference] encountered with ReferenceName")
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
	DataTypeReference
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
func FieldType(schemaType, schemaFormat string, hasReference bool) *DataType {
	var ret DataType

	if hasReference {
		ret = DataTypeReference
		return &ret
	}

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

	return nil
}

func ModelsAndConstants(schemas openapi3.Schemas) (Models, Constants, error) {
	models := make(Models)
	constants := make(Constants)

	for schemaName, schemaRef := range schemas {
		if models.Found(schemaName) {
			return nil, nil, fmt.Errorf("model %q already encountered", schemaName)
		}
		if constants.Found(schemaName) {
			return nil, nil, fmt.Errorf("constant %q already encountered", schemaName)
		}

		model, constant, err := ModelOrConstant(schemaName, schemaRef, true)
		if err != nil {
			return nil, nil, err
		}

		if model != nil {
			models[schemaName] = model
			models[schemaName].AppendDefaultFields()
		}

		if constant != nil {
			constants[schemaName] = constant
		}
	}

	// Now iterate models, mark parent models as such and populate discriminated children
	for schemaName, model := range models {
		if model.ParentModel == nil {
			continue
		}

		parentModel, ok := models[*model.ParentModel]
		if !ok {
			return nil, nil, fmt.Errorf("parent model %q was not found for model %q", *model.ParentModel, schemaName)
		}

		parentModel.Fields["@odata.type"].DiscriminatedValue = true
		parentModel.Parent = true
		parentModel.TypeField = pointer.To("ODataType")
		model.TypeField = pointer.To("ODataType")
		model.TypeValue = pointer.To("#" + schemaName)
	}

	return models, constants, nil
}

func ModelOrConstant(schemaName string, schemaRef *openapi3.SchemaRef, common bool) (*Model, *Constant, error) {
	schema := schemaRef.Value
	if schema == nil {
		logging.Tracef("OpenAPI model %q has no schema, skipping", schemaName)
		return nil, nil, nil
	}

	// First check if this is a constant
	if schema.Enum != nil {
		constant := Constant{
			Name:   normalize.CleanName(schemaName),
			Common: common,
			Enum:   parseEnum(schema.Enum),
			Type:   FieldType(schema.Type, schema.Format, false),
		}

		return nil, &constant, nil
	}

	// Proceed to build a model
	model := Model{
		Name:   normalize.CleanName(schemaName),
		Fields: make(map[string]*ModelField),
		Common: common,
	}

	if schema.Properties != nil {
		// Simple model with no base type
		for jsonField, fieldDetails := range schema.Properties {
			field, err := modelFieldFromSchemaRef(jsonField, fieldDetails)
			if err != nil {
				return nil, nil, fmt.Errorf("building field %q for model %q: %v", jsonField, schemaName, err)
			}

			if field == nil {
				logging.Warnf("Skipping field %q in model %q", schemaName, jsonField)
				continue
			}

			model.Fields[jsonField] = field
		}

	} else if schema.AllOf != nil {
		// Model with inheritance
		for _, allOf := range schema.AllOf {
			if referencedSchemaName := TrimRefPrefix(allOf.Ref); referencedSchemaName != "" {
				if model.ParentModel != nil {
					return nil, nil, fmt.Errorf("model %q already has a parent model %q, cannot set additional parent %q", schemaName, *model.ParentModel, referencedSchemaName)
				}

				model.ParentModel = &referencedSchemaName
				continue
			}

			if allOf.Value != nil && allOf.Value.Properties != nil {
				for jsonField, fieldDetails := range allOf.Value.Properties {
					field, err := modelFieldFromSchemaRef(jsonField, fieldDetails)
					if err != nil {
						return nil, nil, fmt.Errorf("building field %q for model %q: %v", jsonField, schemaName, err)
					}

					if field == nil {
						logging.Warnf("Skipping field %q in model %q", schemaName, jsonField)
						continue
					}

					model.Fields[jsonField] = field
				}
			}
		}
	}

	return &model, nil, nil
}

func modelFieldFromSchemaRef(jsonField string, fieldSchema *openapi3.SchemaRef) (*ModelField, error) {
	if fieldSchema.Value == nil {
		return nil, fmt.Errorf("field has no definition")
	}

	field := ModelField{
		Name:            normalize.CleanName(jsonField),
		Description:     fieldSchema.Value.Description,
		Default:         fieldSchema.Value.Default,
		ReadOnly:        fieldSchema.Value.ReadOnly,
		WriteOnly:       fieldSchema.Value.WriteOnly,
		Nullable:        fieldSchema.Value.Nullable,
		AllowEmptyValue: fieldSchema.Value.AllowEmptyValue,
	}

	if fieldSchema.Value.AnyOf != nil {
		for _, fieldReference := range fieldSchema.Value.AnyOf {
			if referencedSchemaName := TrimRefPrefix(fieldReference.Ref); referencedSchemaName != "" {
				if field.ReferenceName != nil {
					return nil, fmt.Errorf("reference %q already set, cannot set new reference %q", *field.ReferenceName, referencedSchemaName)
				}

				field.ReferenceName = &referencedSchemaName
			}
		}
	}

	if referencedSchemaName := TrimRefPrefix(fieldSchema.Ref); referencedSchemaName != "" {
		if field.ReferenceName != nil {
			return nil, fmt.Errorf("reference %q already set, cannot set new reference %q", *field.ReferenceName, referencedSchemaName)
		}

		field.ReferenceName = &referencedSchemaName
	}

	field.Type = FieldType(fieldSchema.Value.Type, fieldSchema.Value.Format, field.ReferenceName != nil)

	if items := fieldSchema.Value.Items; items != nil {
		if items.Value != nil && items.Value.AnyOf != nil {
			for _, itemsReference := range items.Value.AnyOf {
				if referencedSchemaName := TrimRefPrefix(itemsReference.Ref); referencedSchemaName != "" {
					if field.ReferenceName != nil {
						return nil, fmt.Errorf("item reference %q already set, cannot set new reference %q", *field.ReferenceName, referencedSchemaName)
					}

					field.ReferenceName = &referencedSchemaName
				}
			}
		}

		if referencedSchemaName := TrimRefPrefix(items.Ref); referencedSchemaName != "" {
			if field.ReferenceName != nil {
				return nil, fmt.Errorf("item reference %q already set, cannot set new reference %q", *field.ReferenceName, referencedSchemaName)
			}

			field.ReferenceName = &referencedSchemaName
		}

		if field.ReferenceName == nil && items.Value == nil {
			return nil, fmt.Errorf("item reference not found and items have no definition")
		}

		field.ItemType = FieldType(items.Value.Type, items.Value.Format, field.ReferenceName != nil)
	}

	// Detect nullable, read-only and required fields from the description, which appears to be reliably auto-generated.
	if (strings.HasPrefix(fieldSchema.Value.Description, "Nullable.") || strings.Contains(fieldSchema.Value.Description, " Nullable.")) && !strings.Contains(strings.ToLower(fieldSchema.Value.Description), "not nullable.") {
		field.Nullable = true
	}
	if strings.HasPrefix(fieldSchema.Value.Description, "Read-only.") || strings.Contains(fieldSchema.Value.Description, " Read-only.") {
		field.ReadOnly = true
	}
	if strings.HasPrefix(fieldSchema.Value.Description, "Required.") || strings.Contains(fieldSchema.Value.Description, " Required.") {
		field.Required = true
	}

	if field.Type == nil {
		return nil, nil
	}

	return &field, nil
}

// defaultModelFields adds an explicit ODataId and ODataType field to each model, since it is inconsistently defined in
// the API specs. This won't be valid for every model, but it's impossible to tell which models support them, and it's
// effectively harmless to leave these in so long as they have the `omitempty` struct tag in the generated SDK.
func defaultModelFields() map[string]*ModelField {
	return map[string]*ModelField{
		"@odata.id": {
			Name:        "ODataId",
			Description: "The OData ID of this entity",
			Type:        pointer.To(DataTypeString),
			Default:     "",
			Required:    false,
			Nullable:    false,
		},
		"@odata.type": {
			Name:        "ODataType",
			Description: "The OData Type of this entity",
			Type:        pointer.To(DataTypeString),
			Default:     "",
			Required:    false,
			Nullable:    false,
		},
	}
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
