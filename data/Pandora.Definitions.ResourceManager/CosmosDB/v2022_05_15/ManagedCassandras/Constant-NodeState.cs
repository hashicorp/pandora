using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.CosmosDB.v2022_05_15.ManagedCassandras;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum NodeStateConstant
{
    [Description("Joining")]
    Joining,

    [Description("Leaving")]
    Leaving,

    [Description("Moving")]
    Moving,

    [Description("Normal")]
    Normal,

    [Description("Stopped")]
    Stopped,
}
