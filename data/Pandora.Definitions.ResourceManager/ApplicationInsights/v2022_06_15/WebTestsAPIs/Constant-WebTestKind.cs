using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ApplicationInsights.v2022_06_15.WebTestsAPIs;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum WebTestKindConstant
{
    [Description("multistep")]
    Multistep,

    [Description("ping")]
    Ping,

    [Description("standard")]
    Standard,
}
