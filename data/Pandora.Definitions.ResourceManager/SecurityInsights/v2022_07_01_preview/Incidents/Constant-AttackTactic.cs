using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2022_07_01_preview.Incidents;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AttackTacticConstant
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

    [Description("Impact")]
    Impact,

    [Description("ImpairProcessControl")]
    ImpairProcessControl,

    [Description("InhibitResponseFunction")]
    InhibitResponseFunction,

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

    [Description("Reconnaissance")]
    Reconnaissance,

    [Description("ResourceDevelopment")]
    ResourceDevelopment,
}
