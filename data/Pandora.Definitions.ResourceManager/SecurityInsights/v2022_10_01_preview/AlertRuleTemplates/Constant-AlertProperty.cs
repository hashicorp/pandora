using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2022_10_01_preview.AlertRuleTemplates;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AlertPropertyConstant
{
    [Description("AlertLink")]
    AlertLink,

    [Description("ConfidenceLevel")]
    ConfidenceLevel,

    [Description("ConfidenceScore")]
    ConfidenceScore,

    [Description("ExtendedLinks")]
    ExtendedLinks,

    [Description("ProductComponentName")]
    ProductComponentName,

    [Description("ProductName")]
    ProductName,

    [Description("ProviderName")]
    ProviderName,

    [Description("RemediationSteps")]
    RemediationSteps,

    [Description("Techniques")]
    Techniques,
}
