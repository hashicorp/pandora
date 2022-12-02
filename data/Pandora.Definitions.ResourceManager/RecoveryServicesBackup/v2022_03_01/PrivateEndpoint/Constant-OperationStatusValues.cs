using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2022_03_01.PrivateEndpoint;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum OperationStatusValuesConstant
{
    [Description("Canceled")]
    Canceled,

    [Description("Failed")]
    Failed,

    [Description("InProgress")]
    InProgress,

    [Description("Invalid")]
    Invalid,

    [Description("Succeeded")]
    Succeeded,
}
