using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.Relay.v2017_04_01.WCFRelays;


internal class WcfRelayPropertiesModel
{
    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("createdAt")]
    public DateTime? CreatedAt { get; set; }

    [JsonPropertyName("isDynamic")]
    public bool? IsDynamic { get; set; }

    [JsonPropertyName("listenerCount")]
    public int? ListenerCount { get; set; }

    [JsonPropertyName("relayType")]
    public RelaytypeConstant? RelayType { get; set; }

    [JsonPropertyName("requiresClientAuthorization")]
    public bool? RequiresClientAuthorization { get; set; }

    [JsonPropertyName("requiresTransportSecurity")]
    public bool? RequiresTransportSecurity { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("updatedAt")]
    public DateTime? UpdatedAt { get; set; }

    [JsonPropertyName("userMetadata")]
    public string? UserMetadata { get; set; }
}
