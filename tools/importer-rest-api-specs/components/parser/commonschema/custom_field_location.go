// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package commonschema

import (
	"strings"

	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/parser/internal"
)

var _ customFieldMatcher = locationMatcher{}

type locationMatcher struct{}

func (l locationMatcher) ReplacementObjectDefinition() models.SDKObjectDefinition {
	return models.SDKObjectDefinition{
		Type: models.LocationSDKObjectDefinitionType,
	}
}

func (l locationMatcher) IsMatch(field models.SDKField, _ internal.ParseResult) bool {
	return strings.EqualFold(field.JsonName, "location") && field.ObjectDefinition.Type == models.StringSDKObjectDefinitionType
}
