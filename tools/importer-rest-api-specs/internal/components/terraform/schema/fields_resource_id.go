// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package schema

import (
	"fmt"
	"strings"

	sdkHelpers "github.com/hashicorp/pandora/tools/data-api-sdk/v1/helpers"
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	terraformHelpers "github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/terraform/schema/helpers"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/logging"
	"github.com/hashicorp/pandora/tools/sdk/config/definitions"
)

func (b Builder) identifyTopLevelFieldsWithinResourceID(input sdkModels.ResourceID, mappings *sdkModels.TerraformMappingDefinition, displayName string, resourceDefinition definitions.ResourceDefinition) (map[string]sdkModels.TerraformSchemaField, *sdkModels.TerraformMappingDefinition, error) {
	out := make(map[string]sdkModels.TerraformSchemaField)
	overrides := make([]definitions.Override, 0)

	if resourceDefinition.Overrides != nil {
		overrides = *resourceDefinition.Overrides
	}

	// first determine whether we are dealing with a nested resource
	parentResourceFound := false
	parentResourceIdName := ""
	parentSegments := make([]sdkModels.ResourceIDSegment, 0)
	if len(input.Segments) > 2 {
		parentSegments = input.Segments[0 : len(input.Segments)-2]
		if segmentsContainResource(parentSegments) {
			parentResourceFound = true
			// find the parent Resource ID and use that
			for name, id := range b.apiResource.ResourceIDs {
				if segmentsMatch(id.Segments, parentSegments) {
					parentResourceIdName = name
					break
				}
			}
		}
	}

	if parentResourceFound && parentResourceIdName == "" {
		logging.Debugf("parent resource detected for %s but was not present in resource's ID definitions", displayName)
	}

	// if a parent is resource is found and present in the ResourceID mappings then we use this
	if parentResourceIdName != "" {
		// add field definition for the resource name
		out["Name"] = sdkModels.TerraformSchemaField{
			ObjectDefinition: sdkModels.TerraformSchemaObjectDefinition{
				Type: sdkModels.StringTerraformSchemaObjectDefinitionType,
			},
			Required: true,
			ForceNew: true,
			HCLName:  "name",
			Documentation: sdkModels.TerraformSchemaFieldDocumentationDefinition{
				Markdown: descriptionForResourceIDSegment("Name", displayName, overrides),
			},
		}

		// add the parent resource ID and then the name of the resource
		if resourceDefinition.Overrides != nil {
			updated, err := applySchemaOverrides(parentResourceIdName, *resourceDefinition.Overrides)
			if err != nil {
				return nil, nil, fmt.Errorf("updating schema property from resource ID: %+v", err)
			}
			if updated != nil {
				parentResourceIdName = *updated
			}
		}

		out[parentResourceIdName] = sdkModels.TerraformSchemaField{
			ObjectDefinition: sdkModels.TerraformSchemaObjectDefinition{
				Type: sdkModels.StringTerraformSchemaObjectDefinitionType,
			},
			// since this is included in the Resource ID it's implicitly Required/ForceNew
			Required: true,
			ForceNew: true,
			HCLName:  terraformHelpers.ConvertToSnakeCase(parentResourceIdName),
			Documentation: sdkModels.TerraformSchemaFieldDocumentationDefinition{
				Markdown: descriptionForResourceIDSegment(parentResourceIdName, displayName, overrides),
			},
		}

		mappings.ResourceID = append(mappings.ResourceID, sdkModels.TerraformResourceIDMappingDefinition{
			TerraformSchemaFieldName: "Name",
			SegmentName:              input.Segments[len(input.Segments)-1].Name,
			ParsedFromParentID:       false,
		})

		for _, v := range parentSegments {
			if v.Type == sdkModels.StaticResourceIDSegmentType || v.Type == sdkModels.SubscriptionIDResourceIDSegmentType || v.Type == sdkModels.ResourceProviderResourceIDSegmentType {
				continue
			}

			mappings.ResourceID = append(mappings.ResourceID, sdkModels.TerraformResourceIDMappingDefinition{
				TerraformSchemaFieldName: parentResourceIdName,
				SegmentName:              v.Name,
				ParsedFromParentID:       true,
			})
		}
	} else {
		// TODO: perhaps add the components here instead, aside from Subscription/Tenant ID etc?
		userConfigurableSegments := 0
		for i, v := range input.Segments {
			logging.Tracef("Processing Segment %q", v.Name)
			if v.Type == sdkModels.StaticResourceIDSegmentType || v.Type == sdkModels.SubscriptionIDResourceIDSegmentType || v.Type == sdkModels.ResourceProviderResourceIDSegmentType {
				continue
			}

			userConfigurableSegments++
			fieldName := strings.Title(v.Name)
			if i == len(input.Segments)-1 {
				// if it's the last one override the name since that'll be the name of this Resource
				fieldName = "Name"
			}

			if resourceDefinition.Overrides != nil {
				updated, err := applySchemaOverrides(fieldName, *resourceDefinition.Overrides)
				if err != nil {
					return nil, nil, fmt.Errorf("updating schema property from resource ID: %+v", err)
				}
				if updated != nil {
					fieldName = *updated
				}
			}

			hclName := terraformHelpers.ConvertToSnakeCase(fieldName)
			field := sdkModels.TerraformSchemaField{
				ObjectDefinition: sdkModels.TerraformSchemaObjectDefinition{
					Type: sdkModels.StringTerraformSchemaObjectDefinitionType,
				},
				// since this is included in the Resource ID it's implicitly Required/ForceNew
				Required: true,
				ForceNew: true,
				HCLName:  hclName,
				Documentation: sdkModels.TerraformSchemaFieldDocumentationDefinition{
					Markdown: descriptionForResourceIDSegment(fieldName, displayName, overrides),
				},
			}
			if v.Type == sdkModels.ResourceGroupResourceIDSegmentType {
				field.ObjectDefinition.Type = sdkModels.ResourceGroupTerraformSchemaObjectDefinitionType
			}
			out[fieldName] = field

			mappings.ResourceID = append(mappings.ResourceID, sdkModels.TerraformResourceIDMappingDefinition{
				TerraformSchemaFieldName: fieldName,
				SegmentName:              v.Name,
				ParsedFromParentID:       false,
			})
		}

		if userConfigurableSegments == 0 {
			return nil, nil, fmt.Errorf("no user-configurable segments were found in the Resource ID %q", sdkHelpers.DisplayValueForResourceID(input))
		}
	}

	return out, mappings, nil
}

func descriptionForResourceIDSegment(input, resourceDisplayName string, overrides []definitions.Override) string {
	if overrides != nil && len(overrides) > 0 {
		for _, o := range overrides {
			if o.UpdatedName != nil && strings.EqualFold(input, terraformHelpers.ConvertFromSnakeToTitleCase(*o.UpdatedName)) {
				if o.Description != nil {
					return *o.Description
				}
			}
			if strings.EqualFold(input, terraformHelpers.ConvertFromSnakeToTitleCase(o.Name)) {
				if o.Description != nil {
					return *o.Description
				}
			}
		}
	}

	if strings.EqualFold(input, "Name") {
		return fmt.Sprintf("Specifies the name of this %s.", resourceDisplayName)
	}

	// e.g. AppServiceName -> App Service
	wordified := wordifyParentSegment(input)

	if strings.HasSuffix(input, "Id") {
		return fmt.Sprintf("Specifies the %s within which this %s should exist.", wordified, resourceDisplayName)
	}

	if strings.EqualFold(input, "ResourceGroupName") {
		return fmt.Sprintf("Specifies the name of the %s within which this %s should exist.", wordified, resourceDisplayName)
	}

	return fmt.Sprintf("Specifies the %s of this %s.", wordified, resourceDisplayName)
}

func wordifyParentSegment(input string) string {
	processed := strings.Builder{}

	// first ensure we split the words on spaces
	for i, c := range input {
		runeIsCap := c >= 'A' && c <= 'Z'
		if i != 0 && runeIsCap {
			processed.WriteString(fmt.Sprintf(" %s", string(c)))
			continue
		}
		processed.WriteString(string(c))
	}

	// then title-case each word
	words := strings.Split(processed.String(), " ")
	result := strings.Builder{}
	for i, word := range words {
		// change `resourceGroupName` -> `Resource Group`
		if strings.EqualFold(word, "Name") {
			continue
		}

		if i != 0 {
			result.WriteString(" ")
		}
		result.WriteString(strings.Title(word))
	}
	return result.String()
}

func segmentsMatch(first []sdkModels.ResourceIDSegment, second []sdkModels.ResourceIDSegment) bool {
	if len(first) != len(second) {
		return false
	}

	for i, firstVal := range first {
		secondVal := second[i]
		if firstVal.Type != secondVal.Type {
			return false
		}

		if firstVal.Type == sdkModels.StaticResourceIDSegmentType || firstVal.Type == sdkModels.ResourceProviderResourceIDSegmentType {
			if firstVal.FixedValue == nil || secondVal.FixedValue == nil {
				return false
			}

			if *firstVal.FixedValue != *secondVal.FixedValue {
				return false
			}
		}

		if firstVal.Type == sdkModels.ConstantResourceIDSegmentType {
			if firstVal.ConstantReference == nil || secondVal.ConstantReference == nil {
				return false
			}

			if *firstVal.ConstantReference != *secondVal.ConstantReference {
				return false
			}
		}
	}

	return true
}

func segmentsContainResource(input []sdkModels.ResourceIDSegment) bool {
	penultimateSegmentIsStatic := false
	lastSegmentIsUserSpecifiable := false
	if len(input) >= 4 {
		penultimateSegment := input[len(input)-2]
		lastSegment := input[len(input)-1]

		penultimateSegmentIsStatic = penultimateSegment.Type == sdkModels.StaticResourceIDSegmentType
		lastSegmentIsUserSpecifiable = lastSegment.Type == sdkModels.UserSpecifiedResourceIDSegmentType
	}
	return penultimateSegmentIsStatic && lastSegmentIsUserSpecifiable
}
