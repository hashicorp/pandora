using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Cognitive.v2022_10_01.CognitiveServicesAccounts;


internal class ApiPropertiesModel
{
    [JsonPropertyName("aadClientId")]
    public string? AadClientId { get; set; }

    [JsonPropertyName("aadTenantId")]
    public string? AadTenantId { get; set; }

    [JsonPropertyName("eventHubConnectionString")]
    public string? EventHubConnectionString { get; set; }

    [JsonPropertyName("qnaAzureSearchEndpointId")]
    public string? QnaAzureSearchEndpointId { get; set; }

    [JsonPropertyName("qnaAzureSearchEndpointKey")]
    public string? QnaAzureSearchEndpointKey { get; set; }

    [JsonPropertyName("qnaRuntimeEndpoint")]
    public string? QnaRuntimeEndpoint { get; set; }

    [JsonPropertyName("statisticsEnabled")]
    public bool? StatisticsEnabled { get; set; }

    [JsonPropertyName("storageAccountConnectionString")]
    public string? StorageAccountConnectionString { get; set; }

    [JsonPropertyName("superUser")]
    public string? SuperUser { get; set; }

    [JsonPropertyName("websiteName")]
    public string? WebsiteName { get; set; }
}
