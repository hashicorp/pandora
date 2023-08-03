// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class SubscriptionModel
{
    [JsonPropertyName("applicationId")]
    public string? ApplicationId { get; set; }

    [JsonPropertyName("changeType")]
    public string? ChangeType { get; set; }

    [JsonPropertyName("clientState")]
    public string? ClientState { get; set; }

    [JsonPropertyName("creatorId")]
    public string? CreatorId { get; set; }

    [JsonPropertyName("encryptionCertificate")]
    public string? EncryptionCertificate { get; set; }

    [JsonPropertyName("encryptionCertificateId")]
    public string? EncryptionCertificateId { get; set; }

    [JsonPropertyName("expirationDateTime")]
    public DateTime? ExpirationDateTime { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("includeResourceData")]
    public bool? IncludeResourceData { get; set; }

    [JsonPropertyName("latestSupportedTlsVersion")]
    public string? LatestSupportedTlsVersion { get; set; }

    [JsonPropertyName("lifecycleNotificationUrl")]
    public string? LifecycleNotificationUrl { get; set; }

    [JsonPropertyName("notificationContentType")]
    public string? NotificationContentType { get; set; }

    [JsonPropertyName("notificationQueryOptions")]
    public string? NotificationQueryOptions { get; set; }

    [JsonPropertyName("notificationUrl")]
    public string? NotificationUrl { get; set; }

    [JsonPropertyName("notificationUrlAppId")]
    public string? NotificationUrlAppId { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("resource")]
    public string? Resource { get; set; }
}
