using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.EventHub.v2021_11_01.Namespaces;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SkuTierConstant
{
    [Description("Basic")]
    Basic,

    [Description("Premium")]
    Premium,

    [Description("Standard")]
    Standard,
}
