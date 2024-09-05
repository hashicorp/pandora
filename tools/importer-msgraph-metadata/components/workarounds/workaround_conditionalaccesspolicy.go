// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package workarounds

import (
	"fmt"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/pandora/tools/importer-msgraph-metadata/components/parser"
)

var _ dataWorkaround = workaroundConditionalAccessPolicy{}

// workaroundConditionalAccessPolicy adds missing fields and fixes some field types.
type workaroundConditionalAccessPolicy struct{}

func (workaroundConditionalAccessPolicy) Name() string {
	return "Conditional Access Policy / fixing missing fields and types"
}

func (workaroundConditionalAccessPolicy) Process(apiVersion string, models parser.Models, constants parser.Constants, resourceIds parser.ResourceIds) error {
	model, ok := models["microsoft.graph.conditionalAccessPolicy"]
	if !ok {
		return fmt.Errorf("`ConditionalAccessPolicy` model not found")
	}

	// grantControls and sessionControls must be null to unset them, so make them nullable + required
	if _, ok = model.Fields["grantControls"]; !ok {
		return fmt.Errorf("`GrantControls` field not found")
	}
	model.Fields["grantControls"].Nullable = true
	model.Fields["grantControls"].Required = true
	if _, ok = model.Fields["sessionControls"]; !ok {
		return fmt.Errorf("`SessionControls` field not found")
	}
	model.Fields["sessionControls"].Nullable = true
	model.Fields["sessionControls"].Required = true

	model, ok = models["microsoft.graph.conditionalAccessConditionSet"]
	if !ok {
		return fmt.Errorf("`ConditionalAccessConditionSet` model not found")
	}

	// devices, locations, platforms must each be null to unset them, so make them nullable + required
	if _, ok = model.Fields["devices"]; !ok {
		return fmt.Errorf("`Devices` field not found")
	}
	model.Fields["devices"].Nullable = true
	model.Fields["devices"].Required = true
	if _, ok = model.Fields["locations"]; !ok {
		return fmt.Errorf("`Locations` field not found")
	}
	model.Fields["locations"].Nullable = true
	model.Fields["locations"].Required = true
	if _, ok = model.Fields["platforms"]; !ok {
		return fmt.Errorf("`Platforms` field not found")
	}
	model.Fields["platforms"].Nullable = true
	model.Fields["platforms"].Required = true

	model, ok = models["microsoft.graph.conditionalAccessExternalTenants"]
	if !ok {
		return fmt.Errorf("`ConditionalAccessExternalTenants` model not found")
	}

	// Add the `members` field if missing
	if _, ok = model.Fields["members"]; !ok {
		model.Fields["members"] = &parser.ModelField{
			Name:     "Members",
			Type:     pointer.To(parser.DataTypeArray),
			ItemType: pointer.To(parser.DataTypeString),
		}
	}

	// Set CSV type for field
	model, ok = models["microsoft.graph.conditionalAccessGuestsOrExternalUsers"]
	if !ok {
		return fmt.Errorf("`ConditionalAccessGuestsOrExternalUsers` model not found")
	}
	if _, ok = model.Fields["guestOrExternalUserTypes"]; !ok {
		return fmt.Errorf("`GuestOrExternalUserTypes` field not found")
	}
	//model.Fields["guestOrExternalUserTypes"].Type = pointer.To(parser.DataTypeCsv)

	model, ok = models["microsoft.graph.conditionalAccessSessionControls"]
	if !ok {
		return fmt.Errorf("`ConditionalAccessSessionControls` model not found")
	}

	// cloudAppSecurityPolicy must be null to unset it, so make it nullable + required
	if _, ok = model.Fields["cloudAppSecurity"]; !ok {
		return fmt.Errorf("`CloudAppSecurity` field not found")
	}
	model.Fields["cloudAppSecurity"].Nullable = true
	model.Fields["cloudAppSecurity"].Required = true

	model, ok = models["microsoft.graph.conditionalAccessUsers"]
	if !ok {
		return fmt.Errorf("`ConditionalAccessUsers` model not found")
	}

	// excludeGuestsOrExternalUsers / includeGuestsOrExternalUsers must be null to unset them, so make them nullable + required
	if _, ok = model.Fields["excludeGuestsOrExternalUsers"]; !ok {
		return fmt.Errorf("`ExcludeGuestsOrExternalUsers` field not found")
	}
	model.Fields["excludeGuestsOrExternalUsers"].Nullable = true
	model.Fields["excludeGuestsOrExternalUsers"].Required = true
	if _, ok = model.Fields["includeGuestsOrExternalUsers"]; !ok {
		return fmt.Errorf("`IncludeGuestsOrExternalUsers` field not found")
	}
	model.Fields["includeGuestsOrExternalUsers"].Nullable = true
	model.Fields["includeGuestsOrExternalUsers"].Required = true

	return nil
}
