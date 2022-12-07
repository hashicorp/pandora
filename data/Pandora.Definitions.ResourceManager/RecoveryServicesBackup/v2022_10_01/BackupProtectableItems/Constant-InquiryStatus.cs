using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2022_10_01.BackupProtectableItems;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum InquiryStatusConstant
{
    [Description("Failed")]
    Failed,

    [Description("Invalid")]
    Invalid,

    [Description("Success")]
    Success,
}
