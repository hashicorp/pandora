using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2021_12_01.Restores;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum CopyOptionsConstant
{
    [Description("CreateCopy")]
    CreateCopy,

    [Description("FailOnConflict")]
    FailOnConflict,

    [Description("Invalid")]
    Invalid,

    [Description("Overwrite")]
    Overwrite,

    [Description("Skip")]
    Skip,
}
