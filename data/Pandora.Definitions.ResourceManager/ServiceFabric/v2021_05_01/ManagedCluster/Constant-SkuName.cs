using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ServiceFabric.v2021_05_01.ManagedCluster
{
    [ConstantType(ConstantTypeAttribute.ConstantType.String)]
    internal enum SkuNameConstant
    {
        [Description("Basic")]
        Basic,

        [Description("Standard")]
        Standard,
    }
}
