using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2021_12_01.BackupUsageSummaries;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum UsagesUnitConstant
{
    [Description("Bytes")]
    Bytes,

    [Description("BytesPerSecond")]
    BytesPerSecond,

    [Description("Count")]
    Count,

    [Description("CountPerSecond")]
    CountPerSecond,

    [Description("Percent")]
    Percent,

    [Description("Seconds")]
    Seconds,
}
