using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Sql.v2018_06_01_preview.ManagedInstances;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum IdentityTypeConstant
{
    [Description("None")]
    None,

    [Description("SystemAssigned")]
    SystemAssigned,

    [Description("SystemAssigned,UserAssigned")]
    SystemAssignedUserAssigned,

    [Description("UserAssigned")]
    UserAssigned,
}
