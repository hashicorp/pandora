using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2023_08_01.RecoveryPointsRecommendedForMove;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SQLDataDirectoryTypeConstant
{
    [Description("Data")]
    Data,

    [Description("Invalid")]
    Invalid,

    [Description("Log")]
    Log,
}
