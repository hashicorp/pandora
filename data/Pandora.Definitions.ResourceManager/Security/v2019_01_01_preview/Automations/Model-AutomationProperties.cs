using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Security.v2019_01_01_preview.Automations;


internal class AutomationPropertiesModel
{
    [JsonPropertyName("actions")]
    public List<AutomationActionModel>? Actions { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("isEnabled")]
    public bool? IsEnabled { get; set; }

    [JsonPropertyName("scopes")]
    public List<AutomationScopeModel>? Scopes { get; set; }

    [JsonPropertyName("sources")]
    public List<AutomationSourceModel>? Sources { get; set; }
}
