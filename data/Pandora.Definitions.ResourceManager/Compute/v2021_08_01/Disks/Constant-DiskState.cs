using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Compute.v2021_08_01.Disks;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DiskStateConstant
{
    [Description("ActiveSAS")]
    ActiveSAS,

    [Description("ActiveSASFrozen")]
    ActiveSASFrozen,

    [Description("ActiveUpload")]
    ActiveUpload,

    [Description("Attached")]
    Attached,

    [Description("Frozen")]
    Frozen,

    [Description("ReadyToUpload")]
    ReadyToUpload,

    [Description("Reserved")]
    Reserved,

    [Description("Unattached")]
    Unattached,
}
