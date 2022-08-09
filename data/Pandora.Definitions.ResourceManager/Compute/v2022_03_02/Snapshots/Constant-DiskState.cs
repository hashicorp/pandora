using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Compute.v2022_03_02.Snapshots;

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
