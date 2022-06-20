using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2022_05_01.OperationalizationClusters;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum OperationStatusConstant
{
    [Description("CreateFailed")]
    CreateFailed,

    [Description("DeleteFailed")]
    DeleteFailed,

    [Description("InProgress")]
    InProgress,

    [Description("ReimageFailed")]
    ReimageFailed,

    [Description("RestartFailed")]
    RestartFailed,

    [Description("StartFailed")]
    StartFailed,

    [Description("StopFailed")]
    StopFailed,

    [Description("Succeeded")]
    Succeeded,
}
