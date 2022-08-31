using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.FrontDoor.v2020_05_01.FrontDoors;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum FrontDoorRedirectProtocolConstant
{
    [Description("HttpOnly")]
    HTTPOnly,

    [Description("HttpsOnly")]
    HTTPSOnly,

    [Description("MatchRequest")]
    MatchRequest,
}
