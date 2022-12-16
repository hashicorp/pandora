using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.StreamAnalytics.v2021_10_01_preview.Inputs;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AuthenticationModeConstant
{
    [Description("ConnectionString")]
    ConnectionString,

    [Description("Msi")]
    Msi,

    [Description("UserToken")]
    UserToken,
}
