// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class IosVppEBookModel
{
    [JsonPropertyName("appleId")]
    public string? AppleId { get; set; }

    [JsonPropertyName("assignments")]
    public List<ManagedEBookAssignmentModel>? Assignments { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("deviceStates")]
    public List<DeviceInstallStateModel>? DeviceStates { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("genres")]
    public List<string>? Genres { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("informationUrl")]
    public string? InformationUrl { get; set; }

    [JsonPropertyName("installSummary")]
    public EBookInstallSummaryModel? InstallSummary { get; set; }

    [JsonPropertyName("language")]
    public string? Language { get; set; }

    [JsonPropertyName("largeCover")]
    public MimeContentModel? LargeCover { get; set; }

    [JsonPropertyName("lastModifiedDateTime")]
    public DateTime? LastModifiedDateTime { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("privacyInformationUrl")]
    public string? PrivacyInformationUrl { get; set; }

    [JsonPropertyName("publishedDateTime")]
    public DateTime? PublishedDateTime { get; set; }

    [JsonPropertyName("publisher")]
    public string? Publisher { get; set; }

    [JsonPropertyName("seller")]
    public string? Seller { get; set; }

    [JsonPropertyName("totalLicenseCount")]
    public int? TotalLicenseCount { get; set; }

    [JsonPropertyName("usedLicenseCount")]
    public int? UsedLicenseCount { get; set; }

    [JsonPropertyName("userStateSummary")]
    public List<UserInstallStateSummaryModel>? UserStateSummary { get; set; }

    [JsonPropertyName("vppOrganizationName")]
    public string? VppOrganizationName { get; set; }

    [JsonPropertyName("vppTokenId")]
    public string? VppTokenId { get; set; }
}
