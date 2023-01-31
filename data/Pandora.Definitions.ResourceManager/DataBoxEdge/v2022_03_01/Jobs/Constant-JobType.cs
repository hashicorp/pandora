using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DataBoxEdge.v2022_03_01.Jobs;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum JobTypeConstant
{
    [Description("Backup")]
    Backup,

    [Description("DownloadUpdates")]
    DownloadUpdates,

    [Description("InstallUpdates")]
    InstallUpdates,

    [Description("Invalid")]
    Invalid,

    [Description("RefreshContainer")]
    RefreshContainer,

    [Description("RefreshShare")]
    RefreshShare,

    [Description("Restore")]
    Restore,

    [Description("ScanForUpdates")]
    ScanForUpdates,

    [Description("TriggerSupportPackage")]
    TriggerSupportPackage,
}
