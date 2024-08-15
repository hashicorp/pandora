// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package workarounds

import (
	"fmt"
	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/pandora/tools/importer-msgraph-metadata/components/parser"
)

var _ workaround = workaroundConditionalAccessPolicy{}

// workaroundConditionalAccessPolicy adds missing fields and fixes some field types.
type workaroundConditionalAccessPolicy struct{}

func (workaroundConditionalAccessPolicy) Name() string {
	return "Conditional Access Policy / fixing missing fields and types"
}

func (workaroundConditionalAccessPolicy) Process(apiVersion string, models parser.Models, constants parser.Constants) error {
	model, ok := models["ConditionalAccessPolicy"]
	if !ok {
		return fmt.Errorf("`ConditionalAccessPolicy` model not found")
	}

	// grantControls and sessionControls must be null to unset them, so make them nullable + required
	if _, ok = model.Fields["GrantControls"]; !ok {
		return fmt.Errorf("`GrantControls` field not found")
	}
	model.Fields["GrantControls"].Nullable = true
	model.Fields["GrantControls"].Required = true
	if _, ok = model.Fields["SessionControls"]; !ok {
		return fmt.Errorf("`SessionControls` field not found")
	}
	model.Fields["SessionControls"].Nullable = true
	model.Fields["SessionControls"].Required = true

	model, ok = models["ConditionalAccessConditionSet"]
	if !ok {
		return fmt.Errorf("`ConditionalAccessConditionSet` model not found")
	}

	// devices, locations, platforms must each be null to unset them, so make them nullable + required
	if _, ok = model.Fields["Devices"]; !ok {
		return fmt.Errorf("`Devices` field not found")
	}
	model.Fields["Devices"].Nullable = true
	model.Fields["Devices"].Required = true
	if _, ok = model.Fields["Locations"]; !ok {
		return fmt.Errorf("`Locations` field not found")
	}
	model.Fields["Locations"].Nullable = true
	model.Fields["Locations"].Required = true
	if _, ok = model.Fields["Platforms"]; !ok {
		return fmt.Errorf("`Platforms` field not found")
	}
	model.Fields["Platforms"].Nullable = true
	model.Fields["Platforms"].Required = true

	model, ok = models["ConditionalAccessExternalTenants"]
	if !ok {
		return fmt.Errorf("`ConditionalAccessExternalTenants` model not found")
	}

	// Add the `members` field if missing
	if _, ok = model.Fields["Members"]; !ok {
		model.Fields["Members"] = &parser.ModelField{
			Title:     "Members",
			Type:      pointer.To(parser.DataTypeArray),
			ItemType:  pointer.To(parser.DataTypeString),
			JsonField: "members",
		}
	}

	// Set CSV type for field
	model, ok = models["ConditionalAccessGuestsOrExternalUsers"]
	if !ok {
		return fmt.Errorf("`ConditionalAccessGuestsOrExternalUsers` model not found")
	}
	if _, ok = model.Fields["GuestOrExternalUserTypes"]; !ok {
		return fmt.Errorf("`GuestOrExternalUserTypes` field not found")
	}
	model.Fields["GuestOrExternalUserTypes"].Type = pointer.To(parser.DataTypeCsv)

	// Rename this constant
	if v, ok := constants["ConditionalAccessGuestsOrExternalUsersGuestOrExternalUserType"]; ok {
		constants["ConditionalAccessGuestOrExternalUserType"] = v

		for _, model = range models {
			for fieldName := range model.Fields {
				if model.Fields[fieldName].ConstantName != nil && *model.Fields[fieldName].ConstantName == "ConditionalAccessGuestsOrExternalUsersGuestOrExternalUserType" {
					model.Fields[fieldName].ConstantName = pointer.To("ConditionalAccessGuestOrExternalUserType")
				}
			}
		}

		delete(constants, "ConditionalAccessGuestsOrExternalUsersGuestOrExternalUserType")
	}

	model, ok = models["ConditionalAccessSessionControls"]
	if !ok {
		return fmt.Errorf("`ConditionalAccessSessionControls` model not found")
	}

	// cloudAppSecurityPolicy must be null to unset it, so make it nullable + required
	if _, ok = model.Fields["CloudAppSecurity"]; !ok {
		return fmt.Errorf("`CloudAppSecurity` field not found")
	}
	model.Fields["CloudAppSecurity"].Nullable = true
	model.Fields["CloudAppSecurity"].Required = true

	model, ok = models["ConditionalAccessUsers"]
	if !ok {
		return fmt.Errorf("`ConditionalAccessUsers` model not found")
	}

	// cloudAppSecurityPolicy must be null to unset it, so make it nullable + required
	if _, ok = model.Fields["ExcludeGuestsOrExternalUsers"]; !ok {
		return fmt.Errorf("`ExcludeGuestsOrExternalUsers` field not found")
	}
	model.Fields["ExcludeGuestsOrExternalUsers"].Nullable = true
	model.Fields["ExcludeGuestsOrExternalUsers"].Required = true
	if _, ok = model.Fields["IncludeGuestsOrExternalUsers"]; !ok {
		return fmt.Errorf("`IncludeGuestsOrExternalUsers` field not found")
	}
	model.Fields["IncludeGuestsOrExternalUsers"].Nullable = true
	model.Fields["IncludeGuestsOrExternalUsers"].Required = true

	return nil
}
