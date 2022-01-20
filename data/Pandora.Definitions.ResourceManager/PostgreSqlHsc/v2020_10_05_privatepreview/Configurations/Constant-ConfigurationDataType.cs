using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.PostgreSqlHsc.v2020_10_05_privatepreview.Configurations;

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
