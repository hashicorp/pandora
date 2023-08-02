using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MySql.v2017_12_01.Replicas;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum GeoRedundantBackupConstant
{
    [Description("Disabled")]
    Disabled,

    [Description("Enabled")]
    Enabled,
}
