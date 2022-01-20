using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.DataBricks.v2021_04_01_preview.Workspaces;


internal class CreatedByModel
{
    [JsonPropertyName("applicationId")]
    public string? ApplicationId { get; set; }

    [JsonPropertyName("oid")]
    public string? Oid { get; set; }

    [JsonPropertyName("puid")]
    public string? Puid { get; set; }
}
