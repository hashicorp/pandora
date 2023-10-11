using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.AppPlatform.v2023_09_01_preview.AppPlatform;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ApmTypeConstant
{
    [Description("AppDynamics")]
    AppDynamics,

    [Description("ApplicationInsights")]
    ApplicationInsights,

    [Description("Dynatrace")]
    Dynatrace,

    [Description("ElasticAPM")]
    ElasticAPM,

    [Description("NewRelic")]
    NewRelic,
}
