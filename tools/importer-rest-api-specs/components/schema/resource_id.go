package schema

import (
	"strings"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/helpers"

	"github.com/hashicorp/go-hclog"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func (b Builder) identityTopLevelFieldsWithinResourceID(input resourcemanager.ResourceIdDefinition, mappings *resourcemanager.MappingDefinition, logger hclog.Logger) (*map[string]resourcemanager.TerraformSchemaFieldDefinition, *resourcemanager.MappingDefinition, error) {
	out := make(map[string]resourcemanager.TerraformSchemaFieldDefinition, 0)

	for i, v := range input.Segments {
		if v.Type == resourcemanager.StaticSegment || v.Type == resourcemanager.SubscriptionIdSegment {
			continue
		}

		fieldName := strings.Title(v.Name)
		hclName := helpers.ConvertToSnakeCase(v.Name)
		if i == len(input.Segments)-1 {
			// if it's the last one override the name since that'll be the name of this Resource
			fieldName = "Name"
			hclName = "name"
		}
		out[fieldName] = resourcemanager.TerraformSchemaFieldDefinition{
			ObjectDefinition: resourcemanager.TerraformSchemaFieldObjectDefinition{
				Type: resourcemanager.TerraformSchemaFieldTypeString,
			},
			// since this is included in the Resource ID it's implicitly Required/ForceNew
			Required: true,
			ForceNew: true,
			HclName:  hclName,
			Documentation: resourcemanager.TerraformSchemaDocumentationDefinition{
				Markdown: "The name which should be used for this resource", // TODO get resource name here?
			},
		}
		mappings.ResourceId = append(mappings.ResourceId, resourcemanager.ResourceIdMappingDefinition{
			SchemaFieldName: fieldName,
			SegmentName:     v.Name,
		})
	}

	// TODO: handle using the Parent Resource ID instead where possible, we'd need to thread through the
	// Parent Resource ID here, so this is an enhancement

	return &out, mappings, nil
}
