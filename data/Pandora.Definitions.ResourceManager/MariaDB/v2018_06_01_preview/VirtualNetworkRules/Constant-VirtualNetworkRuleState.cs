using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MariaDB.v2018_06_01_preview.VirtualNetworkRules;

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
