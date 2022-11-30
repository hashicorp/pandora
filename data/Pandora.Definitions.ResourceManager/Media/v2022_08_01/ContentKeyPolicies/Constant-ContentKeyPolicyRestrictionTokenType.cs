using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Media.v2022_08_01.ContentKeyPolicies;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ContentKeyPolicyRestrictionTokenTypeConstant
{
    [Description("Jwt")]
    Jwt,

    [Description("Swt")]
    Swt,

    [Description("Unknown")]
    Unknown,
}
