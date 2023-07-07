using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.PostgreSql.v2023_03_01_preview.Replicas;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SkuTierConstant
{
    [Description("Burstable")]
    Burstable,

    [Description("GeneralPurpose")]
    GeneralPurpose,

    [Description("MemoryOptimized")]
    MemoryOptimized,
}
