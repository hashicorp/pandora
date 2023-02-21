using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DigitalTwins.v2023_01_31.Endpoints;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AuthenticationTypeConstant
{
    [Description("IdentityBased")]
    IdentityBased,

    [Description("KeyBased")]
    KeyBased,
}
