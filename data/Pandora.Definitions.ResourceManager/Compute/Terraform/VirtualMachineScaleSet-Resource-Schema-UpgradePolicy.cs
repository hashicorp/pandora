using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.Compute.Terraform;

public class VirtualMachineScaleSetResourceUpgradePolicySchema
{

    [HclName("automatic_os_upgrade_policy")]
    [Optional]
    public VirtualMachineScaleSetResourceAutomaticOSUpgradePolicySchema AutomaticOSUpgradePolicy { get; set; }


    [HclName("mode")]
    [Optional]
    [PossibleValuesFromConstant(typeof(v2021_11_01.VirtualMachineScaleSets.UpgradeModeConstant))]
    public string Mode { get; set; }


    [HclName("rolling_upgrade_policy")]
    [Optional]
    public VirtualMachineScaleSetResourceRollingUpgradePolicySchema RollingUpgradePolicy { get; set; }

}
