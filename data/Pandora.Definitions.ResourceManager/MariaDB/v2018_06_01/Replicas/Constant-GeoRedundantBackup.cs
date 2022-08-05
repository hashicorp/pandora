using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MariaDB.v2018_06_01.Replicas;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum GeoRedundantBackupConstant
{
    [Description("Disabled")]
    Disabled,

    [Description("Enabled")]
    Enabled,
}
