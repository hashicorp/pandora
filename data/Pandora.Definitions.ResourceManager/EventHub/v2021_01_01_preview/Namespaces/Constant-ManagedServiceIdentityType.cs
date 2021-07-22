using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.EventHub.v2021_01_01_preview.Namespaces
{
    [ConstantType(ConstantTypeAttribute.ConstantType.String)]
    internal enum ManagedServiceIdentityType
    {
        [Description("None")]
        None,

        [Description("SystemAssigned")]
        SystemAssigned,

        [Description("SystemAssigned, UserAssigned")]
        SystemAssignedUserAssigned,

        [Description("UserAssigned")]
        UserAssigned,
    }
}
