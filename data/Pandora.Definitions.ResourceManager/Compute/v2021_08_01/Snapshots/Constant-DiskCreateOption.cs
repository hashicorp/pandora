using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Compute.v2021_08_01.Snapshots;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DiskCreateOptionConstant
{
    [Description("Attach")]
    Attach,

    [Description("Copy")]
    Copy,

    [Description("CopyStart")]
    CopyStart,

    [Description("Empty")]
    Empty,

    [Description("FromImage")]
    FromImage,

    [Description("Import")]
    Import,

    [Description("ImportSecure")]
    ImportSecure,

    [Description("Restore")]
    Restore,

    [Description("Upload")]
    Upload,

    [Description("UploadPreparedSecure")]
    UploadPreparedSecure,
}
