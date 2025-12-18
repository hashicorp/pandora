// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package models

import (
	"encoding/json"
	"fmt"
)

var _ json.Marshaler = &TerraformDirectAssignmentFieldMappingDefinition{}
var _ TerraformFieldMappingDefinition = TerraformDirectAssignmentFieldMappingDefinition{}

// TerraformDirectAssignmentFieldMappingDefinition defines that a TerraformSchemaField within a TerraformSchemaModel
// should be mapped onto an SDKField within an SDKModel.
type TerraformDirectAssignmentFieldMappingDefinition struct {
	// TODO: remove this unnecessary wrapper object once the updated SDK is rolled out everywhere
	DirectAssignment TerraformDirectAssignmentFieldMappingDefinitionImpl `json:"directAssignment"`
}

type TerraformDirectAssignmentFieldMappingDefinitionImpl struct {
	// TerraformSchemaModelName specifies the name of the TerraformSchemaModel where the TerraformSchemaField named in
	// TerraformSchemaFieldName exists.
	TerraformSchemaModelName string `json:"schemaModelName"` // TODO: rename the struct tags once everything is refactored

	// TerraformSchemaFieldName specifies the name of the TerraformSchemaField (within the TerraformSchemaModel named in
	// TerraformSchemaModelName) where the value for SDKFieldName should be mapped to/from.
	TerraformSchemaFieldName string `json:"schemaFieldPath"` // TODO: rename the struct tags once everything is refactored

	// SDKModelName specifies the name of the SDKModel where the SDKField named in SDKFieldName exists.
	SDKModelName string `json:"sdkModelName"`

	// SDKFieldName specifies the name of the SDKField (within the SDKModel named in SDKModelName) that should be mapped
	// to/from the value for the TerraformSchemaField (named in TerraformSchemaFieldName).
	SDKFieldName string `json:"sdkFieldPath"` // TODO: rename the struct tags once everything is refactored
}

// mappingDefinitionType specifies the type of TerraformFieldMappingDefinitionType this TerraformFieldMappingType represents.
func (TerraformDirectAssignmentFieldMappingDefinition) mappingDefinitionType() TerraformFieldMappingDefinitionType {
	return DirectAssignmentTerraformFieldMappingDefinitionType
}

func (d TerraformDirectAssignmentFieldMappingDefinition) MarshalJSON() ([]byte, error) {
	type wrapper TerraformDirectAssignmentFieldMappingDefinition
	wrapped := wrapper(d)
	encoded, err := json.Marshal(wrapped)
	if err != nil {
		return nil, fmt.Errorf("marshaling TerraformDirectAssignmentFieldMappingDefinition: %+v", err)
	}

	var decoded map[string]interface{}
	if err := json.Unmarshal(encoded, &decoded); err != nil {
		return nil, fmt.Errorf("unmarshaling TerraformDirectAssignmentFieldMappingDefinition: %+v", err)
	}
	decoded["type"] = d.mappingDefinitionType()

	encoded, err = json.Marshal(decoded)
	if err != nil {
		return nil, fmt.Errorf("re-marshaling TerraformDirectAssignmentFieldMappingDefinition: %+v", err)
	}

	return encoded, nil
}
