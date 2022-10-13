using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.AppPlatform.v2022_09_01_preview.AppPlatform;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum BindingTypeConstant
{
    [Description("ApacheSkyWalking")]
    ApacheSkyWalking,

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
