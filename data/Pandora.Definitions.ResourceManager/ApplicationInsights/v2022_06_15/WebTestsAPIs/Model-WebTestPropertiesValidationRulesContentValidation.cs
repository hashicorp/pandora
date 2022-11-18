using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApplicationInsights.v2022_06_15.WebTestsAPIs;


internal class WebTestPropertiesValidationRulesContentValidationModel
{
    [JsonPropertyName("ContentMatch")]
    public string? ContentMatch { get; set; }

    [JsonPropertyName("IgnoreCase")]
    public bool? IgnoreCase { get; set; }

    [JsonPropertyName("PassIfTextFound")]
    public bool? PassIfTextFound { get; set; }
}
