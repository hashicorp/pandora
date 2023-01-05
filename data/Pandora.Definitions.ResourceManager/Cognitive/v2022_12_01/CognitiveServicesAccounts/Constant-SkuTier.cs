using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Cognitive.v2022_12_01.CognitiveServicesAccounts;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SkuTierConstant
{
    [Description("Basic")]
    Basic,

    [Description("Enterprise")]
    Enterprise,

    [Description("Free")]
    Free,

    [Description("Premium")]
    Premium,

    [Description("Standard")]
    Standard,
}
