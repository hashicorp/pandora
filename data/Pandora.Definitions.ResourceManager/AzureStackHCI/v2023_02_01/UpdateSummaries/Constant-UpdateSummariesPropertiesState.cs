using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.AzureStackHCI.v2023_02_01.UpdateSummaries;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum UpdateSummariesPropertiesStateConstant
{
    [Description("AppliedSuccessfully")]
    AppliedSuccessfully,

    [Description("NeedsAttention")]
    NeedsAttention,

    [Description("PreparationFailed")]
    PreparationFailed,

    [Description("PreparationInProgress")]
    PreparationInProgress,

    [Description("Unknown")]
    Unknown,

    [Description("UpdateAvailable")]
    UpdateAvailable,

    [Description("UpdateFailed")]
    UpdateFailed,

    [Description("UpdateInProgress")]
    UpdateInProgress,
}
