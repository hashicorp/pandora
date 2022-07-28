using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2021_08_01.NetworkInterfaces;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DdosSettingsProtectionCoverageConstant
{
    [Description("Basic")]
    Basic,

    [Description("Standard")]
    Standard,
}
