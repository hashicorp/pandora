using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.FrontDoor.v2020_05_01.CheckFrontDoorNameAvailabilityWithSubscription
{
    [ConstantType(ConstantTypeAttribute.ConstantType.String)]
    internal enum ResourceTypeConstant
    {
        [Description("Microsoft.Network/frontDoors")]
        MicrosoftPointNetworkFrontDoors,

        [Description("Microsoft.Network/frontDoors/frontendEndpoints")]
        MicrosoftPointNetworkFrontDoorsFrontendEndpoints,
    }
}
