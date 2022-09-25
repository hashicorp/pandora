package dataapigenerator

import (
	"fmt"
	"sort"
	"strings"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func codeForTerraformResourceMappings(terraformNamespace string, apiResourceNamespace string, details resourcemanager.TerraformResourceDetails) string {
	resourceIdMappings := make([]string, 0)
	for _, item := range details.Mappings.ResourceId {
		line := fmt.Sprintf("Mapping.FromSchema<%[1]sResourceSchema>(s => s.%[2]s).ToResourceIdSegmentNamed(%[3]q),", details.ResourceName, item.SchemaFieldName, item.SegmentName)
		resourceIdMappings = append(resourceIdMappings, line)
	}
	sort.Strings(resourceIdMappings)

	// TODO: schema models are available in details.SchemaModels
	// TODO: the main schema name is available in details.SchemaModelName

	// Mapping.FromSchema<%[2]sResourceSchema>(s => s.Location).ToSdkField<%[2]sModel>(m => m.Location),
	// Mapping.FromSchema<%[2]sResourceSchema>(s => s.Tags).ToSdkField<%[2]sModel>(m => m.Tags),
	// Mapping.FromSchema<%[2]sResourceSchema>(s => s.UniqueId).ToSdkField<%[2]sModel>(m => m.Properties.UniqueId),

	// Mapping.FromSchema<%[2]sResourceSchema>(s => s.DataDisks).ToSdkModel<%[2]sDataDiskModel>(),
	// Mapping.FromSchema<%[2]sDataDiskSchemaModel>(s => s.Name).ToSdkField<%[2]sDataDiskModel>(m => m.Name),

	return fmt.Sprintf(`using System.Collections.Generic;
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
`, terraformNamespace, details.ResourceName, apiResourceNamespace, strings.Join(resourceIdMappings, "\n"))
}
