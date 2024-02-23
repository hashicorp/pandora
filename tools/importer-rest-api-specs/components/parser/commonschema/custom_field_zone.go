// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package commonschema

import (
	"strings"

	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/parser/internal"
)

var _ customFieldMatcher = zoneFieldMatcher{}

type zoneFieldMatcher struct {
}

func (zoneFieldMatcher) ReplacementObjectDefinition() models.SDKObjectDefinition {
	return models.SDKObjectDefinition{
		Type: models.ZoneTerraformSchemaObjectDefinitionType,
	}
}

func (zoneFieldMatcher) IsMatch(field models.SDKField, definition models.SDKObjectDefinition, _ internal.ParseResult) bool {
	nameMatches := strings.EqualFold(field.JsonName, "availabilityZone") || strings.EqualFold(field.JsonName, "zone")
	typeMatches := definition.Type == models.StringSDKObjectDefinitionType
	return nameMatches && typeMatches
}
