using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.EventHub.v2022_01_01_preview.ApplicationGroup;


internal class ApplicationGroupPropertiesModel
{
    [JsonPropertyName("clientAppGroupIdentifier")]
    [Required]
    public string ClientAppGroupIdentifier { get; set; }

    [JsonPropertyName("isEnabled")]
    public bool? IsEnabled { get; set; }

    [JsonPropertyName("policies")]
    public List<ApplicationGroupPolicyModel>? Policies { get; set; }
}
