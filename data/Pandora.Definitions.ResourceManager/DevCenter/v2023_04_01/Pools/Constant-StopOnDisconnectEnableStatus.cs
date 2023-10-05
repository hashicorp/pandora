using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DevCenter.v2023_04_01.Pools;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum StopOnDisconnectEnableStatusConstant
{
    [Description("Disabled")]
    Disabled,

    [Description("Enabled")]
    Enabled,
}
