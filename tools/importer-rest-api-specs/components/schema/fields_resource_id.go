package schema

import (
	"fmt"
	"strings"

	"github.com/hashicorp/go-hclog"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/helpers"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func (b Builder) identityTopLevelFieldsWithinResourceID(input resourcemanager.ResourceIdDefinition, mappings *resourcemanager.MappingDefinition, resourceDisplayName string, logger hclog.Logger) (*map[string]resourcemanager.TerraformSchemaFieldDefinition, *resourcemanager.MappingDefinition, error) {
	out := make(map[string]resourcemanager.TerraformSchemaFieldDefinition, 0)

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

	// TODO: handle using the Parent Resource ID instead where possible, we'd need to thread through the
	// Parent Resource ID here, so this is an enhancement (#1570)

	if userConfigurableSegments == 0 {
		return nil, nil, fmt.Errorf("no user-configurable segments were found in the Resource ID %q", input.Id)
	}

	return &out, mappings, nil
}

func descriptionForResourceIDSegment(input, resourceDisplayName string) string {
	if strings.EqualFold(input, "Name") {
		return fmt.Sprintf("Specifies the name of this %s.", resourceDisplayName)
	}

	// e.g. AppServiceName -> App Service
	wordified := wordifyParentSegment(input)
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
