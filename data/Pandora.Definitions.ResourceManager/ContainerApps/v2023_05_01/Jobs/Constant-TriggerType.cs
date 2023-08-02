using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ContainerApps.v2023_05_01.Jobs;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum TriggerTypeConstant
{
    [Description("Event")]
    Event,

    [Description("Manual")]
    Manual,

    [Description("Schedule")]
    Schedule,
}
