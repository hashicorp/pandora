// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package schema

import (
	"fmt"
	"strings"

	"github.com/hashicorp/go-hclog"
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/helpers"
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	terraformHelpers "github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/terraform/helpers"
	terraformModels "github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/terraform/models"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func (b Builder) identifyTopLevelFieldsWithinResourceID(input models.ResourceID, mappings *resourcemanager.MappingDefinition, displayName string, resourceBuildInfo *terraformModels.ResourceBuildInfo, logger hclog.Logger) (*map[string]resourcemanager.TerraformSchemaFieldDefinition, *resourcemanager.MappingDefinition, error) {
	out := make(map[string]resourcemanager.TerraformSchemaFieldDefinition)
	overrides := make([]terraformModels.Override, 0)

	if resourceBuildInfo != nil && resourceBuildInfo.Overrides != nil {
		overrides = resourceBuildInfo.Overrides
	}

	// first determine whether we are dealing with a nested resource
	parentResourceFound := false
	parentResourceIdName := ""
	parentSegments := make([]models.ResourceIDSegment, 0)
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
		logger.Debug("parent resource detected for %s but was not present in resource's ID definitions", displayName)
	}

	// if a parent is resource is found and present in the ResourceID mappings then we use this
	if parentResourceIdName != "" {
		// add field definition for the resource name
		out["Name"] = resourcemanager.TerraformSchemaFieldDefinition{
			ObjectDefinition: models.TerraformSchemaObjectDefinition{
				Type: models.StringTerraformSchemaObjectDefinitionType,
			},
			Required: true,
			ForceNew: true,
			HclName:  "name",
			Documentation: models.TerraformSchemaFieldDocumentationDefinition{
				Markdown: descriptionForResourceIDSegment("Name", displayName, overrides),
			},
		}

		// add the parent resource ID and then the name of the resource
		if resourceBuildInfo != nil && resourceBuildInfo.Overrides != nil {
			updated, err := applySchemaOverrides(parentResourceIdName, resourceBuildInfo.Overrides)
			if err != nil {
				return nil, nil, fmt.Errorf("updating schema property from resource ID: %+v", err)
			}
			if updated != nil {
				parentResourceIdName = *updated
			}
		}

		out[parentResourceIdName] = resourcemanager.TerraformSchemaFieldDefinition{
			ObjectDefinition: models.TerraformSchemaObjectDefinition{
				Type: models.StringTerraformSchemaObjectDefinitionType,
			},
			// since this is included in the Resource ID it's implicitly Required/ForceNew
			Required: true,
			ForceNew: true,
			HclName:  terraformHelpers.ConvertToSnakeCase(parentResourceIdName),
			Documentation: models.TerraformSchemaFieldDocumentationDefinition{
				Markdown: descriptionForResourceIDSegment(parentResourceIdName, displayName, overrides),
			},
		}

		mappings.ResourceId = append(mappings.ResourceId, resourcemanager.ResourceIdMappingDefinition{
			SchemaFieldName: "Name",
			SegmentName:     input.Segments[len(input.Segments)-1].Name,
		})

		for _, v := range parentSegments {
			if v.Type == models.StaticResourceIDSegmentType || v.Type == models.SubscriptionIDResourceIDSegmentType || v.Type == models.ResourceProviderResourceIDSegmentType {
				continue
			}

			mappings.ResourceId = append(mappings.ResourceId, resourcemanager.ResourceIdMappingDefinition{
				SchemaFieldName:    parentResourceIdName,
				SegmentName:        v.Name,
				ParsedFromParentID: true,
			})
		}
	} else {
		// TODO: perhaps add the components here instead, aside from Subscription/Tenant ID etc?
		userConfigurableSegments := 0
		for i, v := range input.Segments {
			logger.Trace(fmt.Sprintf("Processing Segment %q", v.Name))
			if v.Type == models.StaticResourceIDSegmentType || v.Type == models.SubscriptionIDResourceIDSegmentType || v.Type == models.ResourceProviderResourceIDSegmentType {
				continue
			}

			userConfigurableSegments++
			fieldName := strings.Title(v.Name)
			if i == len(input.Segments)-1 {
				// if it's the last one override the name since that'll be the name of this Resource
				fieldName = "Name"
			}

			if resourceBuildInfo != nil && resourceBuildInfo.Overrides != nil {
				updated, err := applySchemaOverrides(fieldName, resourceBuildInfo.Overrides)
				if err != nil {
					return nil, nil, fmt.Errorf("updating schema property from resource ID: %+v", err)
				}
				if updated != nil {
					fieldName = *updated
				}
			}

			hclName := terraformHelpers.ConvertToSnakeCase(fieldName)

			field := resourcemanager.TerraformSchemaFieldDefinition{
				ObjectDefinition: models.TerraformSchemaObjectDefinition{
					Type: models.StringTerraformSchemaObjectDefinitionType,
				},
				// since this is included in the Resource ID it's implicitly Required/ForceNew
				Required: true,
				ForceNew: true,
				HclName:  hclName,
				Documentation: models.TerraformSchemaFieldDocumentationDefinition{
					Markdown: descriptionForResourceIDSegment(fieldName, displayName, overrides),
				},
			}
			if v.Type == models.ResourceGroupResourceIDSegmentType {
				field.ObjectDefinition.Type = models.ResourceGroupTerraformSchemaObjectDefinitionType
			}
			out[fieldName] = field

			mappings.ResourceId = append(mappings.ResourceId, resourcemanager.ResourceIdMappingDefinition{
				SchemaFieldName: fieldName,
				SegmentName:     v.Name,
			})
		}

		if userConfigurableSegments == 0 {
			return nil, nil, fmt.Errorf("no user-configurable segments were found in the Resource ID %q", helpers.DisplayValueForResourceID(input))
		}
	}

	return &out, mappings, nil
}

func descriptionForResourceIDSegment(input, resourceDisplayName string, overrides []terraformModels.Override) string {
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

func segmentsMatch(first []models.ResourceIDSegment, second []models.ResourceIDSegment) bool {
	if len(first) != len(second) {
		return false
	}

	for i, firstVal := range first {
		secondVal := second[i]
		if firstVal.Type != secondVal.Type {
			return false
		}

		if firstVal.Type == models.StaticResourceIDSegmentType || firstVal.Type == models.ResourceProviderResourceIDSegmentType {
			if firstVal.FixedValue == nil || secondVal.FixedValue == nil {
				return false
			}

			if *firstVal.FixedValue != *secondVal.FixedValue {
				return false
			}
		}

		if firstVal.Type == models.ConstantResourceIDSegmentType {
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

func segmentsContainResource(input []models.ResourceIDSegment) bool {
	penultimateSegmentIsStatic := false
	lastSegmentIsUserSpecifiable := false
	if len(input) >= 4 {
		penultimateSegment := input[len(input)-2]
		lastSegment := input[len(input)-1]

		penultimateSegmentIsStatic = penultimateSegment.Type == models.StaticResourceIDSegmentType
		lastSegmentIsUserSpecifiable = lastSegment.Type == models.UserSpecifiedResourceIDSegmentType
	}
	return penultimateSegmentIsStatic && lastSegmentIsUserSpecifiable
}
