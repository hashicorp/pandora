using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MySql.v2022_01_01.Servers;

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
