// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum RuleModeConstant
{
    [Description("Audit")]
    @audit,

    [Description("AuditAndNotify")]
    @auditAndNotify,

    [Description("Enforce")]
    @enforce,

    [Description("PendingDeletion")]
    @pendingDeletion,

    [Description("Test")]
    @test,
}
