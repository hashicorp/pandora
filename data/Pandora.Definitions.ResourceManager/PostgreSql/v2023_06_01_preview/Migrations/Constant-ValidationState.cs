using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.PostgreSql.v2023_06_01_preview.Migrations;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ValidationStateConstant
{
    [Description("Failed")]
    Failed,

    [Description("Succeeded")]
    Succeeded,

    [Description("Warning")]
    Warning,
}
