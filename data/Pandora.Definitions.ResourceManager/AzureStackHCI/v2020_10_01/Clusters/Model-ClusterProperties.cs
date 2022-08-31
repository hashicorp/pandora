using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.AzureStackHCI.v2020_10_01.Clusters;


internal class ClusterPropertiesModel
{
    [JsonPropertyName("aadClientId")]
    [Required]
    public string AadClientId { get; set; }

    [JsonPropertyName("aadTenantId")]
    [Required]
    public string AadTenantId { get; set; }

    [JsonPropertyName("billingModel")]
    public string? BillingModel { get; set; }

    [JsonPropertyName("cloudId")]
    public string? CloudId { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastBillingTimestamp")]
    public DateTime? LastBillingTimestamp { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastSyncTimestamp")]
    public DateTime? LastSyncTimestamp { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("registrationTimestamp")]
    public DateTime? RegistrationTimestamp { get; set; }

    [JsonPropertyName("reportedProperties")]
    public ClusterReportedPropertiesModel? ReportedProperties { get; set; }

    [JsonPropertyName("status")]
    public StatusConstant? Status { get; set; }

    [JsonPropertyName("trialDaysRemaining")]
    public float? TrialDaysRemaining { get; set; }
}
