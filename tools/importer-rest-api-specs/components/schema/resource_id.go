package schema

import (
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func (b Builder) identityTopLevelFieldsWithinResourceID(input resourcemanager.ResourceIdDefinition) (*map[string]resourcemanager.TerraformSchemaFieldDefinition, error) {
	out := make(map[string]resourcemanager.TerraformSchemaFieldDefinition, 0)

	// TODO: mappings
	out["Name"] = resourcemanager.TerraformSchemaFieldDefinition{
		ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
			Type: resourcemanager.TerraformSchemaFieldTypeString,
		},
		// since this is included in the Resource ID it's implicitly Required/ForceNew
		Required: true,
		ForceNew: true,
		HclName:  "name",
	}

	if len(input.Segments) > 2 {
		parentSegments := input.Segments[0 : len(input.Segments)-2]
		if segmentsContainResource(parentSegments) {
			// find the parent Resource ID and use that
			parentResourceIdName := ""
			for name, id := range b.resourceIds {
				if segmentsMatch(id.Segments, parentSegments) {
					parentResourceIdName = name
					break
				}
			}
			if parentResourceIdName != "" {
				parentResourceSchemaField := convertToSnakeCase(parentResourceIdName)
				out[parentResourceIdName] = resourcemanager.TerraformSchemaFieldDefinition{
					ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
						Type:          resourcemanager.TerraformSchemaFieldTypeReference,
						ReferenceName: &parentResourceIdName,
					},
					// since this is included in the Resource ID it's implicitly Required/ForceNew
					Required: true,
					ForceNew: true,
					HclName:  parentResourceSchemaField,
				}
			}
			// TODO: perhaps add the components here instead, aside from Subscription/Tenant ID etc?
		} else {
			// NOTE: Happy path case where we have a "standard" ID `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroup}/...`
			if len(input.Segments) != 4 && input.Segments[2].FixedValue != nil && *input.Segments[2].FixedValue == "resourceGroups" {
				out["ResourceGroupName"] = resourcemanager.TerraformSchemaFieldDefinition{
					ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
						Type: resourcemanager.TerraformSchemaFieldTypeResourceGroup,
					},
					Required: true,
					ForceNew: true,
					HclName:  "resource_group_name",
				}
			}
		}
	}

	return &out, nil
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
