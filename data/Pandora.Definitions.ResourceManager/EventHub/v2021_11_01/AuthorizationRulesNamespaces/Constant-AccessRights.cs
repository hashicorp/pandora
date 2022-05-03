using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.EventHub.v2021_11_01.AuthorizationRulesNamespaces;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AccessRightsConstant
{
    [Description("Listen")]
    Listen,

    [Description("Manage")]
    Manage,

    [Description("Send")]
    Send,
}
