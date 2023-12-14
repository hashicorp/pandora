using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Sql.v2023_02_01_preview.ManagedInstances;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum HybridSecondaryUsageConstant
{
    [Description("Active")]
    Active,

    [Description("Passive")]
    Passive,
}
