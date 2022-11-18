using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Resources.v2022_09_01.Providers;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ProviderAuthorizationConsentStateConstant
{
    [Description("Consented")]
    Consented,

    [Description("NotRequired")]
    NotRequired,

    [Description("NotSpecified")]
    NotSpecified,

    [Description("Required")]
    Required,
}
