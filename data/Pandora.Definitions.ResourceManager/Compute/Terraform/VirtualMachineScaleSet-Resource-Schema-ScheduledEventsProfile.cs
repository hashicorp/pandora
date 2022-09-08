using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.Compute.Terraform;

public class VirtualMachineScaleSetResourceScheduledEventsProfileSchema
{

    [HclName("terminate_notification_profile")]
    [Optional]
    public VirtualMachineScaleSetResourceTerminateNotificationProfileSchema TerminateNotificationProfile { get; set; }

}
