using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MariaDB.v2018_06_01.Servers;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum StorageAutogrowConstant
{
    [Description("Disabled")]
    Disabled,

    [Description("Enabled")]
    Enabled,
}
