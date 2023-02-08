using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Automation.v2015_10_31.ListKeys;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AutomationKeyNameConstant
{
    [Description("Primary")]
    Primary,

    [Description("Secondary")]
    Secondary,
}
