using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Automation.v2015_10_31.ListKeys;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AutomationKeyPermissionsConstant
{
    [Description("Full")]
    Full,

    [Description("Read")]
    Read,
}
