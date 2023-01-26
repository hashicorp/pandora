using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.LoadBalancers;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum PublicIPAddressMigrationPhaseConstant
{
    [Description("Abort")]
    Abort,

    [Description("Commit")]
    Commit,

    [Description("Committed")]
    Committed,

    [Description("None")]
    None,

    [Description("Prepare")]
    Prepare,
}
