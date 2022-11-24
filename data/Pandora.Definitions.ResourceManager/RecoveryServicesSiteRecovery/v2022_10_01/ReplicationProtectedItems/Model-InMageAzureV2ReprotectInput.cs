using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_10_01.ReplicationProtectedItems;

[ValueForType("InMageAzureV2")]
internal class InMageAzureV2ReprotectInputModel : ReverseReplicationProviderSpecificInputModel
{
    [JsonPropertyName("disksToInclude")]
    public List<string>? DisksToInclude { get; set; }

    [JsonPropertyName("logStorageAccountId")]
    public string? LogStorageAccountId { get; set; }

    [JsonPropertyName("masterTargetId")]
    public string? MasterTargetId { get; set; }

    [JsonPropertyName("policyId")]
    public string? PolicyId { get; set; }

    [JsonPropertyName("processServerId")]
    public string? ProcessServerId { get; set; }

    [JsonPropertyName("runAsAccountId")]
    public string? RunAsAccountId { get; set; }

    [JsonPropertyName("storageAccountId")]
    public string? StorageAccountId { get; set; }
}
