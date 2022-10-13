using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Storage.v2022_05_01.BlobInventoryPolicies;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum FormatConstant
{
    [Description("Csv")]
    Csv,

    [Description("Parquet")]
    Parquet,
}
