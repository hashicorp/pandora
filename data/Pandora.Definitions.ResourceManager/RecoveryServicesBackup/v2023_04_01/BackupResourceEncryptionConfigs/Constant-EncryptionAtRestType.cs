using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2023_04_01.BackupResourceEncryptionConfigs;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum EncryptionAtRestTypeConstant
{
    [Description("CustomerManaged")]
    CustomerManaged,

    [Description("Invalid")]
    Invalid,

    [Description("MicrosoftManaged")]
    MicrosoftManaged,
}
