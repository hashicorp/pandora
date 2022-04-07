using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.ContainerRegistry.v2021_09_01.Registries;


internal class ImportImageParametersModel
{
    [JsonPropertyName("mode")]
    public ImportModeConstant? Mode { get; set; }

    [JsonPropertyName("source")]
    [Required]
    public ImportSourceModel Source { get; set; }

    [JsonPropertyName("targetTags")]
    public List<string>? TargetTags { get; set; }

    [JsonPropertyName("untaggedTargetRepositories")]
    public List<string>? UntaggedTargetRepositories { get; set; }
}
