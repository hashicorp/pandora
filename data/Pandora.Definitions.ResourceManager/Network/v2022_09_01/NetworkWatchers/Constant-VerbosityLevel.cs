using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2022_09_01.NetworkWatchers;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum VerbosityLevelConstant
{
    [Description("Full")]
    Full,

    [Description("Minimum")]
    Minimum,

    [Description("Normal")]
    Normal,
}
