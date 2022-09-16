using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Synapse.v2021_06_01.WorkspaceManagedSqlServerBlobAuditing;


internal class ExtendedServerBlobAuditingPolicyPropertiesModel
{
    [JsonPropertyName("auditActionsAndGroups")]
    public List<string>? AuditActionsAndGroups { get; set; }

    [JsonPropertyName("isAzureMonitorTargetEnabled")]
    public bool? IsAzureMonitorTargetEnabled { get; set; }

    [JsonPropertyName("isDevopsAuditEnabled")]
    public bool? IsDevopsAuditEnabled { get; set; }

    [JsonPropertyName("isStorageSecondaryKeyInUse")]
    public bool? IsStorageSecondaryKeyInUse { get; set; }

    [JsonPropertyName("predicateExpression")]
    public string? PredicateExpression { get; set; }

    [JsonPropertyName("queueDelayMs")]
    public int? QueueDelayMs { get; set; }

    [JsonPropertyName("retentionDays")]
    public int? RetentionDays { get; set; }

    [JsonPropertyName("state")]
    [Required]
    public BlobAuditingPolicyStateConstant State { get; set; }

    [JsonPropertyName("storageAccountAccessKey")]
    public string? StorageAccountAccessKey { get; set; }

    [JsonPropertyName("storageAccountSubscriptionId")]
    public string? StorageAccountSubscriptionId { get; set; }

    [JsonPropertyName("storageEndpoint")]
    public string? StorageEndpoint { get; set; }
}
