using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.CosmosDB.v2022_05_15.CosmosDbs;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AnalyticalStorageSchemaTypeConstant
{
    [Description("FullFidelity")]
    FullFidelity,

    [Description("WellDefined")]
    WellDefined,
}
