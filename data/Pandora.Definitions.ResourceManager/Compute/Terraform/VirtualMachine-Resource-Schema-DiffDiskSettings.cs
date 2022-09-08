using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.Compute.Terraform;

public class VirtualMachineResourceDiffDiskSettingsSchema
{

    [HclName("option")]
    [Optional]
    [PossibleValuesFromConstant(typeof(v2021_11_01.VirtualMachines.DiffDiskOptionsConstant))]
    public string Option { get; set; }


    [HclName("placement")]
    [Optional]
    [PossibleValuesFromConstant(typeof(v2021_11_01.VirtualMachines.DiffDiskPlacementConstant))]
    public string Placement { get; set; }

}
