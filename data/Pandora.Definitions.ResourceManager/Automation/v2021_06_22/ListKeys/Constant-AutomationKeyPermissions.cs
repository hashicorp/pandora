using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Automation.v2021_06_22.ListKeys;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AutomationKeyPermissionsConstant
{
    [Description("Full")]
    Full,

    [Description("Read")]
    Read,
}
