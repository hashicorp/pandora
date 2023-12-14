// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class WindowsAppXModel
{
    [JsonPropertyName("applicableArchitectures")]
    public WindowsAppXApplicableArchitecturesConstant? ApplicableArchitectures { get; set; }

    [JsonPropertyName("assignments")]
    public List<MobileAppAssignmentModel>? Assignments { get; set; }

    [JsonPropertyName("categories")]
    public List<MobileAppCategoryModel>? Categories { get; set; }

    [JsonPropertyName("committedContentVersion")]
    public string? CommittedContentVersion { get; set; }

    [JsonPropertyName("contentVersions")]
    public List<MobileAppContentModel>? ContentVersions { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("developer")]
    public string? Developer { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("fileName")]
    public string? FileName { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("identityName")]
    public string? IdentityName { get; set; }

    [JsonPropertyName("identityPublisherHash")]
    public string? IdentityPublisherHash { get; set; }

    [JsonPropertyName("identityResourceIdentifier")]
    public string? IdentityResourceIdentifier { get; set; }

    [JsonPropertyName("identityVersion")]
    public string? IdentityVersion { get; set; }

    [JsonPropertyName("informationUrl")]
    public string? InformationUrl { get; set; }

    [JsonPropertyName("isBundle")]
    public bool? IsBundle { get; set; }

    [JsonPropertyName("isFeatured")]
    public bool? IsFeatured { get; set; }

    [JsonPropertyName("largeIcon")]
    public MimeContentModel? LargeIcon { get; set; }

    [JsonPropertyName("lastModifiedDateTime")]
    public DateTime? LastModifiedDateTime { get; set; }

    [JsonPropertyName("minimumSupportedOperatingSystem")]
    public WindowsMinimumOperatingSystemModel? MinimumSupportedOperatingSystem { get; set; }

    [JsonPropertyName("notes")]
    public string? Notes { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("owner")]
    public string? Owner { get; set; }

    [JsonPropertyName("privacyInformationUrl")]
    public string? PrivacyInformationUrl { get; set; }

    [JsonPropertyName("publisher")]
    public string? Publisher { get; set; }

    [JsonPropertyName("publishingState")]
    public WindowsAppXPublishingStateConstant? PublishingState { get; set; }

    [JsonPropertyName("size")]
    public int? Size { get; set; }
}
