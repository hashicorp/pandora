using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Storage.v2022_05_01.BlobContainers;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum LeaseStateConstant
{
    [Description("Available")]
    Available,

    [Description("Breaking")]
    Breaking,

    [Description("Broken")]
    Broken,

    [Description("Expired")]
    Expired,

    [Description("Leased")]
    Leased,
}
