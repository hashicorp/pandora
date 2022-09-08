using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.Compute.Terraform;

public class VirtualMachineScaleSetResourceRollingUpgradePolicySchema
{

    [HclName("cross_zone_upgrade_enabled")]
    [Optional]
    public bool CrossZoneUpgradeEnabled { get; set; }


    [HclName("max_batch_instance_percent")]
    [Optional]
    public int MaxBatchInstancePercent { get; set; }


    [HclName("max_unhealthy_instance_percent")]
    [Optional]
    public int MaxUnhealthyInstancePercent { get; set; }


    [HclName("max_unhealthy_upgraded_instance_percent")]
    [Optional]
    public int MaxUnhealthyUpgradedInstancePercent { get; set; }


    [HclName("pause_time_between_batches")]
    [Optional]
    public string PauseTimeBetweenBatches { get; set; }


    [HclName("prioritize_unhealthy_instances")]
    [Optional]
    public bool PrioritizeUnhealthyInstances { get; set; }

}
