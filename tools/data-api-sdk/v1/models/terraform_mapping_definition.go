// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package models

import (
	"encoding/json"
	"fmt"
)

var _ json.Unmarshaler = &TerraformMappingDefinition{}

// TerraformMappingDefinition defines how Fields within TerraformSchemaModel's should be mapped onto
// either SDKField/SDKModel's or ResourceID segments.
type TerraformMappingDefinition struct {
	// Fields specifies the mappings between a TerraformSchemaField (within a TerraformSchemaModel) and
	// a SDKField (within a SDKModel).
	Fields []TerraformFieldMappingDefinition `json:"fields"`

	// ModelToModels specifies the mappings between TerraformSchemaModel's and SDKModel's.
	// This information is aggregated from the other mapping types, and is present to make
	// ordering the output simpler.
	// TODO: determine if this is still needed.
	ModelToModels []TerraformModelToModelMappingDefinition `json:"modelToModel"`

	// ResourceID specifies the mappings between any Segments within the ResourceID and a TerraformSchemaModel.
	// This is used in both the Create function (to build up the ResourceID) and in the Read function
	// (to populate the TerraformSchemaField values stored within the ResourceID).
	ResourceID []TerraformResourceIDMappingDefinition `json:"resourceId"`
}

func (d *TerraformMappingDefinition) UnmarshalJSON(bytes []byte) error {
	type alias TerraformMappingDefinition
	var decoded alias
	if err := json.Unmarshal(bytes, &decoded); err != nil {
		return fmt.Errorf("unmarshaling into TerraformMappingDefinition: %+v", err)
	}

	d.ModelToModels = decoded.ModelToModels
	d.ResourceID = decoded.ResourceID

	var temp map[string]json.RawMessage
	if err := json.Unmarshal(bytes, &temp); err != nil {
		return fmt.Errorf("unmarshaling TerraformMappingDefinition into map[string]json.RawMessage: %+v", err)
	}

	if v, ok := temp["fields"]; ok {
		var listTemp []json.RawMessage
		if err := json.Unmarshal(v, &listTemp); err != nil {
			return fmt.Errorf("unmarshaling TerraformFieldMappingDefinition into list []json.RawMessage: %+v", err)
		}

		output := make([]TerraformFieldMappingDefinition, 0)
		for i, val := range listTemp {
			impl, err := unmarshalTerraformFieldMappingDefinitionImplementation(val)
			if err != nil {
				return fmt.Errorf("unmarshaling index %d field for `Fields` within `TerraformFieldMappingDefinition`: %+v", i, err)
			}
			output = append(output, impl)
		}
		d.Fields = output
	}
	return nil
}
