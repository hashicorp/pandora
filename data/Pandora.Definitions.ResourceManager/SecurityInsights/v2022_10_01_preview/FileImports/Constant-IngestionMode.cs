using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2022_10_01_preview.FileImports;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum IngestionModeConstant
{
    [Description("IngestAnyValidRecords")]
    IngestAnyValidRecords,

    [Description("IngestOnlyIfAllAreValid")]
    IngestOnlyIfAllAreValid,

    [Description("Unspecified")]
    Unspecified,
}
