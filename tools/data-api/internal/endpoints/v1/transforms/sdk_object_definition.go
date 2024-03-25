// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package transforms

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/data-api/internal/repositories"
)

var objectDefinitionTypes = map[repositories.ObjectDefinitionType]models.SDKObjectDefinitionType{
	// Basic Types
	repositories.BooleanObjectDefinitionType:  models.BooleanSDKObjectDefinitionType,
	repositories.DateTimeObjectDefinitionType: models.DateTimeSDKObjectDefinitionType,
	repositories.FloatObjectDefinitionType:    models.FloatSDKObjectDefinitionType,
	repositories.IntegerObjectDefinitionType:  models.IntegerSDKObjectDefinitionType,
	repositories.StringObjectDefinitionType:   models.StringSDKObjectDefinitionType,

	// Complex Types
	repositories.CsvObjectDefinitionType:        models.CSVSDKObjectDefinitionType,
	repositories.DictionaryObjectDefinitionType: models.DictionarySDKObjectDefinitionType,
	repositories.ListObjectDefinitionType:       models.ListSDKObjectDefinitionType,
	repositories.RawFileObjectDefinitionType:    models.RawFileSDKObjectDefinitionType,
	repositories.RawObjectObjectDefinitionType:  models.RawObjectSDKObjectDefinitionType,
	repositories.ReferenceObjectDefinitionType:  models.ReferenceSDKObjectDefinitionType,

	// Common Schema
	repositories.EdgeZoneObjectDefinitionType:                                models.EdgeZoneSDKObjectDefinitionType,
	repositories.LegacySystemAndUserAssignedIdentityListObjectDefinitionType: models.LegacySystemAndUserAssignedIdentityListSDKObjectDefinitionType,
	repositories.LegacySystemAndUserAssignedIdentityMapObjectDefinitionType:  models.LegacySystemAndUserAssignedIdentityMapSDKObjectDefinitionType,
	repositories.LocationObjectDefinitionType:                                models.LocationSDKObjectDefinitionType,
	repositories.SystemAssignedIdentityObjectDefinitionType:                  models.SystemAssignedIdentitySDKObjectDefinitionType,
	repositories.SystemAndUserAssignedIdentityListObjectDefinitionType:       models.SystemAndUserAssignedIdentityListSDKObjectDefinitionType,
	repositories.SystemAndUserAssignedIdentityMapObjectDefinitionType:        models.SystemAndUserAssignedIdentityMapSDKObjectDefinitionType,
	repositories.SystemDataObjectDefinitionType:                              models.SystemDataSDKObjectDefinitionType,
	repositories.SystemOrUserAssignedIdentityListObjectDefinitionType:        models.SystemOrUserAssignedIdentityListSDKObjectDefinitionType,
	repositories.SystemOrUserAssignedIdentityMapObjectDefinitionType:         models.SystemOrUserAssignedIdentityMapSDKObjectDefinitionType,
	repositories.TagsObjectDefinitionType:                                    models.TagsSDKObjectDefinitionType,
	repositories.UserAssignedIdentityListObjectDefinitionType:                models.UserAssignedIdentityListSDKObjectDefinitionType,
	repositories.UserAssignedIdentityMapObjectDefinitionType:                 models.UserAssignedIdentityMapSDKObjectDefinitionType,
	repositories.ZoneObjectDefinitionType:                                    models.ZoneSDKObjectDefinitionType,
	repositories.ZonesObjectDefinitionType:                                   models.ZonesSDKObjectDefinitionType,
}

func mapSDKObjectDefinition(input repositories.ObjectDefinition) (*models.SDKObjectDefinition, error) {
	objectDefinitionType, ok := objectDefinitionTypes[input.Type]
	if !ok {
		return nil, fmt.Errorf("internal-error: missing mapping for SDKObjectDefinitionType %q", string(input.Type))
	}

	output := models.SDKObjectDefinition{
		Type: objectDefinitionType,
	}
	if input.NestedItem != nil {
		mappedInner, err := mapSDKObjectDefinition(*input.NestedItem)
		if err != nil {
			return nil, fmt.Errorf("mapping NestedItem: %+v", err)
		}
		output.NestedItem = mappedInner
	}
	if input.ReferenceName != nil {
		output.ReferenceName = input.ReferenceName
	}
	return &output, nil
}
