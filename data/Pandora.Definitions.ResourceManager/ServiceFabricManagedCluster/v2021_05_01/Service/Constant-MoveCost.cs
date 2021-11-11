using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ServiceFabricManagedCluster.v2021_05_01.Service
{
    [ConstantType(ConstantTypeAttribute.ConstantType.String)]
    internal enum MoveCostConstant
    {
        [Description("High")]
        High,

        [Description("Low")]
        Low,

        [Description("Medium")]
        Medium,

        [Description("Zero")]
        Zero,
    }
}
