using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.AzureStackHCI.v2023_02_01.UpdateSummaries;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum HealthStateConstant
{
    [Description("Error")]
    Error,

    [Description("Failure")]
    Failure,

    [Description("InProgress")]
    InProgress,

    [Description("Success")]
    Success,

    [Description("Unknown")]
    Unknown,

    [Description("Warning")]
    Warning,
}
