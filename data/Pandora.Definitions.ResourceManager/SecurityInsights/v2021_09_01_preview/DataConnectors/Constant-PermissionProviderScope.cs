using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2021_09_01_preview.DataConnectors;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum PermissionProviderScopeConstant
{
    [Description("ResourceGroup")]
    ResourceGroup,

    [Description("Subscription")]
    Subscription,

    [Description("Workspace")]
    Workspace,
}
