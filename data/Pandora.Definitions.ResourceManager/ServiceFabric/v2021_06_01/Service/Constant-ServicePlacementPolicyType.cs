using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ServiceFabric.v2021_06_01.Service;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ServicePlacementPolicyTypeConstant
{
    [Description("Invalid")]
    Invalid,

    [Description("InvalidDomain")]
    InvalidDomain,

    [Description("NonPartiallyPlaceService")]
    NonPartiallyPlaceService,

    [Description("PreferredPrimaryDomain")]
    PreferredPrimaryDomain,

    [Description("RequiredDomain")]
    RequiredDomain,

    [Description("RequiredDomainDistribution")]
    RequiredDomainDistribution,
}
