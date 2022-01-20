using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.LabServices.v2021_10_01_preview.Image;


internal class ImagePropertiesModel
{
    [JsonPropertyName("author")]
    public string? Author { get; set; }

    [JsonPropertyName("availableRegions")]
    public List<string>? AvailableRegions { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("enabledState")]
    [Required]
    public EnableStateConstant EnabledState { get; set; }

    [JsonPropertyName("iconUrl")]
    public string? IconUrl { get; set; }

    [JsonPropertyName("offer")]
    public string? Offer { get; set; }

    [JsonPropertyName("osState")]
    public OsStateConstant? OsState { get; set; }

    [JsonPropertyName("osType")]
    public OsTypeConstant? OsType { get; set; }

    [JsonPropertyName("plan")]
    public string? Plan { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("publisher")]
    public string? Publisher { get; set; }

    [JsonPropertyName("sharedGalleryId")]
    public string? SharedGalleryId { get; set; }

    [JsonPropertyName("sku")]
    public string? Sku { get; set; }

    [JsonPropertyName("termsStatus")]
    public EnableStateConstant? TermsStatus { get; set; }

    [JsonPropertyName("version")]
    public string? Version { get; set; }
}
