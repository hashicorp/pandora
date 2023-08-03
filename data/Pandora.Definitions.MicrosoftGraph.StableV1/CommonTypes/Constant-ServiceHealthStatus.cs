// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ServiceHealthStatusConstant
{
    [Description("ServiceOperational")]
    @serviceOperational,

    [Description("Investigating")]
    @investigating,

    [Description("RestoringService")]
    @restoringService,

    [Description("VerifyingService")]
    @verifyingService,

    [Description("ServiceRestored")]
    @serviceRestored,

    [Description("PostIncidentReviewPublished")]
    @postIncidentReviewPublished,

    [Description("ServiceDegradation")]
    @serviceDegradation,

    [Description("ServiceInterruption")]
    @serviceInterruption,

    [Description("ExtendedRecovery")]
    @extendedRecovery,

    [Description("FalsePositive")]
    @falsePositive,

    [Description("InvestigationSuspended")]
    @investigationSuspended,

    [Description("Resolved")]
    @resolved,

    [Description("MitigatedExternal")]
    @mitigatedExternal,

    [Description("Mitigated")]
    @mitigated,

    [Description("ResolvedExternal")]
    @resolvedExternal,

    [Description("Confirmed")]
    @confirmed,

    [Description("Reported")]
    @reported,
}
