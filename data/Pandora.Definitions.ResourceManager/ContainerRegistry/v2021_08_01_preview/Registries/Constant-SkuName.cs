using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ContainerRegistry.v2021_08_01_preview.Registries;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SkuNameConstant
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
