using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.LabServices.v2023_06_07.User;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum RegistrationStateConstant
{
    [Description("NotRegistered")]
    NotRegistered,

    [Description("Registered")]
    Registered,
}
