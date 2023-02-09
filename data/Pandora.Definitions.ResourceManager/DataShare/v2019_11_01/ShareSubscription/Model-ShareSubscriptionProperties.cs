using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataShare.v2019_11_01.ShareSubscription;


internal class ShareSubscriptionPropertiesModel
{
    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("createdAt")]
    public DateTime? CreatedAt { get; set; }

    [JsonPropertyName("invitationId")]
    [Required]
    public string InvitationId { get; set; }

    [JsonPropertyName("providerEmail")]
    public string? ProviderEmail { get; set; }

    [JsonPropertyName("providerName")]
    public string? ProviderName { get; set; }

    [JsonPropertyName("providerTenantName")]
    public string? ProviderTenantName { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("shareDescription")]
    public string? ShareDescription { get; set; }

    [JsonPropertyName("shareKind")]
    public ShareKindConstant? ShareKind { get; set; }

    [JsonPropertyName("shareName")]
    public string? ShareName { get; set; }

    [JsonPropertyName("shareSubscriptionStatus")]
    public ShareSubscriptionStatusConstant? ShareSubscriptionStatus { get; set; }

    [JsonPropertyName("shareTerms")]
    public string? ShareTerms { get; set; }

    [JsonPropertyName("sourceShareLocation")]
    [Required]
    public string SourceShareLocation { get; set; }

    [JsonPropertyName("userEmail")]
    public string? UserEmail { get; set; }

    [JsonPropertyName("userName")]
    public string? UserName { get; set; }
}
