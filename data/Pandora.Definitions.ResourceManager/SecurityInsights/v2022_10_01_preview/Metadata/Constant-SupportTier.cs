using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2022_10_01_preview.Metadata;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SupportTierConstant
{
    [Description("Community")]
    Community,

    [Description("Microsoft")]
    Microsoft,

    [Description("Partner")]
    Partner,
}
