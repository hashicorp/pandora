package models

import (
	"github.com/go-openapi/spec"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/cleanup"
)

type AzureApiDefinition struct {
	ServiceName string
	ApiVersion  string
	Resources   map[string]AzureApiResource
}

type AzureApiResource struct {
	Constants   map[string]ConstantDetails
	Models      map[string]ModelDetails
	Operations  map[string]OperationDetails
	ResourceIds map[string]string
}

func (r *AzureApiResource) Normalize() {
	normalizedConstants := make(map[string]ConstantDetails)
	for k, v := range r.Constants {
		name := cleanup.NormalizeName(k)
		normalizedConstants[name] = v
	}
	r.Constants = normalizedConstants

	normalizedModels := make(map[string]ModelDetails)
	for k, v := range r.Models {
		modelName := cleanup.NormalizeName(k)
		fields := make(map[string]FieldDetails)
		for fieldName, fieldVal := range v.Fields {
			normalizedFieldName := cleanup.NormalizeName(fieldName)
			if fieldVal.ConstantReference != nil {
				normalized := cleanup.NormalizeName(*fieldVal.ConstantReference)
				fieldVal.ConstantReference = &normalized
			}

			if fieldVal.ModelReference != nil {
				normalized := cleanup.NormalizeName(*fieldVal.ModelReference)
				fieldVal.ModelReference = &normalized
			}

			fields[normalizedFieldName] = fieldVal
		}

		v.Fields = fields
		normalizedModels[modelName] = v
	}
	r.Models = normalizedModels
}

type OperationDetails struct {
	ApiVersion          *string
	ContentType         string
	ExpectedStatusCodes []int
	LongRunning         bool
	Method              string
	RequestObjectName   *string
	ResponseObjectName  *string
	ResourceIdName      *string
	Uri                 string

	FieldContainingPaginationDetails *string
	Options                          map[string]OperationOption
	UriSuffix                        *string
}

type OperationOption struct {
	FieldType       FieldDefinitionType
	QueryStringName string
	// TODO: support Header names here too in time
	Required bool
}

type ConstantDetails struct {
	Values    map[string]string
	FieldType ConstantFieldType
}

type ConstantFieldType string

const (
	IntegerConstant ConstantFieldType = "int"
	FloatConstant   ConstantFieldType = "float"
	StringConstant  ConstantFieldType = "string"
	UnknownConstant ConstantFieldType = "unknown"
)

type ModelDetails struct {
	Description string
	Fields      map[string]FieldDetails

	// @tombuildsstuff: placeholder until the other branch is merged
	ParentTypeName *string
	TypeHintIn     *string
	TypeHintValue  *string

	// TODO: include ReadOnly, which'll mean we need to generate this on a per-type basis if necessary
}

type FieldDetails struct {
	Type              FieldDefinitionType
	DictValueType     *FieldDefinitionType
	Required          bool
	ReadOnly          bool
	ConstantReference *string
	ModelReference    *string

	// The schema that is referenced by either ConstantReference or ModelReference
	ReferenceSchema *spec.Schema

	Sensitive         bool
	JsonName          string
	ListElementType   *FieldDefinitionType
	ListElementMin    *int64
	ListElementMax    *int64
	ListElementUnique *bool

	// TODO: should we output Description here too?
}

type FieldDefinitionType string

const (
	Boolean                FieldDefinitionType = "bool"
	DateTime               FieldDefinitionType = "datetime"
	Dictionary             FieldDefinitionType = "dictionary"
	Integer                FieldDefinitionType = "int"
	Location               FieldDefinitionType = "location"
	List                   FieldDefinitionType = "list"
	Object                 FieldDefinitionType = "object"
	String                 FieldDefinitionType = "string"
	Tags                   FieldDefinitionType = "tags"
	SystemAssignedIdentity FieldDefinitionType = "system_assigned_identity"
	SystemUserAssignedIdentityList FieldDefinitionType = "system_user_assigned_identity_list"
	SystemUserAssignedIdentityMap FieldDefinitionType = "system_user_assigned_identity_map"
	UserAssignedIdentityList   FieldDefinitionType = "user_assigned_identity_list"
	UserAssignedIdentityMap    FieldDefinitionType = "user_assigned_identity_map"

	// TODO: support this in all of the places
	Float FieldDefinitionType = "float"

	Unknown FieldDefinitionType = "unknown"
)

var FieldDefinitionPrimaryTypes = []FieldDefinitionType{Boolean, Integer, String, Float}
