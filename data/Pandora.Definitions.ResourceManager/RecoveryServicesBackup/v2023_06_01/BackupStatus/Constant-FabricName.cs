using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2023_06_01.BackupStatus;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum FabricNameConstant
{
    [Description("Azure")]
    Azure,

    [Description("Invalid")]
    Invalid,
}
