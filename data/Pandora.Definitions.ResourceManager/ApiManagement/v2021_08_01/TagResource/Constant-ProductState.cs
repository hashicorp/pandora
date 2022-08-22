using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ApiManagement.v2021_08_01.TagResource;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ProductStateConstant
{
    [Description("notPublished")]
    NotPublished,

    [Description("published")]
    Published,
}
