using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.Compute.Terraform;

public class VirtualMachineScaleSetResourceCapacityReservationProfileSchema
{

    [HclName("capacity_reservation_group_id")]
    [Optional]
    public VirtualMachineScaleSetResourceSubResourceSchema CapacityReservationGroupId { get; set; }

}
