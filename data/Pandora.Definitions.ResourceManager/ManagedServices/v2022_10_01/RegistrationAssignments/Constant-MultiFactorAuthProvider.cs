using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ManagedServices.v2022_10_01.RegistrationAssignments;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum MultiFactorAuthProviderConstant
{
    [Description("Azure")]
    Azure,

    [Description("None")]
    None,
}
