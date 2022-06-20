using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2022_05_01.OnlineEndpoint;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ManagedServiceIdentityTypeConstant
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
