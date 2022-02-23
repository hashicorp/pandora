using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.Storage.v2021_04_01.BlobInventoryPolicies;


internal class BlobInventoryPolicyDefinitionModel
{
    [JsonPropertyName("filters")]
    public BlobInventoryPolicyFilterModel? Filters { get; set; }

    [JsonPropertyName("format")]
    [Required]
    public FormatConstant Format { get; set; }

    [JsonPropertyName("objectType")]
    [Required]
    public ObjectTypeConstant ObjectType { get; set; }

    [JsonPropertyName("schedule")]
    [Required]
    public ScheduleConstant Schedule { get; set; }

    [JsonPropertyName("schemaFields")]
    [Required]
    public List<string> SchemaFields { get; set; }
}
