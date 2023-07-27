using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ApiManagement.v2022_08_01.ApiProduct;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ProductStateConstant
{
    [Description("notPublished")]
    NotPublished,

    [Description("published")]
    Published,
}
