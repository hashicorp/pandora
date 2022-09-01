using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2021_09_01_preview.DataConnectors;


internal class RequiredPermissionsModel
{
    [JsonPropertyName("action")]
    public bool? Action { get; set; }

    [JsonPropertyName("delete")]
    public bool? Delete { get; set; }

    [JsonPropertyName("read")]
    public bool? Read { get; set; }

    [JsonPropertyName("write")]
    public bool? Write { get; set; }
}
