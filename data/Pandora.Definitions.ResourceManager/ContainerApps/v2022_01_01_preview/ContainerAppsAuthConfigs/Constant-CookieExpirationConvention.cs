using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ContainerApps.v2022_01_01_preview.ContainerAppsAuthConfigs;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum CookieExpirationConventionConstant
{
    [Description("FixedTime")]
    FixedTime,

    [Description("IdentityProviderDerived")]
    IdentityProviderDerived,
}
