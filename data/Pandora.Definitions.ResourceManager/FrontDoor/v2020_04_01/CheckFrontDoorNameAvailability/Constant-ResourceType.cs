using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.FrontDoor.v2020_04_01.CheckFrontDoorNameAvailability;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ResourceTypeConstant
{
    [Description("Microsoft.Network/frontDoors")]
    MicrosoftPointNetworkFrontDoors,

    [Description("Microsoft.Network/frontDoors/frontendEndpoints")]
    MicrosoftPointNetworkFrontDoorsFrontendEndpoints,
}
