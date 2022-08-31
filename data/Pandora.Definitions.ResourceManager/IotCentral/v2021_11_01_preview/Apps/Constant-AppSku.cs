using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.IotCentral.v2021_11_01_preview.Apps;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AppSkuConstant
{
    [Description("ST1")]
    STOne,

    [Description("ST2")]
    STTwo,

    [Description("ST0")]
    STZero,
}
