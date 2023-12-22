using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.NetApp.v2023_07_01.VolumeGroups;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum NetworkFeaturesConstant
{
    [Description("Basic")]
    Basic,

    [Description("Basic_Standard")]
    BasicStandard,

    [Description("Standard")]
    Standard,

    [Description("Standard_Basic")]
    StandardBasic,
}
