using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Automation.v2020_01_13_preview.DscCompilationJob;


internal class DscCompilationJobCreatePropertiesModel
{
    [JsonPropertyName("configuration")]
    [Required]
    public DscConfigurationAssociationPropertyModel Configuration { get; set; }

    [JsonPropertyName("incrementNodeConfigurationBuild")]
    public bool? IncrementNodeConfigurationBuild { get; set; }

    [JsonPropertyName("parameters")]
    public Dictionary<string, string>? Parameters { get; set; }
}
