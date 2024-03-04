// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package commonschema

import (
	"strings"

	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/parser/internal"
)

var _ customFieldMatcher = zonesFieldMatcher{}

type zonesFieldMatcher struct {
}

func (zonesFieldMatcher) ReplacementObjectDefinition() models.SDKObjectDefinition {
	return models.SDKObjectDefinition{
		Type: models.ZonesTerraformSchemaObjectDefinitionType,
	}
}

func (zonesFieldMatcher) IsMatch(field models.SDKField, _ internal.ParseResult) bool {
	nameMatches := strings.EqualFold(field.JsonName, "availabilityZones") || strings.EqualFold(field.JsonName, "zones")
	typesMatch := field.ObjectDefinition.Type == models.ListSDKObjectDefinitionType && field.ObjectDefinition.NestedItem != nil && field.ObjectDefinition.NestedItem.Type == models.StringSDKObjectDefinitionType
	return nameMatches && typesMatch
}
