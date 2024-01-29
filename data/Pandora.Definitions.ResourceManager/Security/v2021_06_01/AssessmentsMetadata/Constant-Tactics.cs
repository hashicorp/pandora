// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Security.v2021_06_01.AssessmentsMetadata;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum TacticsConstant
{
    [Description("Collection")]
    Collection,

    [Description("Command and Control")]
    CommandAndControl,

    [Description("Credential Access")]
    CredentialAccess,

    [Description("Defense Evasion")]
    DefenseEvasion,

    [Description("Discovery")]
    Discovery,

    [Description("Execution")]
    Execution,

    [Description("Exfiltration")]
    Exfiltration,

    [Description("Impact")]
    Impact,

    [Description("Initial Access")]
    InitialAccess,

    [Description("Lateral Movement")]
    LateralMovement,

    [Description("Persistence")]
    Persistence,

    [Description("Privilege Escalation")]
    PrivilegeEscalation,

    [Description("Reconnaissance")]
    Reconnaissance,

    [Description("Resource Development")]
    ResourceDevelopment,
}
