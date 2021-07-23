using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.TrafficManager.v2018_08_01.Profiles
{
    [ConstantType(ConstantTypeAttribute.ConstantType.String)]
    internal enum TrafficRoutingMethod
    {
        [Description("Geographic")]
        Geographic,

        [Description("MultiValue")]
        MultiValue,

        [Description("Performance")]
        Performance,

        [Description("Priority")]
        Priority,

        [Description("Subnet")]
        Subnet,

        [Description("Weighted")]
        Weighted,
    }
}
