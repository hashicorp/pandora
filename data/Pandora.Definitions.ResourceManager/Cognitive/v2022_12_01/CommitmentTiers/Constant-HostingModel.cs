using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Cognitive.v2022_12_01.CommitmentTiers;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum HostingModelConstant
{
    [Description("ConnectedContainer")]
    ConnectedContainer,

    [Description("DisconnectedContainer")]
    DisconnectedContainer,

    [Description("Web")]
    Web,
}
