using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ApiManagement.v2022_08_01.Diagnostic;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum IdentityProviderTypeConstant
{
    [Description("aad")]
    Aad,

    [Description("aadB2C")]
    AadBTwoC,

    [Description("facebook")]
    Facebook,

    [Description("google")]
    Google,

    [Description("microsoft")]
    Microsoft,

    [Description("twitter")]
    Twitter,
}
