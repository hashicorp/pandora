using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DataBoxEdge.v2022_03_01.Devices;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ClusterWitnessTypeConstant
{
    [Description("Cloud")]
    Cloud,

    [Description("FileShare")]
    FileShare,

    [Description("None")]
    None,
}
