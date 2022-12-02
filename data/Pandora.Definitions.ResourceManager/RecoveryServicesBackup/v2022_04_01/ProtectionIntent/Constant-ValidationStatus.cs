using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2022_04_01.ProtectionIntent;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ValidationStatusConstant
{
    [Description("Failed")]
    Failed,

    [Description("Invalid")]
    Invalid,

    [Description("Succeeded")]
    Succeeded,
}
