using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.EventHub.v2022_01_01_preview.NetworkRuleSets;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum PublicNetworkAccessFlagConstant
{
    [Description("Disabled")]
    Disabled,

    [Description("Enabled")]
    Enabled,

    [Description("SecuredByPerimeter")]
    SecuredByPerimeter,
}
