// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class ChangeNotificationModel
{
    [JsonPropertyName("changeType")]
    public ChangeNotificationChangeTypeConstant? ChangeType { get; set; }

    [JsonPropertyName("clientState")]
    public string? ClientState { get; set; }

    [JsonPropertyName("encryptedContent")]
    public ChangeNotificationEncryptedContentModel? EncryptedContent { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("lifecycleEvent")]
    public ChangeNotificationLifecycleEventConstant? LifecycleEvent { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("resource")]
    public string? Resource { get; set; }

    [JsonPropertyName("resourceData")]
    public ResourceDataModel? ResourceData { get; set; }

    [JsonPropertyName("subscriptionExpirationDateTime")]
    public DateTime? SubscriptionExpirationDateTime { get; set; }

    [JsonPropertyName("subscriptionId")]
    public string? SubscriptionId { get; set; }

    [JsonPropertyName("tenantId")]
    public string? TenantId { get; set; }
}
