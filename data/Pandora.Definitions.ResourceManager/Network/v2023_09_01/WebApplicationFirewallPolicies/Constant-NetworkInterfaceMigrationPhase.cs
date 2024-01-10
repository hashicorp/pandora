using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2023_09_01.WebApplicationFirewallPolicies;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum NetworkInterfaceMigrationPhaseConstant
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
