using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.VMware.v2021_12_01.PrivateClouds;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AvailabilityStrategyConstant
{
    [Description("DualZone")]
    DualZone,

    [Description("SingleZone")]
    SingleZone,
}
