// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SynchronizationSecretConstant
{
    [Description("None")]
    @None,

    [Description("UserName")]
    @UserName,

    [Description("Password")]
    @Password,

    [Description("SecretToken")]
    @SecretToken,

    [Description("AppKey")]
    @AppKey,

    [Description("BaseAddress")]
    @BaseAddress,

    [Description("ClientIdentifier")]
    @ClientIdentifier,

    [Description("ClientSecret")]
    @ClientSecret,

    [Description("SingleSignOnType")]
    @SingleSignOnType,

    [Description("Sandbox")]
    @Sandbox,

    [Description("Url")]
    @Url,

    [Description("Domain")]
    @Domain,

    [Description("ConsumerKey")]
    @ConsumerKey,

    [Description("ConsumerSecret")]
    @ConsumerSecret,

    [Description("TokenKey")]
    @TokenKey,

    [Description("TokenExpiration")]
    @TokenExpiration,

    [Description("Oauth2AccessToken")]
    @Oauth2AccessToken,

    [Description("Oauth2AccessTokenCreationTime")]
    @Oauth2AccessTokenCreationTime,

    [Description("Oauth2RefreshToken")]
    @Oauth2RefreshToken,

    [Description("SyncAll")]
    @SyncAll,

    [Description("InstanceName")]
    @InstanceName,

    [Description("Oauth2ClientId")]
    @Oauth2ClientId,

    [Description("Oauth2ClientSecret")]
    @Oauth2ClientSecret,

    [Description("CompanyId")]
    @CompanyId,

    [Description("UpdateKeyOnSoftDelete")]
    @UpdateKeyOnSoftDelete,

    [Description("SynchronizationSchedule")]
    @SynchronizationSchedule,

    [Description("SystemOfRecord")]
    @SystemOfRecord,

    [Description("SandboxName")]
    @SandboxName,

    [Description("EnforceDomain")]
    @EnforceDomain,

    [Description("SyncNotificationSettings")]
    @SyncNotificationSettings,

    [Description("SkipOutOfScopeDeletions")]
    @SkipOutOfScopeDeletions,

    [Description("Oauth2AuthorizationCode")]
    @Oauth2AuthorizationCode,

    [Description("Oauth2RedirectUri")]
    @Oauth2RedirectUri,

    [Description("ApplicationTemplateIdentifier")]
    @ApplicationTemplateIdentifier,

    [Description("Oauth2TokenExchangeUri")]
    @Oauth2TokenExchangeUri,

    [Description("Oauth2AuthorizationUri")]
    @Oauth2AuthorizationUri,

    [Description("AuthenticationType")]
    @AuthenticationType,

    [Description("Server")]
    @Server,

    [Description("PerformInboundEntitlementGrants")]
    @PerformInboundEntitlementGrants,

    [Description("HardDeletesEnabled")]
    @HardDeletesEnabled,

    [Description("SyncAgentCompatibilityKey")]
    @SyncAgentCompatibilityKey,

    [Description("SyncAgentADContainer")]
    @SyncAgentADContainer,

    [Description("ValidateDomain")]
    @ValidateDomain,

    [Description("TestReferences")]
    @TestReferences,

    [Description("ConnectionString")]
    @ConnectionString,
}
