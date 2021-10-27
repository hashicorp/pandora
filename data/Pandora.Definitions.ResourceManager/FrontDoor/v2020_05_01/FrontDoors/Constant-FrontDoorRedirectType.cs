using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.FrontDoor.v2020_05_01.FrontDoors
{
    [ConstantType(ConstantTypeAttribute.ConstantType.String)]
    internal enum FrontDoorRedirectTypeConstant
    {
        [Description("Found")]
        Found,

        [Description("Moved")]
        Moved,

        [Description("PermanentRedirect")]
        PermanentRedirect,

        [Description("TemporaryRedirect")]
        TemporaryRedirect,
    }
}
