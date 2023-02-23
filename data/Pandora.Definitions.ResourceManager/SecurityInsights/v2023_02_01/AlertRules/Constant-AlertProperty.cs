using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2023_02_01.AlertRules;

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
