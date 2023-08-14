using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.VMware.v2023_03_01.Locations;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum QuotaEnabledConstant
{
    [Description("Disabled")]
    Disabled,

    [Description("Enabled")]
    Enabled,
}
