// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package workarounds

import (
	"fmt"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/pandora/tools/importer-msgraph-metadata/components/parser"
	"github.com/hashicorp/pandora/tools/importer-msgraph-metadata/components/versions"
)

var _ dataWorkaround = workaroundApplication{}

// workaroundApplication works around missing fields in the Application model for the beta API.
//  1. Missing `oauth2RequirePostResponse` field.
//     Upstream PR: https://github.com/microsoftgraph/msgraph-metadata/issues/273
//  2. Missing `applicationTemplateId` field.
type workaroundApplication struct{}

func (workaroundApplication) Name() string {
	return "Application / missing fields in beta"
}

func (workaroundApplication) Process(apiVersion string, models parser.Models, constants parser.Constants, resourceIds parser.ResourceIds) error {
	if apiVersion != versions.ApiVersionBeta {
		return nil
	}

	model, ok := models["microsoft.graph.application"]
	if !ok {
		return fmt.Errorf("`Application` model not found")
	}

	// Add the `oauth2RequirePostResponse` field if missing
	if _, ok := model.Fields["OAuth2RequirePostResponse"]; !ok {
		model.Fields["oauth2RequirePostResponse"] = &parser.ModelField{
			Name:        "OAuth2RequirePostResponse",
			Description: "Specifies whether, as part of OAuth 2.0 token requests, Microsoft Entra ID allows POST requests, as opposed to GET requests. The default is false, which specifies that only GET requests are allowed.",
			Type:        pointer.To(parser.DataTypeBool),
		}
	}

	// Add the `applicationTemplateId` field if missing
	if _, ok := model.Fields["ApplicationTemplateId"]; !ok {
		model.Fields["applicationTemplateId"] = &parser.ModelField{
			Name:        "ApplicationTemplateId",
			Description: "Unique identifier of the applicationTemplate. Supports $filter (eq, not, ne). Read-only. null if the app wasn't created from an application template.",
			Type:        pointer.To(parser.DataTypeString),
			Nullable:    true,
		}
	}

	return nil
}
