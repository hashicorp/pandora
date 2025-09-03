// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package workarounds

import (
	"errors"
	"github.com/hashicorp/pandora/tools/importer-msgraph-metadata/components/versions"

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
	if apiVersion != versions.ApiVersionStable {
		return nil // This workaround only applies to the stable API version as there is no beta API version for Conditional Access Policies currently.
	}
	model, ok := models["microsoft.graph.conditionalAccessPolicy"]
	if !ok {
		return errors.New("`ConditionalAccessPolicy` model not found")
	}

	// `grantControls` and `sessionControls` must be null to unset them, so make them nullable + required
	if _, ok = model.Fields["grantControls"]; !ok {
		return errors.New("`GrantControls` field not found")
	}
	model.Fields["grantControls"].Nullable = true
	model.Fields["grantControls"].Required = true
	if _, ok = model.Fields["sessionControls"]; !ok {
		return errors.New("`SessionControls` field not found")
	}
	model.Fields["sessionControls"].Nullable = true
	model.Fields["sessionControls"].Required = true

	model, ok = models["microsoft.graph.conditionalAccessConditionSet"]
	if !ok {
		return errors.New("`ConditionalAccessConditionSet` model not found")
	}

	// `devices`, `locations`, `platforms` must each be null to unset them, so make them nullable + required
	if _, ok = model.Fields["devices"]; !ok {
		return errors.New("`Devices` field not found")
	}
	model.Fields["devices"].Nullable = true
	model.Fields["devices"].Required = true
	if _, ok = model.Fields["locations"]; !ok {
		return errors.New("`Locations` field not found")
	}
	model.Fields["locations"].Nullable = true
	model.Fields["locations"].Required = true
	if _, ok = model.Fields["platforms"]; !ok {
		return errors.New("`Platforms` field not found")
	}
	model.Fields["platforms"].Nullable = true
	model.Fields["platforms"].Required = true

	model, ok = models["microsoft.graph.conditionalAccessExternalTenants"]
	if !ok {
		return errors.New("`ConditionalAccessExternalTenants` model not found")
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
		return errors.New("`ConditionalAccessGuestsOrExternalUsers` model not found")
	}
	if _, ok = model.Fields["guestOrExternalUserTypes"]; !ok {
		return errors.New("`GuestOrExternalUserTypes` field not found")
	}
	// model.Fields["guestOrExternalUserTypes"].Type = pointer.To(parser.DataTypeCsv)

	model, ok = models["microsoft.graph.conditionalAccessSessionControls"]
	if !ok {
		return errors.New("`ConditionalAccessSessionControls` model not found")
	}

	// `cloudAppSecurityPolicy` must be null to unset it, so make it nullable + required
	if _, ok = model.Fields["cloudAppSecurity"]; !ok {
		return errors.New("`CloudAppSecurity` field not found")
	}
	model.Fields["cloudAppSecurity"].Nullable = true
	model.Fields["cloudAppSecurity"].Required = true

	model, ok = models["microsoft.graph.conditionalAccessUsers"]
	if !ok {
		return errors.New("`ConditionalAccessUsers` model not found")
	}

	// `excludeGuestsOrExternalUsers` / `includeGuestsOrExternalUsers` must be null to unset them, so make them nullable + required
	if _, ok = model.Fields["excludeGuestsOrExternalUsers"]; !ok {
		return errors.New("`ExcludeGuestsOrExternalUsers` field not found")
	}
	model.Fields["excludeGuestsOrExternalUsers"].Nullable = true
	model.Fields["excludeGuestsOrExternalUsers"].Required = true
	if _, ok = model.Fields["includeGuestsOrExternalUsers"]; !ok {
		return errors.New("`IncludeGuestsOrExternalUsers` field not found")
	}
	model.Fields["includeGuestsOrExternalUsers"].Nullable = true
	model.Fields["includeGuestsOrExternalUsers"].Required = true

	model, ok = models["microsoft.graph.conditionalAccessClientApplications"]
	if !ok {
		return errors.New("`ConditionalAccessClientApplications` model not found")
	}

	// `servicePrincipalFilter` must be null to unset it, so make it nullable + required
	if _, ok := model.Fields["servicePrincipalFilter"]; !ok {
		return errors.New("`ServicePrincipalFilter` field not found")
	}
	model.Fields["servicePrincipalFilter"].Nullable = true
	model.Fields["servicePrincipalFilter"].Required = true

	return nil
}
