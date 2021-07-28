using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Relay.v2017_04_01.WCFRelays
{
    [ConstantType(ConstantTypeAttribute.ConstantType.String)]
    internal enum AccessRights
    {
        [Description("Listen")]
        Listen,

        [Description("Manage")]
        Manage,

        [Description("Send")]
        Send,
    }
}
