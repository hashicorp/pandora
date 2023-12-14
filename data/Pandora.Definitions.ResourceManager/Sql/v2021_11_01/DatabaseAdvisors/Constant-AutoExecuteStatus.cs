using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Sql.v2021_11_01.DatabaseAdvisors;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AutoExecuteStatusConstant
{
    [Description("Default")]
    Default,

    [Description("Disabled")]
    Disabled,

    [Description("Enabled")]
    Enabled,
}
