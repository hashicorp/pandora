// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package transforms

import (
	"fmt"
	"sort"

	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	repositoryModels "github.com/hashicorp/pandora/tools/sdk/dataapimodels"
)

func MapTerraformSchemaModelToRepository(modelName string, schemaModel sdkModels.TerraformSchemaModelDefinition) (*repositoryModels.TerraformSchemaModel, error) {
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
