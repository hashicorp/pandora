using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.CostManagement.v2021_10_01.GenerateDetailedCostReportOperationStatus;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum OperationStatusTypeConstant
{
    [Description("Completed")]
    Completed,

    [Description("Failed")]
    Failed,

    [Description("InProgress")]
    InProgress,

    [Description("NoDataFound")]
    NoDataFound,

    [Description("Queued")]
    Queued,

    [Description("ReadyToDownload")]
    ReadyToDownload,

    [Description("TimedOut")]
    TimedOut,
}
