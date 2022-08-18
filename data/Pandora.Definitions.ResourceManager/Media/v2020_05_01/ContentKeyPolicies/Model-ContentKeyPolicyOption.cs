using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Media.v2020_05_01.ContentKeyPolicies;


internal class ContentKeyPolicyOptionModel
{
    [JsonPropertyName("configuration")]
    [Required]
    public ContentKeyPolicyConfigurationModel Configuration { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("policyOptionId")]
    public string? PolicyOptionId { get; set; }

    [JsonPropertyName("restriction")]
    [Required]
    public ContentKeyPolicyRestrictionModel Restriction { get; set; }
}
