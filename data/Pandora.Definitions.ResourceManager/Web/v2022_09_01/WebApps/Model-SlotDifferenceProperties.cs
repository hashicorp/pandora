using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Web.v2022_09_01.WebApps;


internal class SlotDifferencePropertiesModel
{
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("diffRule")]
    public string? DiffRule { get; set; }

    [JsonPropertyName("level")]
    public string? Level { get; set; }

    [JsonPropertyName("settingName")]
    public string? SettingName { get; set; }

    [JsonPropertyName("settingType")]
    public string? SettingType { get; set; }

    [JsonPropertyName("valueInCurrentSlot")]
    public string? ValueInCurrentSlot { get; set; }

    [JsonPropertyName("valueInTargetSlot")]
    public string? ValueInTargetSlot { get; set; }
}
