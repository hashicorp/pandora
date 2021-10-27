using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.FrontDoor.v2020_04_01.CheckFrontDoorNameAvailability
{
    [ConstantType(ConstantTypeAttribute.ConstantType.String)]
    internal enum AvailabilityConstant
    {
        [Description("Available")]
        Available,

        [Description("Unavailable")]
        Unavailable,
    }
}
