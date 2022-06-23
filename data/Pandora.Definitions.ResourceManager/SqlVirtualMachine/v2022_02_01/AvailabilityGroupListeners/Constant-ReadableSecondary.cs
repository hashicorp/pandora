using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.SqlVirtualMachine.v2022_02_01.AvailabilityGroupListeners;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ReadableSecondaryConstant
{
    [Description("ALL")]
    ALL,

    [Description("NO")]
    NO,

    [Description("READ_ONLY")]
    READONLY,
}
