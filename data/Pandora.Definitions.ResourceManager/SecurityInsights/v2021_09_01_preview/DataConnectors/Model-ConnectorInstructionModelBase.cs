using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2021_09_01_preview.DataConnectors;


internal class ConnectorInstructionModelBaseModel
{
    [JsonPropertyName("parameters")]
    public object? Parameters { get; set; }

    [JsonPropertyName("type")]
    [Required]
    public SettingTypeConstant Type { get; set; }
}
