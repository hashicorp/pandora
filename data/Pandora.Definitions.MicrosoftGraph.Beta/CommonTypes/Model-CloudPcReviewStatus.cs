// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class CloudPcReviewStatusModel
{
    [JsonPropertyName("azureStorageAccountId")]
    public string? AzureStorageAccountId { get; set; }

    [JsonPropertyName("azureStorageAccountName")]
    public string? AzureStorageAccountName { get; set; }

    [JsonPropertyName("azureStorageContainerName")]
    public string? AzureStorageContainerName { get; set; }

    [JsonPropertyName("inReview")]
    public bool? InReview { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("restorePointDateTime")]
    public DateTime? RestorePointDateTime { get; set; }

    [JsonPropertyName("reviewStartDateTime")]
    public DateTime? ReviewStartDateTime { get; set; }

    [JsonPropertyName("subscriptionId")]
    public string? SubscriptionId { get; set; }

    [JsonPropertyName("subscriptionName")]
    public string? SubscriptionName { get; set; }

    [JsonPropertyName("userAccessLevel")]
    public CloudPcUserAccessLevelConstant? UserAccessLevel { get; set; }
}
