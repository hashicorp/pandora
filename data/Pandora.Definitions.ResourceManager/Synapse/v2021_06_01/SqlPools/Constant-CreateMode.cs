using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Synapse.v2021_06_01.SqlPools;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum CreateModeConstant
{
    [Description("Default")]
    Default,

    [Description("PointInTimeRestore")]
    PointInTimeRestore,

    [Description("Recovery")]
    Recovery,

    [Description("Restore")]
    Restore,
}
