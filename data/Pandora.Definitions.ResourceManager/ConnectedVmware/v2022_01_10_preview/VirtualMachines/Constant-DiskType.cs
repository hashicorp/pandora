using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ConnectedVmware.v2022_01_10_preview.VirtualMachines;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DiskTypeConstant
{
    [Description("flat")]
    Flat,

    [Description("pmem")]
    Pmem,

    [Description("rawphysical")]
    Rawphysical,

    [Description("rawvirtual")]
    Rawvirtual,

    [Description("sesparse")]
    Sesparse,

    [Description("sparse")]
    Sparse,

    [Description("unknown")]
    Unknown,
}
