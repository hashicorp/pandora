using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ContainerRegistry.v2021_09_01.Registries;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SkuTierConstant
{
    [Description("Basic")]
    Basic,

    [Description("Classic")]
    Classic,

    [Description("Premium")]
    Premium,

    [Description("Standard")]
    Standard,
}
