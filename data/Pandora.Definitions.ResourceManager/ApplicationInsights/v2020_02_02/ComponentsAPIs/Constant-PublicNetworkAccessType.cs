using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ApplicationInsights.v2020_02_02.ComponentsAPIs;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum PublicNetworkAccessTypeConstant
{
    [Description("Disabled")]
    Disabled,

    [Description("Enabled")]
    Enabled,
}
