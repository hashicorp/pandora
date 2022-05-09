using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Search.v2020_03_13.Services;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SkuNameConstant
{
    [Description("basic")]
    Basic,

    [Description("free")]
    Free,

    [Description("standard")]
    Standard,

    [Description("standard3")]
    StandardThree,

    [Description("standard2")]
    StandardTwo,

    [Description("storage_optimized_l1")]
    StorageOptimizedLOne,

    [Description("storage_optimized_l2")]
    StorageOptimizedLTwo,
}
