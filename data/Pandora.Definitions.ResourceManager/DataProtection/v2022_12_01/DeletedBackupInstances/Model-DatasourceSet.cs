using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataProtection.v2022_12_01.DeletedBackupInstances;


internal class DatasourceSetModel
{
    [JsonPropertyName("datasourceType")]
    public string? DatasourceType { get; set; }

    [JsonPropertyName("objectType")]
    public string? ObjectType { get; set; }

    [JsonPropertyName("resourceID")]
    [Required]
    public string ResourceID { get; set; }

    [JsonPropertyName("resourceLocation")]
    public string? ResourceLocation { get; set; }

    [JsonPropertyName("resourceName")]
    public string? ResourceName { get; set; }

    [JsonPropertyName("resourceType")]
    public string? ResourceType { get; set; }

    [JsonPropertyName("resourceUri")]
    public string? ResourceUri { get; set; }
}
