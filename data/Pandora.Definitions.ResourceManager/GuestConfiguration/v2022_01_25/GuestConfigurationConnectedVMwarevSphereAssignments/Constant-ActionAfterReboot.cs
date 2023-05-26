using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.GuestConfiguration.v2022_01_25.GuestConfigurationConnectedVMwarevSphereAssignments;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ActionAfterRebootConstant
{
    [Description("ContinueConfiguration")]
    ContinueConfiguration,

    [Description("StopConfiguration")]
    StopConfiguration,
}
