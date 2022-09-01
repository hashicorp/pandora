using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.LabServices.v2021_10_01_preview.User;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum RegistrationStateConstant
{
    [Description("NotRegistered")]
    NotRegistered,

    [Description("Registered")]
    Registered,
}
