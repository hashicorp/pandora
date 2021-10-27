using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.FrontDoor.v2020_05_01.FrontDoors
{
    [ConstantType(ConstantTypeAttribute.ConstantType.String)]
    internal enum MinimumTLSVersionConstant
    {
        [Description("1.2")]
        OnePointTwo,

        [Description("1.0")]
        OnePointZero,
    }
}
