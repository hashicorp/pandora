using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Storage.v2021_04_01.BlobContainers;


internal class ContainerPropertiesModel
{
    [JsonPropertyName("defaultEncryptionScope")]
    public string? DefaultEncryptionScope { get; set; }

    [JsonPropertyName("deleted")]
    public bool? Deleted { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("deletedTime")]
    public DateTime? DeletedTime { get; set; }

    [JsonPropertyName("denyEncryptionScopeOverride")]
    public bool? DenyEncryptionScopeOverride { get; set; }

    [JsonPropertyName("hasImmutabilityPolicy")]
    public bool? HasImmutabilityPolicy { get; set; }

    [JsonPropertyName("hasLegalHold")]
    public bool? HasLegalHold { get; set; }

    [JsonPropertyName("immutabilityPolicy")]
    public ImmutabilityPolicyPropertiesModel? ImmutabilityPolicy { get; set; }

    [JsonPropertyName("immutableStorageWithVersioning")]
    public ImmutableStorageWithVersioningModel? ImmutableStorageWithVersioning { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastModifiedTime")]
    public DateTime? LastModifiedTime { get; set; }

    [JsonPropertyName("leaseDuration")]
    public LeaseDurationConstant? LeaseDuration { get; set; }

    [JsonPropertyName("leaseState")]
    public LeaseStateConstant? LeaseState { get; set; }

    [JsonPropertyName("leaseStatus")]
    public LeaseStatusConstant? LeaseStatus { get; set; }

    [JsonPropertyName("legalHold")]
    public LegalHoldPropertiesModel? LegalHold { get; set; }

    [JsonPropertyName("metadata")]
    public Dictionary<string, string>? Metadata { get; set; }

    [JsonPropertyName("publicAccess")]
    public PublicAccessConstant? PublicAccess { get; set; }

    [JsonPropertyName("remainingRetentionDays")]
    public int? RemainingRetentionDays { get; set; }

    [JsonPropertyName("version")]
    public string? Version { get; set; }
}
