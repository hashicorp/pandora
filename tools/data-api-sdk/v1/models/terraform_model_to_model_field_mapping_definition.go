// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package models

import (
	"encoding/json"
	"fmt"
)

var _ json.Marshaler = TerraformModelToModelFieldMappingDefinition{}

var _ TerraformFieldMappingDefinition = TerraformModelToModelFieldMappingDefinition{}

// TerraformModelToModelFieldMappingDefinition defines that the SDKField named in SDKFieldName should be
// mapped to/from the TerraformSchemaModel named in TerraformSchemaModelName by calling the associated
// `map{TerraformSchemaModelName}To{SDKModel}` (and vica-versa) function.
//
// This enables fields which contain nested models (e.g. a list of `[]Subnets`) to be mapped across.
type TerraformModelToModelFieldMappingDefinition struct {
	// TODO: remove this unnecessary wrapper object once the updated SDK is rolled out everywhere
	ModelToModel TerraformModelToModelFieldMappingDefinitionImpl `json:"modelToModel"`
}

type TerraformModelToModelFieldMappingDefinitionImpl struct {
	// TerraformSchemaModelName specifies the name of the TerraformSchemaModel which should be mapped to/from the SDKModel
	// named in SDKModelName.
	TerraformSchemaModelName string `json:"schemaModelName"`

	// SDKModelName specifies the name of the SDKModel which should be mapped to/from the TerraformSchemaModel named in
	// TerraformSchemaModelName.
	SDKModelName string `json:"sdkModelName"`

	// SDKFieldName specifies the name of the SDKField within the SDKModel (defined in SDKModelName) which should be
	// mapped to/from the TerraformSchemaModel (defined in TerraformSchemaModelName).
	SDKFieldName string `json:"sdkFieldName"`
}

// mappingDefinitionType specifies the type of TerraformFieldMappingDefinitionType this TerraformFieldMappingType represents.
func (TerraformModelToModelFieldMappingDefinition) mappingDefinitionType() TerraformFieldMappingDefinitionType {
	return ModelToModelTerraformFieldMappingDefinitionType
}

func (d TerraformModelToModelFieldMappingDefinition) MarshalJSON() ([]byte, error) {
	type wrapper TerraformModelToModelFieldMappingDefinition
	wrapped := wrapper(d)
	encoded, err := json.Marshal(wrapped)
	if err != nil {
		return nil, fmt.Errorf("marshaling TerraformModelToModelFieldMappingDefinition: %+v", err)
	}

	var decoded map[string]interface{}
	if err := json.Unmarshal(encoded, &decoded); err != nil {
		return nil, fmt.Errorf("unmarshaling TerraformModelToModelFieldMappingDefinition: %+v", err)
	}
	decoded["type"] = d.mappingDefinitionType()

	encoded, err = json.Marshal(decoded)
	if err != nil {
		return nil, fmt.Errorf("re-marshaling TerraformModelToModelFieldMappingDefinition: %+v", err)
	}

	return encoded, nil
}
