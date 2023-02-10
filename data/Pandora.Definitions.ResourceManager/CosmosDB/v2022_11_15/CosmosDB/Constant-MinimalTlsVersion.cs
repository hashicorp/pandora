using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.CosmosDB.v2022_11_15.CosmosDB;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum MinimalTlsVersionConstant
{
    [Description("Tls")]
    Tls,

    [Description("Tls11")]
    TlsOneOne,

    [Description("Tls12")]
    TlsOneTwo,
}
