using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2021_07_01.Workspaces;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ResourceIdentityTypeConstant
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
