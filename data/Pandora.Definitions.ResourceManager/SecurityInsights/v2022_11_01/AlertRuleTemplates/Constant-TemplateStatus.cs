using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2022_11_01.AlertRuleTemplates;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum TemplateStatusConstant
{
    [Description("Available")]
    Available,

    [Description("Installed")]
    Installed,

    [Description("NotAvailable")]
    NotAvailable,
}
