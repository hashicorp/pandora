using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Synapse.v2021_06_01.Workspaces;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ActualStateConstant
{
    [Description("Disabled")]
    Disabled,

    [Description("Disabling")]
    Disabling,

    [Description("Enabled")]
    Enabled,

    [Description("Enabling")]
    Enabling,

    [Description("Unknown")]
    Unknown,
}
