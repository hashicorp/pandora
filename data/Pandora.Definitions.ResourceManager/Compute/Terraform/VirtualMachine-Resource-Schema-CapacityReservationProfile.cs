using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.Compute.Terraform;

public class VirtualMachineResourceCapacityReservationProfileSchema
{

    [HclName("capacity_reservation_group")]
    [Optional]
    public VirtualMachineResourceSubResourceSchema CapacityReservationGroup { get; set; }

}
