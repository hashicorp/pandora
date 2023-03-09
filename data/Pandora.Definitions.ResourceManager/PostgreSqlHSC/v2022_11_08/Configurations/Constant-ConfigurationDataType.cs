using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.PostgreSqlHSC.v2022_11_08.Configurations;

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
