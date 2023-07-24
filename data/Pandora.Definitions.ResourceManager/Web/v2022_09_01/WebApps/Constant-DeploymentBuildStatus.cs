using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Web.v2022_09_01.WebApps;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DeploymentBuildStatusConstant
{
    [Description("BuildAborted")]
    BuildAborted,

    [Description("BuildFailed")]
    BuildFailed,

    [Description("BuildInProgress")]
    BuildInProgress,

    [Description("BuildPending")]
    BuildPending,

    [Description("BuildRequestReceived")]
    BuildRequestReceived,

    [Description("BuildSuccessful")]
    BuildSuccessful,

    [Description("PostBuildRestartRequired")]
    PostBuildRestartRequired,

    [Description("RuntimeFailed")]
    RuntimeFailed,

    [Description("RuntimeStarting")]
    RuntimeStarting,

    [Description("RuntimeSuccessful")]
    RuntimeSuccessful,

    [Description("StartPolling")]
    StartPolling,

    [Description("StartPollingWithRestart")]
    StartPollingWithRestart,

    [Description("TimedOut")]
    TimedOut,
}
