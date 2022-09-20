using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.Compute.Terraform;

public class VirtualMachineScaleSetResourceAutomaticOSUpgradePolicySchema
{

    [HclName("automatic_osupgrade_enabled")]
    [Optional]
    public bool AutomaticOSUpgradeEnabled { get; set; }


    [HclName("automatic_rollback_disabled")]
    [Optional]
    public bool AutomaticRollbackDisabled { get; set; }

}
