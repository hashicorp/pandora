using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Sql.v2021_02_01_preview.LongTermRetentionBackups;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum BackupStorageRedundancyConstant
{
    [Description("Geo")]
    Geo,

    [Description("Local")]
    Local,

    [Description("Zone")]
    Zone,
}
