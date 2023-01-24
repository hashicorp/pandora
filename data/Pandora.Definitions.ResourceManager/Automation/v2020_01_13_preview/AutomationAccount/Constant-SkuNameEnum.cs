using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Automation.v2020_01_13_preview.AutomationAccount;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SkuNameEnumConstant
{
    [Description("Basic")]
    Basic,

    [Description("Free")]
    Free,
}
