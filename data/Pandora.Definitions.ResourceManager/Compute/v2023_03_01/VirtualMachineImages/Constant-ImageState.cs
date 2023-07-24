using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Compute.v2023_03_01.VirtualMachineImages;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ImageStateConstant
{
    [Description("Active")]
    Active,

    [Description("Deprecated")]
    Deprecated,

    [Description("ScheduledForDeprecation")]
    ScheduledForDeprecation,
}
