using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MariaDB.v2018_06_01_preview.Servers;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ServerStateConstant
{
    [Description("Disabled")]
    Disabled,

    [Description("Dropping")]
    Dropping,

    [Description("Ready")]
    Ready,
}
