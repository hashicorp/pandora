using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DataBoxEdge.v2022_03_01.Jobs;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum UpdateOperationStageConstant
{
    [Description("DownloadComplete")]
    DownloadComplete,

    [Description("DownloadFailed")]
    DownloadFailed,

    [Description("DownloadStarted")]
    DownloadStarted,

    [Description("Failure")]
    Failure,

    [Description("Initial")]
    Initial,

    [Description("InstallComplete")]
    InstallComplete,

    [Description("InstallFailed")]
    InstallFailed,

    [Description("InstallStarted")]
    InstallStarted,

    [Description("RebootInitiated")]
    RebootInitiated,

    [Description("RescanComplete")]
    RescanComplete,

    [Description("RescanFailed")]
    RescanFailed,

    [Description("RescanStarted")]
    RescanStarted,

    [Description("ScanComplete")]
    ScanComplete,

    [Description("ScanFailed")]
    ScanFailed,

    [Description("ScanStarted")]
    ScanStarted,

    [Description("Success")]
    Success,

    [Description("Unknown")]
    Unknown,
}
