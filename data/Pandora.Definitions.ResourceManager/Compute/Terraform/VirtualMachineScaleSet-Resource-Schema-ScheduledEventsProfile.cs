using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.Compute.Terraform;

public class VirtualMachineScaleSetResourceScheduledEventsProfileSchema
{

    [HclName("terminate_notification_profile")]
    [Optional]
    public List<VirtualMachineScaleSetResourceTerminateNotificationProfileSchema> TerminateNotificationProfile { get; set; }

}
