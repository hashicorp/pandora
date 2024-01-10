using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ApiManagement.v2023_03_01_preview.ApiOperationsByTag;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ProductStateConstant
{
    [Description("notPublished")]
    NotPublished,

    [Description("published")]
    Published,
}
