// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package workarounds

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/importer-msgraph-metadata/components/parser"
)

var _ dataWorkaround = workaroundOAuth2PermissionGrant{}

// workaroundOAuth2PermissionGrant adds missing fields and fixes some field types.
type workaroundOAuth2PermissionGrant struct{}

func (workaroundOAuth2PermissionGrant) Name() string {
	return "OAuth2PermissionGrant / clientId is not required when updating"
}

func (workaroundOAuth2PermissionGrant) Process(apiVersion string, models parser.Models, constants parser.Constants, resourceIds parser.ResourceIds) error {
	model, ok := models["microsoft.graph.oAuth2PermissionGrant"]
	if !ok {
		return fmt.Errorf("`oAuth2PermissionGrant` model not found")
	}

	// `clientId` is not read-only
	if _, ok = model.Fields["clientId"]; !ok {
		return fmt.Errorf("`clientId` field not found")
	}
	model.Fields["clientId"].Required = false

	return nil
}
