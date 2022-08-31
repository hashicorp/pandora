using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.PostgreSql.v2017_12_01.VirtualNetworkRules;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum VirtualNetworkRuleStateConstant
{
    [Description("Deleting")]
    Deleting,

    [Description("InProgress")]
    InProgress,

    [Description("Initializing")]
    Initializing,

    [Description("Ready")]
    Ready,

    [Description("Unknown")]
    Unknown,
}
