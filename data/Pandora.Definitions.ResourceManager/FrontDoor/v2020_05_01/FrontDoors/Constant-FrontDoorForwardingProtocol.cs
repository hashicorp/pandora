using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.FrontDoor.v2020_05_01.FrontDoors
{
    [ConstantType(ConstantTypeAttribute.ConstantType.String)]
    internal enum FrontDoorForwardingProtocolConstant
    {
        [Description("HttpOnly")]
        HttpOnly,

        [Description("HttpsOnly")]
        HttpsOnly,

        [Description("MatchRequest")]
        MatchRequest,
    }
}
