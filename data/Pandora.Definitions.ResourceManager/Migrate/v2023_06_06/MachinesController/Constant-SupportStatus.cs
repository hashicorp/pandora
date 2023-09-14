using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Migrate.v2023_06_06.MachinesController;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SupportStatusConstant
{
    [Description("Extended")]
    Extended,

    [Description("Mainstream")]
    Mainstream,

    [Description("Unknown")]
    Unknown,
}
