// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package transforms

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/sdk/dataapimodels"
)

func mapSDKFieldToRepository(fieldName string, fieldDetails models.SDKField, isTypeHint bool, constants map[string]models.SDKConstant, knownModels map[string]models.SDKModel) (*dataapimodels.ModelField, error) {
	// TODO: thread through logging
	objectDefinition, err := mapSDKObjectDefinitionToRepository(fieldDetails.ObjectDefinition, constants, knownModels)
	if err != nil {
		return nil, fmt.Errorf("mapping the ObjectDefinition for field %q: %+v", fieldName, err)
	}

	return &dataapimodels.ModelField{
		ContainsDiscriminatedTypeValue: isTypeHint,
		DateFormat:                     nil,
		Description:                    nil,
		// TODO this can be uncommented when #3325 has been fixed
		// Description: fieldDetails.Description,
		JsonName:         fieldDetails.JsonName,
		Name:             fieldName,
		ObjectDefinition: *objectDefinition,
		Optional:         fieldDetails.Optional,
		ReadOnly:         fieldDetails.ReadOnly,
		Required:         fieldDetails.Required,
		Sensitive:        fieldDetails.Sensitive,
	}, nil
}
