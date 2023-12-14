using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataProtection.v2023_11_01.DppResourceGuardProxies;


internal class ResourceGuardProxyBaseModel
{
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("lastUpdatedTime")]
    public string? LastUpdatedTime { get; set; }

    [JsonPropertyName("resourceGuardOperationDetails")]
    public List<ResourceGuardOperationDetailModel>? ResourceGuardOperationDetails { get; set; }

    [JsonPropertyName("resourceGuardResourceId")]
    public string? ResourceGuardResourceId { get; set; }
}
