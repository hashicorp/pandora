using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2022_03_01.ProtectionContainers;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum OperationTypeConstant
{
    [Description("Invalid")]
    Invalid,

    [Description("Register")]
    Register,

    [Description("Reregister")]
    Reregister,
}
