using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.AlertsManagement.v2019_05_05_preview.ActionRules;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ScopeTypeConstant
{
    [Description("Resource")]
    Resource,

    [Description("ResourceGroup")]
    ResourceGroup,

    [Description("Subscription")]
    Subscription,
}
