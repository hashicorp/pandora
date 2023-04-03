using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Insights.v2019_10_17_preview.PrivateLinkScopesAPIs;


internal class PrivateLinkServiceConnectionStatePropertyModel
{
    [JsonPropertyName("actionsRequired")]
    public string? ActionsRequired { get; set; }

    [JsonPropertyName("description")]
    [Required]
    public string Description { get; set; }

    [JsonPropertyName("status")]
    [Required]
    public string Status { get; set; }
}
