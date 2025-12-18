// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package transforms

import (
	"fmt"
	"sort"

	repositoryModels "github.com/hashicorp/pandora/tools/data-api-repository/repository/internal/models"
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

func MapTerraformSchemaModelFromRepository(input *repositoryModels.TerraformSchemaModel) (*sdkModels.TerraformSchemaModel, error) {
	fields := make(map[string]sdkModels.TerraformSchemaField)
	for _, item := range input.Fields {
		mapped, err := mapTerraformSchemaFieldFromRepository(item)
		if err != nil {
			return nil, fmt.Errorf("mapping TerraformSchemaField %q: %+v", item.Name, err)
		}
		fields[item.Name] = *mapped
	}
	return &sdkModels.TerraformSchemaModel{
		Fields: fields,
	}, nil
}

func MapTerraformSchemaModelToRepository(modelName string, schemaModel sdkModels.TerraformSchemaModel) (*repositoryModels.TerraformSchemaModel, error) {
	fieldList := make([]string, 0)
	for f := range schemaModel.Fields {
		fieldList = append(fieldList, f)
	}
	sort.Strings(fieldList)

	schemaFields := make([]repositoryModels.TerraformSchemaField, 0)
	for _, fieldName := range fieldList {
		def := schemaModel.Fields[fieldName]

		fieldBody, err := mapTerraformSchemaFieldToRepository(fieldName, def)
		if err != nil {
			return nil, fmt.Errorf("mapping the terraform schema field %q: %+v", fieldName, err)
		}

		schemaFields = append(schemaFields, *fieldBody)
	}

	return &repositoryModels.TerraformSchemaModel{
		Fields: schemaFields,
		// todo remove Schema when https://github.com/hashicorp/pandora/issues/3346 is addressed
		Name: fmt.Sprintf("%sSchema", modelName),
	}, nil
}
