using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Cognitive.v2021_04_30.Skus;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ResourceSkuRestrictionsTypeConstant
{
    [Description("Location")]
    Location,

    [Description("Zone")]
    Zone,
}
