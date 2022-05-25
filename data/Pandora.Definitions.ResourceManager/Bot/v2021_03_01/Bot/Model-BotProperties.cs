using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Bot.v2021_03_01.Bot;


internal class BotPropertiesModel
{
    [JsonPropertyName("allSettings")]
    public Dictionary<string, string>? AllSettings { get; set; }

    [JsonPropertyName("appPasswordHint")]
    public string? AppPasswordHint { get; set; }

    [JsonPropertyName("cmekEncryptionStatus")]
    public string? CmekEncryptionStatus { get; set; }

    [JsonPropertyName("cmekKeyVaultUrl")]
    public string? CmekKeyVaultUrl { get; set; }

    [JsonPropertyName("configuredChannels")]
    public List<string>? ConfiguredChannels { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("developerAppInsightKey")]
    public string? DeveloperAppInsightKey { get; set; }

    [JsonPropertyName("developerAppInsightsApiKey")]
    public string? DeveloperAppInsightsApiKey { get; set; }

    [JsonPropertyName("developerAppInsightsApplicationId")]
    public string? DeveloperAppInsightsApplicationId { get; set; }

    [JsonPropertyName("disableLocalAuth")]
    public bool? DisableLocalAuth { get; set; }

    [JsonPropertyName("displayName")]
    [Required]
    public string DisplayName { get; set; }

    [JsonPropertyName("enabledChannels")]
    public List<string>? EnabledChannels { get; set; }

    [JsonPropertyName("endpoint")]
    [Required]
    public string Endpoint { get; set; }

    [JsonPropertyName("endpointVersion")]
    public string? EndpointVersion { get; set; }

    [JsonPropertyName("iconUrl")]
    public string? IconUrl { get; set; }

    [JsonPropertyName("isCmekEnabled")]
    public bool? IsCmekEnabled { get; set; }

    [JsonPropertyName("isDeveloperAppInsightsApiKeySet")]
    public bool? IsDeveloperAppInsightsApiKeySet { get; set; }

    [JsonPropertyName("isStreamingSupported")]
    public bool? IsStreamingSupported { get; set; }

    [JsonPropertyName("luisAppIds")]
    public List<string>? LuisAppIds { get; set; }

    [JsonPropertyName("luisKey")]
    public string? LuisKey { get; set; }

    [JsonPropertyName("manifestUrl")]
    public string? ManifestUrl { get; set; }

    [JsonPropertyName("migrationToken")]
    public string? MigrationToken { get; set; }

    [JsonPropertyName("msaAppId")]
    [Required]
    public string MsaAppId { get; set; }

    [JsonPropertyName("msaAppMSIResourceId")]
    public string? MsaAppMSIResourceId { get; set; }

    [JsonPropertyName("msaAppTenantId")]
    public string? MsaAppTenantId { get; set; }

    [JsonPropertyName("msaAppType")]
    public MsaAppTypeConstant? MsaAppType { get; set; }

    [JsonPropertyName("openWithHint")]
    public string? OpenWithHint { get; set; }

    [JsonPropertyName("parameters")]
    public Dictionary<string, string>? Parameters { get; set; }

    [JsonPropertyName("provisioningState")]
    public string? ProvisioningState { get; set; }

    [JsonPropertyName("publicNetworkAccess")]
    public PublicNetworkAccessConstant? PublicNetworkAccess { get; set; }

    [JsonPropertyName("publishingCredentials")]
    public string? PublishingCredentials { get; set; }

    [JsonPropertyName("schemaTransformationVersion")]
    public string? SchemaTransformationVersion { get; set; }

    [JsonPropertyName("storageResourceId")]
    public string? StorageResourceId { get; set; }
}
