using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.PostgreSql.v2023_03_01_preview.Configurations;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ConfigurationDataTypeConstant
{
    [Description("Boolean")]
    Boolean,

    [Description("Enumeration")]
    Enumeration,

    [Description("Integer")]
    Integer,

    [Description("Numeric")]
    Numeric,
}
