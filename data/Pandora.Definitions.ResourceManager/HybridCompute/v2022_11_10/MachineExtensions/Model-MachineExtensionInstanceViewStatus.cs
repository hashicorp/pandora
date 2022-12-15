using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.HybridCompute.v2022_11_10.MachineExtensions;


internal class MachineExtensionInstanceViewStatusModel
{
    [JsonPropertyName("code")]
    public string? Code { get; set; }

    [JsonPropertyName("displayStatus")]
    public string? DisplayStatus { get; set; }

    [JsonPropertyName("level")]
    public StatusLevelTypesConstant? Level { get; set; }

    [JsonPropertyName("message")]
    public string? Message { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("time")]
    public DateTime? Time { get; set; }
}
