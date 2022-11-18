using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Automation.v2022_08_08.ListKeys;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AutomationKeyNameConstant
{
    [Description("Primary")]
    Primary,

    [Description("Secondary")]
    Secondary,
}
