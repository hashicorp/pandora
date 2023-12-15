using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Authorization.v2018_01_01_preview.ProviderOperationsMetadata;


internal class ProviderOperationsMetadataModel
{
    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("operations")]
    public List<ProviderOperationModel>? Operations { get; set; }

    [JsonPropertyName("resourceTypes")]
    public List<ResourceTypeModel>? ResourceTypes { get; set; }

    [JsonPropertyName("type")]
    public string? Type { get; set; }
}
