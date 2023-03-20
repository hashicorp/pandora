using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServices.v2023_02_01.Vaults;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum BackupStorageVersionConstant
{
    [Description("Unassigned")]
    Unassigned,

    [Description("V1")]
    VOne,

    [Description("V2")]
    VTwo,
}
