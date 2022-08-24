using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.CosmosDB.v2022_05_15.CosmosDbs;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DefaultConsistencyLevelConstant
{
    [Description("BoundedStaleness")]
    BoundedStaleness,

    [Description("ConsistentPrefix")]
    ConsistentPrefix,

    [Description("Eventual")]
    Eventual,

    [Description("Session")]
    Session,

    [Description("Strong")]
    Strong,
}
