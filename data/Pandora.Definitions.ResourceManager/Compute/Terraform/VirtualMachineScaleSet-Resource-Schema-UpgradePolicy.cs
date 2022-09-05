using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.Compute.Terraform;

public class VirtualMachineScaleSetResourceUpgradePolicySchema
{

    [HclName("automatic_os_upgrade_policy")]
    [Optional]
    public List<VirtualMachineScaleSetResourceAutomaticOSUpgradePolicySchema> AutomaticOSUpgradePolicy { get; set; }


    [HclName("mode")]
    [Optional]
    public string Mode { get; set; }


    [HclName("rolling_upgrade_policy")]
    [Optional]
    public List<VirtualMachineScaleSetResourceRollingUpgradePolicySchema> RollingUpgradePolicy { get; set; }

}
