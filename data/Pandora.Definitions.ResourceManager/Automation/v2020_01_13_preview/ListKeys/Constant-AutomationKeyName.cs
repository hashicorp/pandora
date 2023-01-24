using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Automation.v2020_01_13_preview.ListKeys;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AutomationKeyNameConstant
{
    [Description("Primary")]
    Primary,

    [Description("Secondary")]
    Secondary,
}
