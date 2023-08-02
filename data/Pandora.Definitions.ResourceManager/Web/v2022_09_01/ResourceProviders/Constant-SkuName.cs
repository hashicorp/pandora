using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Web.v2022_09_01.ResourceProviders;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SkuNameConstant
{
    [Description("Basic")]
    Basic,

    [Description("Dynamic")]
    Dynamic,

    [Description("ElasticIsolated")]
    ElasticIsolated,

    [Description("ElasticPremium")]
    ElasticPremium,

    [Description("Free")]
    Free,

    [Description("Isolated")]
    Isolated,

    [Description("IsolatedV2")]
    IsolatedVTwo,

    [Description("Premium")]
    Premium,

    [Description("PremiumContainer")]
    PremiumContainer,

    [Description("PremiumV3")]
    PremiumVThree,

    [Description("PremiumV2")]
    PremiumVTwo,

    [Description("Shared")]
    Shared,

    [Description("Standard")]
    Standard,
}
