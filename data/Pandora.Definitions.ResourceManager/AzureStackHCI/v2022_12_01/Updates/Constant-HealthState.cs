using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.AzureStackHCI.v2022_12_01.Updates;

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
