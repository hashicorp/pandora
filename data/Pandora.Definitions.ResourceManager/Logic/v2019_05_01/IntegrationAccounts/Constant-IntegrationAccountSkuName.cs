using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Logic.v2019_05_01.IntegrationAccounts;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum IntegrationAccountSkuNameConstant
{
    [Description("Basic")]
    Basic,

    [Description("Free")]
    Free,

    [Description("NotSpecified")]
    NotSpecified,

    [Description("Standard")]
    Standard,
}
