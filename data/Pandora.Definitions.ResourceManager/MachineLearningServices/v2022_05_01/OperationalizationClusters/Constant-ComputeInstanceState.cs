using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2022_05_01.OperationalizationClusters;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ComputeInstanceStateConstant
{
    [Description("CreateFailed")]
    CreateFailed,

    [Description("Creating")]
    Creating,

    [Description("Deleting")]
    Deleting,

    [Description("JobRunning")]
    JobRunning,

    [Description("Restarting")]
    Restarting,

    [Description("Running")]
    Running,

    [Description("SettingUp")]
    SettingUp,

    [Description("SetupFailed")]
    SetupFailed,

    [Description("Starting")]
    Starting,

    [Description("Stopped")]
    Stopped,

    [Description("Stopping")]
    Stopping,

    [Description("Unknown")]
    Unknown,

    [Description("Unusable")]
    Unusable,

    [Description("UserSettingUp")]
    UserSettingUp,

    [Description("UserSetupFailed")]
    UserSetupFailed,
}
