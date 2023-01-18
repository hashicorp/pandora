using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Logic.v2019_05_01.IntegrationAccountMaps;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum MapTypeConstant
{
    [Description("Liquid")]
    Liquid,

    [Description("NotSpecified")]
    NotSpecified,

    [Description("Xslt")]
    Xslt,

    [Description("Xslt30")]
    XsltThreeZero,

    [Description("Xslt20")]
    XsltTwoZero,
}
