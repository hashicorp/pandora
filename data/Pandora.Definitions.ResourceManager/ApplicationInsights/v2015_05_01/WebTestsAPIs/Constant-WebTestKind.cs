using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ApplicationInsights.v2015_05_01.WebTestsAPIs;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum WebTestKindConstant
{
    [Description("multistep")]
    Multistep,

    [Description("ping")]
    Ping,
}
