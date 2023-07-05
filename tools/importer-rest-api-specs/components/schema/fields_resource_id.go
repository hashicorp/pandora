package schema

import (
	"fmt"
	"strings"

	"github.com/hashicorp/go-hclog"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/helpers"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func (b Builder) identifyTopLevelFieldsWithinResourceID(input resourcemanager.ResourceIdDefinition, mappings *resourcemanager.MappingDefinition, resourceDisplayName string, logger hclog.Logger) (*map[string]resourcemanager.TerraformSchemaFieldDefinition, *resourcemanager.MappingDefinition, error) {
	out := make(map[string]resourcemanager.TerraformSchemaFieldDefinition, 0)

	// first determine whether we are dealing with a nested resource
	parentResourceFound := false
	parentResourceIdName := ""
	parentSegments := make([]resourcemanager.ResourceIdSegment, 0)
	if len(input.Segments) > 2 {
		parentSegments = input.Segments[0 : len(input.Segments)-2]
		if segmentsContainResource(parentSegments) {
			parentResourceFound = true
			// find the parent Resource ID and use that
			for name, id := range b.resourceIds {
				if segmentsMatch(id.Segments, parentSegments) {
					parentResourceIdName = name
					break
				}
			}
		}
	}

	if parentResourceFound && parentResourceIdName == "" {
		logger.Debug("parent resource detected for %s but was not present in resource's ID definitions", resourceDisplayName)
	}

	// if a parent is resource is found and present in the ResourceID mappings then we use this
	if parentResourceIdName != "" {
		// add field definition for the resource name
		out["Name"] = resourcemanager.TerraformSchemaFieldDefinition{
			ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
				Type: resourcemanager.TerraformSchemaFieldTypeString,
			},
			Required: true,
			ForceNew: true,
			HclName:  "name",
			Documentation: resourcemanager.TerraformSchemaDocumentationDefinition{
				Markdown: descriptionForResourceIDSegment("Name", resourceDisplayName),
			},
		}

		// add the parent resource ID and then the name of the resource
		parentResourceSchemaField := helpers.ConvertToSnakeCase(parentResourceIdName)
		out[parentResourceIdName] = resourcemanager.TerraformSchemaFieldDefinition{
			ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
				Type: resourcemanager.TerraformSchemaFieldTypeString,
			},
			// since this is included in the Resource ID it's implicitly Required/ForceNew
			Required: true,
			ForceNew: true,
			HclName:  parentResourceSchemaField,
			Documentation: resourcemanager.TerraformSchemaDocumentationDefinition{
				Markdown: descriptionForResourceIDSegment(parentResourceIdName, resourceDisplayName),
			},
		}

		mappings.ResourceId = append(mappings.ResourceId, resourcemanager.ResourceIdMappingDefinition{
			SchemaFieldName: "Name",
			SegmentName:     input.Segments[len(input.Segments)-1].Name,
		})

		for _, v := range parentSegments {
			if v.Type == resourcemanager.StaticSegment || v.Type == resourcemanager.SubscriptionIdSegment || v.Type == resourcemanager.ResourceProviderSegment {
				continue
			}

			mappings.ResourceId = append(mappings.ResourceId, resourcemanager.ResourceIdMappingDefinition{
				SchemaFieldName: parentResourceIdName,
				SegmentName:     v.Name,
				Parent:          true,
			})
		}
	} else {
		// TODO: perhaps add the components here instead, aside from Subscription/Tenant ID etc?
		userConfigurableSegments := 0
		for i, v := range input.Segments {
			logger.Trace(fmt.Sprintf("Processing Segment %q", v.Name))
			if v.Type == resourcemanager.StaticSegment || v.Type == resourcemanager.SubscriptionIdSegment || v.Type == resourcemanager.ResourceProviderSegment {
				continue
			}

			userConfigurableSegments++
			fieldName := strings.Title(v.Name)
			hclName := helpers.ConvertToSnakeCase(v.Name)
			if i == len(input.Segments)-1 {
				// if it's the last one override the name since that'll be the name of this Resource
				fieldName = "Name"
				hclName = "name"
			}
			field := resourcemanager.TerraformSchemaFieldDefinition{
				ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
					Type: resourcemanager.TerraformSchemaFieldTypeString,
				},
				// since this is included in the Resource ID it's implicitly Required/ForceNew
				Required: true,
				ForceNew: true,
				HclName:  hclName,
				Documentation: resourcemanager.TerraformSchemaDocumentationDefinition{
					Markdown: descriptionForResourceIDSegment(fieldName, resourceDisplayName),
				},
			}
			if v.Type == resourcemanager.ResourceGroupSegment {
				field.ObjectDefinition.Type = resourcemanager.TerraformSchemaFieldTypeResourceGroup
			}
			out[fieldName] = field

			mappings.ResourceId = append(mappings.ResourceId, resourcemanager.ResourceIdMappingDefinition{
				SchemaFieldName: fieldName,
				SegmentName:     v.Name,
			})
		}

		if userConfigurableSegments == 0 {
			return nil, nil, fmt.Errorf("no user-configurable segments were found in the Resource ID %q", input.Id)
		}
	}

	return &out, mappings, nil
}

func descriptionForResourceIDSegment(input, resourceDisplayName string) string {
	if strings.EqualFold(input, "Name") {
		return fmt.Sprintf("Specifies the name of this %s.", resourceDisplayName)
	}

	// e.g. AppServiceName -> App Service
	wordified := wordifyParentSegment(input)

	if strings.HasSuffix(input, "Id") {
		return fmt.Sprintf("Specifies the %s within which this %s should exist.", wordified, resourceDisplayName)
	}

	return fmt.Sprintf("Specifies the name of the %s within which this %s should exist.", wordified, resourceDisplayName)
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

func segmentsMatch(first []resourcemanager.ResourceIdSegment, second []resourcemanager.ResourceIdSegment) bool {
	if len(first) != len(second) {
		return false
	}

	for i, firstVal := range first {
		secondVal := second[i]
		if firstVal.Type != secondVal.Type {
			return false
		}

		if firstVal.Type == resourcemanager.StaticSegment || firstVal.Type == resourcemanager.ResourceProviderSegment {
			if firstVal.FixedValue == nil || secondVal.FixedValue == nil {
				return false
			}

			if *firstVal.FixedValue != *secondVal.FixedValue {
				return false
			}
		}

		if firstVal.Type == resourcemanager.ConstantSegment {
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

func segmentsContainResource(input []resourcemanager.ResourceIdSegment) bool {
	penultimateSegmentIsStatic := false
	lastSegmentIsUserSpecifiable := false
	if len(input) >= 4 {
		penultimateSegment := input[len(input)-2]
		lastSegment := input[len(input)-1]

		penultimateSegmentIsStatic = penultimateSegment.Type == resourcemanager.StaticSegment
		lastSegmentIsUserSpecifiable = lastSegment.Type == resourcemanager.UserSpecifiedSegment
	}
	return penultimateSegmentIsStatic && lastSegmentIsUserSpecifiable
}
