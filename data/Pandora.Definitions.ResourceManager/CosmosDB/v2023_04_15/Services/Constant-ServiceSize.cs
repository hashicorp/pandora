using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.CosmosDB.v2023_04_15.Services;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ServiceSizeConstant
{
    [Description("Cosmos.D8s")]
    CosmosPointDEights,

    [Description("Cosmos.D4s")]
    CosmosPointDFours,

    [Description("Cosmos.D16s")]
    CosmosPointDOneSixs,
}
