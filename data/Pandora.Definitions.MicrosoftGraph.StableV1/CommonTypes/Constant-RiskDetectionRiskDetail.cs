// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum RiskDetectionRiskDetailConstant
{
    [Description("None")]
    @none,

    [Description("AdminGeneratedTemporaryPassword")]
    @adminGeneratedTemporaryPassword,

    [Description("UserPerformedSecuredPasswordChange")]
    @userPerformedSecuredPasswordChange,

    [Description("UserPerformedSecuredPasswordReset")]
    @userPerformedSecuredPasswordReset,

    [Description("AdminConfirmedSigninSafe")]
    @adminConfirmedSigninSafe,

    [Description("AiConfirmedSigninSafe")]
    @aiConfirmedSigninSafe,

    [Description("UserPassedMFADrivenByRiskBasedPolicy")]
    @userPassedMFADrivenByRiskBasedPolicy,

    [Description("AdminDismissedAllRiskForUser")]
    @adminDismissedAllRiskForUser,

    [Description("AdminConfirmedSigninCompromised")]
    @adminConfirmedSigninCompromised,

    [Description("Hidden")]
    @hidden,

    [Description("AdminConfirmedUserCompromised")]
    @adminConfirmedUserCompromised,

    [Description("AdminConfirmedServicePrincipalCompromised")]
    @adminConfirmedServicePrincipalCompromised,

    [Description("AdminDismissedAllRiskForServicePrincipal")]
    @adminDismissedAllRiskForServicePrincipal,

    [Description("M365DAdminDismissedDetection")]
    @m365DAdminDismissedDetection,
}
