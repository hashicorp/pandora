using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ContainerService.v2023_01_02_preview.ManagedClusters;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum GPUInstanceProfileConstant
{
    [Description("MIG4g")]
    MIGFourg,

    [Description("MIG1g")]
    MIGOneg,

    [Description("MIG7g")]
    MIGSeveng,

    [Description("MIG3g")]
    MIGThreeg,

    [Description("MIG2g")]
    MIGTwog,
}
