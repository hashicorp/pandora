using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DataShare.v2021_08_01.DataSetMapping;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum OutputTypeConstant
{
    [Description("Csv")]
    Csv,

    [Description("Parquet")]
    Parquet,
}
