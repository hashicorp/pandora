// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package models

import (
	"encoding/json"
	"fmt"
)

var _ json.Unmarshaler = &TerraformSchemaField{}

// TerraformSchemaField defines a Field within a TerraformSchemaModel, which is output in both
// the generated Model and the Terraform Schema for this Terraform Resource.
type TerraformSchemaField struct {
	// NOTE: custom unmarshaller below

	// Computed specifies whether this field is Computed - meaning that there is a default value
	// for this field set by the API.
	// Note that it's preferable for a field to be Optional with a Default value, rather than Computed.
	Computed bool `json:"computed"`

	// TODO: support `Default`

	// Documentation specifies the Documentation available for this field
	Documentation TerraformSchemaFieldDocumentationDefinition `json:"documentation"`

	// ForceNew specifies whether this field is ForceNew - meaning that it can only be set during Creation
	// and that to update the value the Terraform Resource must be recreated.
	ForceNew bool `json:"forceNew"`

	// HCLName specifies the HCL Name for this field within the Terraform Schema.
	HCLName string `json:"hclName"`

	// ObjectDefinition specifies the Type of this field, mapping to Types in the Terraform Schema.
	// Examples include a String or a List of a Model.
	ObjectDefinition TerraformSchemaObjectDefinition `json:"objectDefinition"`

	// Optional specifies whether this field is Optional, e.g. whether it can be omitted.
	Optional bool `json:"optional"`

	// Requires specifies whether this field is Required, e.g. whether it must be specified.
	Required bool `json:"required"`

	// Validation specifies the validation criteria for this field, for example a set of fixed values.
	Validation TerraformSchemaFieldValidationDefinition `json:"validation"`
}

func (f *TerraformSchemaField) UnmarshalJSON(bytes []byte) error {
	type alias TerraformSchemaField
	var decoded alias
	if err := json.Unmarshal(bytes, &decoded); err != nil {
		return fmt.Errorf("unmarshaling into TerraformSchemaField: %+v", err)
	}

	f.Computed = decoded.Computed
	f.Documentation = decoded.Documentation
	f.ForceNew = decoded.ForceNew
	f.HCLName = decoded.HCLName
	f.ObjectDefinition = decoded.ObjectDefinition
	f.Optional = decoded.Optional
	f.Required = decoded.Required

	var temp map[string]json.RawMessage
	if err := json.Unmarshal(bytes, &temp); err != nil {
		return fmt.Errorf("unmarshaling TerraformSchemaField into map[string]json.RawMessage: %+v", err)
	}

	if v, ok := temp["validation"]; ok {
		impl, err := unmarshalTerraformSchemaFieldValidationDefinitionImplementation(v)
		if err != nil {
			return fmt.Errorf("unmarshaling `Fields` within `TerraformSchemaFieldValidationDefinition`: %+v", err)
		}
		f.Validation = impl
	}
	return nil
}
