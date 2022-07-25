using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Automation.v2021_06_22.AutomationAccount;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SkuNameEnumConstant
{
    [Description("Basic")]
    Basic,

    [Description("Free")]
    Free,
}
