// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2023_02_01.IncidentBookmarks;

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
