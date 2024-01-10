using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Sql.v2021_11_01.Databases;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DatabaseReadScaleConstant
{
    [Description("Disabled")]
    Disabled,

    [Description("Enabled")]
    Enabled,
}
