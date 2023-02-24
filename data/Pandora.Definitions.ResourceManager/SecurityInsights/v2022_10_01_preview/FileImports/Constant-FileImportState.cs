using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2022_10_01_preview.FileImports;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum FileImportStateConstant
{
    [Description("FatalError")]
    FatalError,

    [Description("InProgress")]
    InProgress,

    [Description("Ingested")]
    Ingested,

    [Description("IngestedWithErrors")]
    IngestedWithErrors,

    [Description("Invalid")]
    Invalid,

    [Description("Unspecified")]
    Unspecified,

    [Description("WaitingForUpload")]
    WaitingForUpload,
}
