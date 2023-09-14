using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Migrate.v2023_06_06.SqlServersController;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum EsuStatusConstant
{
    [Description("Active")]
    Active,

    [Description("InActive")]
    InActive,

    [Description("Unknown")]
    Unknown,
}
