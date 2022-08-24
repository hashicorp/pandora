using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.CosmosDB.v2022_05_15.CosmosDbs;

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
