using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Security.v2019_08_01.IoTSecurityAlertTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AlertIntentConstant
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

    [Description("InitialAccess")]
    InitialAccess,

    [Description("LateralMovement")]
    LateralMovement,

    [Description("Persistence")]
    Persistence,

    [Description("PreAttack")]
    PreAttack,

    [Description("PrivilegeEscalation")]
    PrivilegeEscalation,

    [Description("Probing")]
    Probing,

    [Description("Unknown")]
    Unknown,
}
