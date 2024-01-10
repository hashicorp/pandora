using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Search.v2023_11_01.Services;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum HostingModeConstant
{
    [Description("default")]
    Default,

    [Description("highDensity")]
    HighDensity,
}
