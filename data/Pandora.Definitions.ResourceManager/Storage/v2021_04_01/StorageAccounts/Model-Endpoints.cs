using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.Storage.v2021_04_01.StorageAccounts;


internal class EndpointsModel
{
    [JsonPropertyName("blob")]
    public string? Blob { get; set; }

    [JsonPropertyName("dfs")]
    public string? Dfs { get; set; }

    [JsonPropertyName("file")]
    public string? File { get; set; }

    [JsonPropertyName("internetEndpoints")]
    public StorageAccountInternetEndpointsModel? InternetEndpoints { get; set; }

    [JsonPropertyName("microsoftEndpoints")]
    public StorageAccountMicrosoftEndpointsModel? MicrosoftEndpoints { get; set; }

    [JsonPropertyName("queue")]
    public string? Queue { get; set; }

    [JsonPropertyName("table")]
    public string? Table { get; set; }

    [JsonPropertyName("web")]
    public string? Web { get; set; }
}
