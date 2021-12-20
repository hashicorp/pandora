using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.StoragePool.v2021_08_01.DiskPools
{
    [ConstantType(ConstantTypeAttribute.ConstantType.String)]
    internal enum OperationalStatusConstant
    {
        [Description("Healthy")]
        Healthy,

        [Description("Invalid")]
        Invalid,

        [Description("Running")]
        Running,

        [Description("Stopped")]
        Stopped,

        [Description("Stopped (deallocated)")]
        StoppedDeallocated,

        [Description("Unhealthy")]
        Unhealthy,

        [Description("Unknown")]
        Unknown,

        [Description("Updating")]
        Updating,
    }
}
