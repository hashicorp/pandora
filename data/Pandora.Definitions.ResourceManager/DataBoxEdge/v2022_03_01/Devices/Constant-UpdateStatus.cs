using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DataBoxEdge.v2022_03_01.Devices;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum UpdateStatusConstant
{
    [Description("DownloadCompleted")]
    DownloadCompleted,

    [Description("DownloadPending")]
    DownloadPending,

    [Description("DownloadStarted")]
    DownloadStarted,

    [Description("InstallCompleted")]
    InstallCompleted,

    [Description("InstallStarted")]
    InstallStarted,
}
