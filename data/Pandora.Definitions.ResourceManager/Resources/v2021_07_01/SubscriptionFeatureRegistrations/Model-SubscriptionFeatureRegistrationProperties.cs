using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Resources.v2021_07_01.SubscriptionFeatureRegistrations;


internal class SubscriptionFeatureRegistrationPropertiesModel
{
    [JsonPropertyName("approvalType")]
    public SubscriptionFeatureRegistrationApprovalTypeConstant? ApprovalType { get; set; }

    [JsonPropertyName("authorizationProfile")]
    public AuthorizationProfileModel? AuthorizationProfile { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("documentationLink")]
    public string? DocumentationLink { get; set; }

    [JsonPropertyName("featureName")]
    public string? FeatureName { get; set; }

    [JsonPropertyName("metadata")]
    public Dictionary<string, string>? Metadata { get; set; }

    [JsonPropertyName("providerNamespace")]
    public string? ProviderNamespace { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("registrationDate")]
    public DateTime? RegistrationDate { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("releaseDate")]
    public DateTime? ReleaseDate { get; set; }

    [JsonPropertyName("shouldFeatureDisplayInPortal")]
    public bool? ShouldFeatureDisplayInPortal { get; set; }

    [JsonPropertyName("state")]
    public SubscriptionFeatureRegistrationStateConstant? State { get; set; }

    [JsonPropertyName("subscriptionId")]
    public string? SubscriptionId { get; set; }

    [JsonPropertyName("tenantId")]
    public string? TenantId { get; set; }
}
