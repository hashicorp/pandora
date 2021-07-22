using System.ComponentModel;
using Pandora.Definitions.Attributes;

namespace Pandora.Definitions.ResourceManager.AppConfiguration.v2020_06_01.ConfigurationStores
{
    [ConstantType(ConstantTypeAttribute.ConstantType.String)]
    internal enum IdentityType
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
