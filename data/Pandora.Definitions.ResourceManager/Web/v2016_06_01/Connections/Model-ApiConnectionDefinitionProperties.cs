using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.Web.v2016_06_01.Connections;


internal class ApiConnectionDefinitionPropertiesModel
{
    [JsonPropertyName("api")]
    public ApiReferenceModel? Api { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("changedTime")]
    public DateTime? ChangedTime { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("createdTime")]
    public DateTime? CreatedTime { get; set; }

    [JsonPropertyName("customParameterValues")]
    public Dictionary<string, string>? CustomParameterValues { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("nonSecretParameterValues")]
    public Dictionary<string, string>? NonSecretParameterValues { get; set; }

    [JsonPropertyName("parameterValues")]
    public Dictionary<string, string>? ParameterValues { get; set; }

    [JsonPropertyName("statuses")]
    public List<ConnectionStatusDefinitionModel>? Statuses { get; set; }

    [JsonPropertyName("testLinks")]
    public List<ApiConnectionTestLinkModel>? TestLinks { get; set; }
}
