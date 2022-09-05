using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.Compute.Terraform;

public class VirtualMachineResourceCapacityReservationProfileSchema
{

    [HclName("capacity_reservation_group_id")]
    [Optional]
    public List<VirtualMachineResourceSubResourceSchema> CapacityReservationGroupId { get; set; }

}
