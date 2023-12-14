using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Sql.v2023_02_01_preview.VirtualNetworkRules;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum VirtualNetworkRuleStateConstant
{
    [Description("Deleting")]
    Deleting,

    [Description("Failed")]
    Failed,

    [Description("InProgress")]
    InProgress,

    [Description("Initializing")]
    Initializing,

    [Description("Ready")]
    Ready,

    [Description("Unknown")]
    Unknown,
}
