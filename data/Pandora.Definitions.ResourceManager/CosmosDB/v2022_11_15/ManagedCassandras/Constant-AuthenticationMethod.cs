using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.CosmosDB.v2022_11_15.ManagedCassandras;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AuthenticationMethodConstant
{
    [Description("Cassandra")]
    Cassandra,

    [Description("None")]
    None,
}
