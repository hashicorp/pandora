using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.EventHub.v2022_01_01_preview.Namespaces;

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
