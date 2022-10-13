using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.WebPubSub.v2021_10_01.WebPubSub;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum UpstreamAuthTypeConstant
{
    [Description("ManagedIdentity")]
    ManagedIdentity,

    [Description("None")]
    None,
}
