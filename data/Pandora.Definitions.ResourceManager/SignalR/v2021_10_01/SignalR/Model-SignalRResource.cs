using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.SignalR.v2021_10_01.SignalR;


internal class SignalRResourceModel
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("identity")]
    public CustomTypes.SystemOrUserAssignedIdentityMap? Identity { get; set; }

    [JsonPropertyName("kind")]
    public ServiceKindConstant? Kind { get; set; }

    [JsonPropertyName("location")]
    public CustomTypes.Location? Location { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("properties")]
    public SignalRPropertiesModel? Properties { get; set; }

    [JsonPropertyName("sku")]
    public ResourceSkuModel? Sku { get; set; }

    [JsonPropertyName("systemData")]
    public SystemDataModel? SystemData { get; set; }

    [JsonPropertyName("tags")]
    public CustomTypes.Tags? Tags { get; set; }

    [JsonPropertyName("type")]
    public string? Type { get; set; }
}
