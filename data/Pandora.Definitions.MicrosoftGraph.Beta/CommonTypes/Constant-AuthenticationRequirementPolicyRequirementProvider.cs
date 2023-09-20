// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AuthenticationRequirementPolicyRequirementProviderConstant
{
    [Description("User")]
    @user,

    [Description("Request")]
    @request,

    [Description("ServicePrincipal")]
    @servicePrincipal,

    [Description("V1ConditionalAccess")]
    @v1ConditionalAccess,

    [Description("MultiConditionalAccess")]
    @multiConditionalAccess,

    [Description("TenantSessionRiskPolicy")]
    @tenantSessionRiskPolicy,

    [Description("AccountCompromisePolicies")]
    @accountCompromisePolicies,

    [Description("V1ConditionalAccessDependency")]
    @v1ConditionalAccessDependency,

    [Description("V1ConditionalAccessPolicyIdRequested")]
    @v1ConditionalAccessPolicyIdRequested,

    [Description("MfaRegistrationRequiredByIdentityProtectionPolicy")]
    @mfaRegistrationRequiredByIdentityProtectionPolicy,

    [Description("BaselineProtection")]
    @baselineProtection,

    [Description("MfaRegistrationRequiredByBaselineProtection")]
    @mfaRegistrationRequiredByBaselineProtection,

    [Description("MfaRegistrationRequiredByMultiConditionalAccess")]
    @mfaRegistrationRequiredByMultiConditionalAccess,

    [Description("EnforcedForCspAdmins")]
    @enforcedForCspAdmins,

    [Description("SecurityDefaults")]
    @securityDefaults,

    [Description("MfaRegistrationRequiredBySecurityDefaults")]
    @mfaRegistrationRequiredBySecurityDefaults,

    [Description("ProofUpCodeRequest")]
    @proofUpCodeRequest,

    [Description("CrossTenantOutboundRule")]
    @crossTenantOutboundRule,

    [Description("GpsLocationCondition")]
    @gpsLocationCondition,

    [Description("RiskBasedPolicy")]
    @riskBasedPolicy,
}
