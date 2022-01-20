using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.EventHub.v2017_04_01.EventHubs;

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
