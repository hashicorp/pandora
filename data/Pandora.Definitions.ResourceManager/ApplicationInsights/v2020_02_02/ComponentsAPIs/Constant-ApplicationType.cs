using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ApplicationInsights.v2020_02_02.ComponentsAPIs;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ApplicationTypeConstant
{
    [Description("other")]
    Other,

    [Description("web")]
    Web,
}
