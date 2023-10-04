using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.CosmosDB.v2023_09_15.Restorables;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum CompositePathSortOrderConstant
{
    [Description("ascending")]
    Ascending,

    [Description("descending")]
    Descending,
}
