using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.CosmosDB.v2021_10_15.Restorables;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum PartitionKindConstant
{
    [Description("Hash")]
    Hash,

    [Description("MultiHash")]
    MultiHash,

    [Description("Range")]
    Range,
}
