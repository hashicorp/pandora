// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class SharepointSettingsModel
{
    [JsonPropertyName("allowedDomainGuidsForSyncApp")]
    public List<string>? AllowedDomainGuidsForSyncApp { get; set; }

    [JsonPropertyName("availableManagedPathsForSiteCreation")]
    public List<string>? AvailableManagedPathsForSiteCreation { get; set; }

    [JsonPropertyName("deletedUserPersonalSiteRetentionPeriodInDays")]
    public int? DeletedUserPersonalSiteRetentionPeriodInDays { get; set; }

    [JsonPropertyName("excludedFileExtensionsForSyncApp")]
    public List<string>? ExcludedFileExtensionsForSyncApp { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("idleSessionSignOut")]
    public IdleSessionSignOutModel? IdleSessionSignOut { get; set; }

    [JsonPropertyName("imageTaggingOption")]
    public ImageTaggingChoiceConstant? ImageTaggingOption { get; set; }

    [JsonPropertyName("isCommentingOnSitePagesEnabled")]
    public bool? IsCommentingOnSitePagesEnabled { get; set; }

    [JsonPropertyName("isFileActivityNotificationEnabled")]
    public bool? IsFileActivityNotificationEnabled { get; set; }

    [JsonPropertyName("isLegacyAuthProtocolsEnabled")]
    public bool? IsLegacyAuthProtocolsEnabled { get; set; }

    [JsonPropertyName("isLoopEnabled")]
    public bool? IsLoopEnabled { get; set; }

    [JsonPropertyName("isMacSyncAppEnabled")]
    public bool? IsMacSyncAppEnabled { get; set; }

    [JsonPropertyName("isRequireAcceptingUserToMatchInvitedUserEnabled")]
    public bool? IsRequireAcceptingUserToMatchInvitedUserEnabled { get; set; }

    [JsonPropertyName("isResharingByExternalUsersEnabled")]
    public bool? IsResharingByExternalUsersEnabled { get; set; }

    [JsonPropertyName("isSharePointMobileNotificationEnabled")]
    public bool? IsSharePointMobileNotificationEnabled { get; set; }

    [JsonPropertyName("isSharePointNewsfeedEnabled")]
    public bool? IsSharePointNewsfeedEnabled { get; set; }

    [JsonPropertyName("isSiteCreationEnabled")]
    public bool? IsSiteCreationEnabled { get; set; }

    [JsonPropertyName("isSiteCreationUIEnabled")]
    public bool? IsSiteCreationUIEnabled { get; set; }

    [JsonPropertyName("isSitePagesCreationEnabled")]
    public bool? IsSitePagesCreationEnabled { get; set; }

    [JsonPropertyName("isSitesStorageLimitAutomatic")]
    public bool? IsSitesStorageLimitAutomatic { get; set; }

    [JsonPropertyName("isSyncButtonHiddenOnPersonalSite")]
    public bool? IsSyncButtonHiddenOnPersonalSite { get; set; }

    [JsonPropertyName("isUnmanagedSyncAppForTenantRestricted")]
    public bool? IsUnmanagedSyncAppForTenantRestricted { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("personalSiteDefaultStorageLimitInMB")]
    public long? PersonalSiteDefaultStorageLimitInMB { get; set; }

    [JsonPropertyName("sharingAllowedDomainList")]
    public List<string>? SharingAllowedDomainList { get; set; }

    [JsonPropertyName("sharingBlockedDomainList")]
    public List<string>? SharingBlockedDomainList { get; set; }

    [JsonPropertyName("sharingCapability")]
    public SharingCapabilitiesConstant? SharingCapability { get; set; }

    [JsonPropertyName("sharingDomainRestrictionMode")]
    public SharingDomainRestrictionModeConstant? SharingDomainRestrictionMode { get; set; }

    [JsonPropertyName("siteCreationDefaultManagedPath")]
    public string? SiteCreationDefaultManagedPath { get; set; }

    [JsonPropertyName("siteCreationDefaultStorageLimitInMB")]
    public int? SiteCreationDefaultStorageLimitInMB { get; set; }

    [JsonPropertyName("tenantDefaultTimezone")]
    public string? TenantDefaultTimezone { get; set; }
}
