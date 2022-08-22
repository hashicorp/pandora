using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ApiManagement.v2021_08_01.User;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ConfirmationConstant
{
    [Description("invite")]
    Invite,

    [Description("signup")]
    Signup,
}
