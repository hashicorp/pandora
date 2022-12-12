using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MobileNetwork.v2022_11_01.PacketCoreControlPlaneVersion;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum RecommendedVersionConstant
{
    [Description("NotRecommended")]
    NotRecommended,

    [Description("Recommended")]
    Recommended,
}
