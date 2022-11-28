using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.HealthBot.v2022_08_08.Healthbots;


internal class HealthBotKeyModel
{
    [JsonPropertyName("keyName")]
    public string? KeyName { get; set; }

    [JsonPropertyName("value")]
    public string? Value { get; set; }
}
