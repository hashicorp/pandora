using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.PostgreSql.v2022_03_08_preview.Servers;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum CreateModeForUpdateConstant
{
    [Description("Default")]
    Default,

    [Description("Update")]
    Update,
}
