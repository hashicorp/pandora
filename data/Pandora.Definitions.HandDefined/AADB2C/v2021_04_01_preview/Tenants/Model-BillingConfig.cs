using System.Text.Json.Serialization;

namespace Pandora.Definitions.HandDefined.AADB2C.v2021_04_01_preview.Tenants;

internal class BillingConfigModel
{
    [JsonPropertyName("billingType")]
    public BillingType BillingType { get; set; }

    [JsonPropertyName("effectiveStartDateUtc")]
    public string EffectiveStartDateUtc { get; set; }
}