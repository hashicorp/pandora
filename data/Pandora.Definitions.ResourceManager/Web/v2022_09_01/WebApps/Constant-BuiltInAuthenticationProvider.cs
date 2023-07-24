using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Web.v2022_09_01.WebApps;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum BuiltInAuthenticationProviderConstant
{
    [Description("AzureActiveDirectory")]
    AzureActiveDirectory,

    [Description("Facebook")]
    Facebook,

    [Description("Github")]
    Github,

    [Description("Google")]
    Google,

    [Description("MicrosoftAccount")]
    MicrosoftAccount,

    [Description("Twitter")]
    Twitter,
}
