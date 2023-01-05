using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataProtection.v2022_12_01.RecoveryPoint;

[ValueForType("AzureBackupDiscreteRecoveryPoint")]
internal class AzureBackupDiscreteRecoveryPointModel : AzureBackupRecoveryPointModel
{
    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("expiryTime")]
    public DateTime? ExpiryTime { get; set; }

    [JsonPropertyName("friendlyName")]
    public string? FriendlyName { get; set; }

    [JsonPropertyName("policyName")]
    public string? PolicyName { get; set; }

    [JsonPropertyName("policyVersion")]
    public string? PolicyVersion { get; set; }

    [JsonPropertyName("recoveryPointDataStoresDetails")]
    public List<RecoveryPointDataStoreDetailsModel>? RecoveryPointDataStoresDetails { get; set; }

    [JsonPropertyName("recoveryPointId")]
    public string? RecoveryPointId { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("recoveryPointTime")]
    [Required]
    public DateTime RecoveryPointTime { get; set; }

    [JsonPropertyName("recoveryPointType")]
    public string? RecoveryPointType { get; set; }

    [JsonPropertyName("retentionTagName")]
    public string? RetentionTagName { get; set; }

    [JsonPropertyName("retentionTagVersion")]
    public string? RetentionTagVersion { get; set; }
}
