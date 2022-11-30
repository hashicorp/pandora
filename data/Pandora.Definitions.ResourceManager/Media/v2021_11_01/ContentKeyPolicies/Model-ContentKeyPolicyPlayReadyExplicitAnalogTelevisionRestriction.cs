using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Media.v2021_11_01.ContentKeyPolicies;


internal class ContentKeyPolicyPlayReadyExplicitAnalogTelevisionRestrictionModel
{
    [JsonPropertyName("bestEffort")]
    [Required]
    public bool BestEffort { get; set; }

    [JsonPropertyName("configurationData")]
    [Required]
    public int ConfigurationData { get; set; }
}
