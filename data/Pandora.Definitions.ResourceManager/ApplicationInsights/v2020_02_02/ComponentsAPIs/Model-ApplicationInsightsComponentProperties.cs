using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApplicationInsights.v2020_02_02.ComponentsAPIs;


internal class ApplicationInsightsComponentPropertiesModel
{
    [JsonPropertyName("AppId")]
    public string? AppId { get; set; }

    [JsonPropertyName("ApplicationId")]
    public string? ApplicationId { get; set; }

    [JsonPropertyName("Application_Type")]
    [Required]
    public ApplicationTypeConstant ApplicationType { get; set; }

    [JsonPropertyName("ConnectionString")]
    public string? ConnectionString { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("CreationDate")]
    public DateTime? CreationDate { get; set; }

    [JsonPropertyName("DisableIpMasking")]
    public bool? DisableIPMasking { get; set; }

    [JsonPropertyName("DisableLocalAuth")]
    public bool? DisableLocalAuth { get; set; }

    [JsonPropertyName("Flow_Type")]
    public FlowTypeConstant? FlowType { get; set; }

    [JsonPropertyName("ForceCustomerStorageForProfiler")]
    public bool? ForceCustomerStorageForProfiler { get; set; }

    [JsonPropertyName("HockeyAppId")]
    public string? HockeyAppId { get; set; }

    [JsonPropertyName("HockeyAppToken")]
    public string? HockeyAppToken { get; set; }

    [JsonPropertyName("ImmediatePurgeDataOn30Days")]
    public bool? ImmediatePurgeDataOn30Days { get; set; }

    [JsonPropertyName("IngestionMode")]
    public IngestionModeConstant? IngestionMode { get; set; }

    [JsonPropertyName("InstrumentationKey")]
    public string? InstrumentationKey { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("LaMigrationDate")]
    public DateTime? LaMigrationDate { get; set; }

    [JsonPropertyName("Name")]
    public string? Name { get; set; }

    [JsonPropertyName("PrivateLinkScopedResources")]
    public List<PrivateLinkScopedResourceModel>? PrivateLinkScopedResources { get; set; }

    [JsonPropertyName("provisioningState")]
    public string? ProvisioningState { get; set; }

    [JsonPropertyName("publicNetworkAccessForIngestion")]
    public PublicNetworkAccessTypeConstant? PublicNetworkAccessForIngestion { get; set; }

    [JsonPropertyName("publicNetworkAccessForQuery")]
    public PublicNetworkAccessTypeConstant? PublicNetworkAccessForQuery { get; set; }

    [JsonPropertyName("Request_Source")]
    public RequestSourceConstant? RequestSource { get; set; }

    [JsonPropertyName("RetentionInDays")]
    public int? RetentionInDays { get; set; }

    [JsonPropertyName("SamplingPercentage")]
    public float? SamplingPercentage { get; set; }

    [JsonPropertyName("TenantId")]
    public string? TenantId { get; set; }

    [JsonPropertyName("WorkspaceResourceId")]
    public string? WorkspaceResourceId { get; set; }
}
