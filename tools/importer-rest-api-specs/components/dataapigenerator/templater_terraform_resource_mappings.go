package dataapigenerator

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func codeForTerraformResourceMappings(terraformNamespace string, details resourcemanager.TerraformResourceDetails) string {
	return fmt.Sprintf(`using System.Collections.Generic;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Mappings;
// using Pandora.Definitions.ResourceManager.Compute.v2021_11_01.VirtualMachineScaleSets;

namespace %[1]s;

public class %[2]sResourceMappings : TerraformMappingDefinition
{
    public List<Mapping> Mappings => new List<Mapping>
    {
        // Mapping.FromSchema<%[2]sResourceSchema>(s => s.Name).ToResourceIdSegmentNamed("virtualMachineScaleSetName"),
        // Mapping.FromSchema<%[2]sResourceSchema>(s => s.ResourceGroupName).ToResourceIdSegmentNamed("resourceGroupName"),

        // Mapping.FromSchema<%[2]sResourceSchema>(s => s.Location).ToSdkModelField<%[2]sModel>(m => m.Location),
        // Mapping.FromSchema<%[2]sResourceSchema>(s => s.Tags).ToSdkModelField<%[2]sModel>(m => m.Tags),
        // Mapping.FromSchema<%[2]sResourceSchema>(s => s.UniqueId).ToSdkModelField<%[2]sModel>(m => m.Properties.UniqueId),

        // Mapping.FromSchema<%[2]sResourceSchema>(s => s.DataDisks).ToSdkModel<%[2]sDataDiskModel>(),
        // Mapping.FromSchema<%[2]sDataDiskSchemaModel>(s => s.Name).ToSdkModelField<%[2]sDataDiskModel>(m => m.Name),
    };
}
`, terraformNamespace, details.ResourceName)
}
