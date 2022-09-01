using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Storage.v2021_04_01.FileShares;


internal class FileSharePropertiesModel
{
    [JsonPropertyName("accessTier")]
    public ShareAccessTierConstant? AccessTier { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("accessTierChangeTime")]
    public DateTime? AccessTierChangeTime { get; set; }

    [JsonPropertyName("accessTierStatus")]
    public string? AccessTierStatus { get; set; }

    [JsonPropertyName("deleted")]
    public bool? Deleted { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("deletedTime")]
    public DateTime? DeletedTime { get; set; }

    [JsonPropertyName("enabledProtocols")]
    public EnabledProtocolsConstant? EnabledProtocols { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastModifiedTime")]
    public DateTime? LastModifiedTime { get; set; }

    [JsonPropertyName("leaseDuration")]
    public LeaseDurationConstant? LeaseDuration { get; set; }

    [JsonPropertyName("leaseState")]
    public LeaseStateConstant? LeaseState { get; set; }

    [JsonPropertyName("leaseStatus")]
    public LeaseStatusConstant? LeaseStatus { get; set; }

    [JsonPropertyName("metadata")]
    public Dictionary<string, string>? Metadata { get; set; }

    [JsonPropertyName("remainingRetentionDays")]
    public int? RemainingRetentionDays { get; set; }

    [JsonPropertyName("rootSquash")]
    public RootSquashTypeConstant? RootSquash { get; set; }

    [JsonPropertyName("shareQuota")]
    public int? ShareQuota { get; set; }

    [JsonPropertyName("shareUsageBytes")]
    public int? ShareUsageBytes { get; set; }

    [JsonPropertyName("signedIdentifiers")]
    public List<SignedIdentifierModel>? SignedIdentifiers { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("snapshotTime")]
    public DateTime? SnapshotTime { get; set; }

    [JsonPropertyName("version")]
    public string? Version { get; set; }
}
