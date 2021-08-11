using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.AppConfiguration.v2020_06_01.ConfigurationStores
{
    [ConstantType(ConstantTypeAttribute.ConstantType.String)]
    internal enum IdentityTypeConstant
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
