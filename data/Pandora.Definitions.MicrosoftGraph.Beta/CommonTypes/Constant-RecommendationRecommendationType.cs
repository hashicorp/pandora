// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum RecommendationRecommendationTypeConstant
{
    [Description("AdfsAppsMigration")]
    @adfsAppsMigration,

    [Description("EnableDesktopSSO")]
    @enableDesktopSSO,

    [Description("EnablePHS")]
    @enablePHS,

    [Description("EnableProvisioning")]
    @enableProvisioning,

    [Description("SwitchFromPerUserMFA")]
    @switchFromPerUserMFA,

    [Description("TenantMFA")]
    @tenantMFA,

    [Description("ThirdPartyApps")]
    @thirdPartyApps,

    [Description("TurnOffPerUserMFA")]
    @turnOffPerUserMFA,

    [Description("UseAuthenticatorApp")]
    @useAuthenticatorApp,

    [Description("UseMyApps")]
    @useMyApps,

    [Description("StaleApps")]
    @staleApps,

    [Description("StaleAppCreds")]
    @staleAppCreds,

    [Description("ApplicationCredentialExpiry")]
    @applicationCredentialExpiry,

    [Description("ServicePrincipalKeyExpiry")]
    @servicePrincipalKeyExpiry,

    [Description("AdminMFAV2")]
    @adminMFAV2,

    [Description("BlockLegacyAuthentication")]
    @blockLegacyAuthentication,

    [Description("IntegratedApps")]
    @integratedApps,

    [Description("MfaRegistrationV2")]
    @mfaRegistrationV2,

    [Description("PwagePolicyNew")]
    @pwagePolicyNew,

    [Description("PasswordHashSync")]
    @passwordHashSync,

    [Description("OneAdmin")]
    @oneAdmin,

    [Description("RoleOverlap")]
    @roleOverlap,

    [Description("SelfServicePasswordReset")]
    @selfServicePasswordReset,

    [Description("SigninRiskPolicy")]
    @signinRiskPolicy,

    [Description("UserRiskPolicy")]
    @userRiskPolicy,

    [Description("VerifyAppPublisher")]
    @verifyAppPublisher,

    [Description("PrivateLinkForAAD")]
    @privateLinkForAAD,

    [Description("AppRoleAssignmentsGroups")]
    @appRoleAssignmentsGroups,

    [Description("AppRoleAssignmentsUsers")]
    @appRoleAssignmentsUsers,

    [Description("ManagedIdentity")]
    @managedIdentity,

    [Description("OverprivilegedApps")]
    @overprivilegedApps,
}
