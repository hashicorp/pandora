using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Storage.v2021_04_01.StorageAccounts;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum GeoReplicationStatusConstant
{
    [Description("Bootstrap")]
    Bootstrap,

    [Description("Live")]
    Live,

    [Description("Unavailable")]
    Unavailable,
}
