package dataapigenerator

import (
	"fmt"
	"sort"
	"strings"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func codeForTerraformResourceMappings(terraformNamespace string, apiResourceNamespace string, details resourcemanager.TerraformResourceDetails) (*string, error) {
	resourceIdMappings := make([]string, 0)
	for _, item := range details.Mappings.ResourceId {
		line := fmt.Sprintf("Mapping.FromSchema<%[1]sResourceSchema>(s => s.%[2]s).ToResourceIdSegmentNamed(%[3]q)", details.ResourceName, item.SchemaFieldName, item.SegmentName)
		resourceIdMappings = append(resourceIdMappings, fmt.Sprintf("\t\t%s,", line))
	}
	sort.Strings(resourceIdMappings)

	// TODO: schema models are available in details.SchemaModels
	// TODO: the main schema name is available in details.SchemaModelName

	// Mapping.FromSchema<%[2]sResourceSchema>(s => s.Location).ToSdkField<%[2]sModel>(m => m.Location),
	// Mapping.FromSchema<%[2]sResourceSchema>(s => s.Tags).ToSdkField<%[2]sModel>(m => m.Tags),
	// Mapping.FromSchema<%[2]sResourceSchema>(s => s.UniqueId).ToSdkField<%[2]sModel>(m => m.Properties.UniqueId),

	// Mapping.FromSchema<%[2]sResourceSchema>(s => s.DataDisks).ToSdkModel<%[2]sDataDiskModel>(),
	// Mapping.FromSchema<%[2]sDataDiskSchemaModel>(s => s.Name).ToSdkField<%[2]sDataDiskModel>(m => m.Name),

	createMappings := make([]string, 0)
	for _, item := range details.Mappings.Create {
		line, err := codeForTerraformFieldMapping(item)
		if err != nil {
			return nil, fmt.Errorf("building mapping: %+v", err)
		}
		createMappings = append(createMappings, fmt.Sprintf("\t\t%s,", *line))
	}
	sort.Strings(createMappings)

	updateMappings := make([]string, 0)
	if details.Mappings.Update != nil {
		for _, item := range *details.Mappings.Update {
			line, err := codeForTerraformFieldMapping(item)
			if err != nil {
				return nil, fmt.Errorf("building mapping: %+v", err)
			}
			updateMappings = append(updateMappings, fmt.Sprintf("\t\t%s,", *line))
		}
	}
	sort.Strings(updateMappings)

	readMappings := make([]string, 0)
	for _, item := range details.Mappings.Read {
		line, err := codeForTerraformFieldMapping(item)
		if err != nil {
			return nil, fmt.Errorf("building mapping: %+v", err)
		}
		readMappings = append(readMappings, fmt.Sprintf("\t\t%s,", *line))
	}
	sort.Strings(readMappings)

	mappings := make([]string, 0)
	if len(resourceIdMappings) > 0 {
		mappings = append(mappings, strings.Join(resourceIdMappings, "\n"))
	}
	if len(createMappings) > 0 {
		mappings = append(mappings, strings.Join(createMappings, "\n"))
	}
	// TODO: if the models are reused for Create/Read and/or Update, we should output these once?
	if len(updateMappings) > 0 {
		mappings = append(mappings, strings.Join(updateMappings, "\n"))
	}
	if len(readMappings) > 0 {
		mappings = append(mappings, strings.Join(readMappings, "\n"))
	}

	out := fmt.Sprintf(`using System.Collections.Generic;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Mappings;
using %[3]s;

namespace %[1]s;

public class %[2]sResourceMappings : TerraformMappingDefinition
{
    public List<MappingType> Mappings => new List<MappingType>
    {
%[4]s
    };
}
`, terraformNamespace, details.ResourceName, apiResourceNamespace, strings.Join(mappings, "\n\n"))
	return &out, nil
}

func codeForTerraformFieldMapping(input resourcemanager.FieldMappingDefinition) (*string, error) {
	// all field mappings are extension methods on `ToSdkField` (which returns `MappingDefinition`) so we can compute
	// this once and just template the extension method below
	mapping := fmt.Sprintf("Mapping.FromSchema<%[1]sSchema>(s => s.%[2]s).ToSdkField<%[3]sModel>(m => m.%[4]s)", input.DirectAssignment.SchemaModelName, input.DirectAssignment.SchemaFieldPath, input.DirectAssignment.SdkModelName, input.DirectAssignment.SdkFieldPath)

	switch input.Type {
	// TODO: BooleanEquals etc
	case resourcemanager.DirectAssignmentMappingDefinitionType:
		{
			out := fmt.Sprintf("%s.Direct()", mapping)
			return &out, nil
		}
	}

	return nil, fmt.Errorf("unimplemented mapping type %q", string(input.Type))
}
