using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Automation.v2015_10_31.AutomationAccount;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SkuNameEnumConstant
{
    [Description("Basic")]
    Basic,

    [Description("Free")]
    Free,
}
