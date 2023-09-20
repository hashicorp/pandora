// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SecuritySecurityGroupEvidenceRolesConstant
{
    [Description("Unknown")]
    @unknown,

    [Description("Contextual")]
    @contextual,

    [Description("Scanned")]
    @scanned,

    [Description("Source")]
    @source,

    [Description("Destination")]
    @destination,

    [Description("Created")]
    @created,

    [Description("Added")]
    @added,

    [Description("Compromised")]
    @compromised,

    [Description("Edited")]
    @edited,

    [Description("Attacked")]
    @attacked,

    [Description("Attacker")]
    @attacker,

    [Description("CommandAndControl")]
    @commandAndControl,

    [Description("Loaded")]
    @loaded,

    [Description("Suspicious")]
    @suspicious,

    [Description("PolicyViolator")]
    @policyViolator,
}
