using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DevTestLab.v2018_09_15.Labs;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum PremiumDataDiskConstant
{
    [Description("Disabled")]
    Disabled,

    [Description("Enabled")]
    Enabled,
}
