using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2023_09_01.NetworkWatchers;


internal class TroubleshootingParametersModel
{
    [JsonPropertyName("properties")]
    [Required]
    public TroubleshootingPropertiesModel Properties { get; set; }

    [JsonPropertyName("targetResourceId")]
    [Required]
    public string TargetResourceId { get; set; }
}
