using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataShare.v2021_08_01.ConsumerInvitation;


internal class ConsumerInvitationPropertiesModel
{
    [JsonPropertyName("dataSetCount")]
    public int? DataSetCount { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("expirationDate")]
    public DateTime? ExpirationDate { get; set; }

    [JsonPropertyName("invitationId")]
    [Required]
    public string InvitationId { get; set; }

    [JsonPropertyName("invitationStatus")]
    public InvitationStatusConstant? InvitationStatus { get; set; }

    [JsonPropertyName("location")]
    public CustomTypes.Location? Location { get; set; }

    [JsonPropertyName("providerEmail")]
    public string? ProviderEmail { get; set; }

    [JsonPropertyName("providerName")]
    public string? ProviderName { get; set; }

    [JsonPropertyName("providerTenantName")]
    public string? ProviderTenantName { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("respondedAt")]
    public DateTime? RespondedAt { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("sentAt")]
    public DateTime? SentAt { get; set; }

    [JsonPropertyName("shareName")]
    public string? ShareName { get; set; }

    [JsonPropertyName("termsOfUse")]
    public string? TermsOfUse { get; set; }

    [JsonPropertyName("userEmail")]
    public string? UserEmail { get; set; }

    [JsonPropertyName("userName")]
    public string? UserName { get; set; }
}
