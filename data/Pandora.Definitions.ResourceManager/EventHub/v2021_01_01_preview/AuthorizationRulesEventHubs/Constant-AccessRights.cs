using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.EventHub.v2021_01_01_preview.AuthorizationRulesEventHubs;

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
