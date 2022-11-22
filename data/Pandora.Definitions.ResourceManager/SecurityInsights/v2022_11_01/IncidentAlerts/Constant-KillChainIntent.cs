using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2022_11_01.IncidentAlerts;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum KillChainIntentConstant
{
    [Description("Collection")]
    Collection,

    [Description("CommandAndControl")]
    CommandAndControl,

    [Description("CredentialAccess")]
    CredentialAccess,

    [Description("DefenseEvasion")]
    DefenseEvasion,

    [Description("Discovery")]
    Discovery,

    [Description("Execution")]
    Execution,

    [Description("Exfiltration")]
    Exfiltration,

    [Description("Exploitation")]
    Exploitation,

    [Description("Impact")]
    Impact,

    [Description("LateralMovement")]
    LateralMovement,

    [Description("Persistence")]
    Persistence,

    [Description("PrivilegeEscalation")]
    PrivilegeEscalation,

    [Description("Probing")]
    Probing,

    [Description("Unknown")]
    Unknown,
}
