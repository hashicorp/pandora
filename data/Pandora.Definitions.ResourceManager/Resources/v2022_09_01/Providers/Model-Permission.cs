using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Resources.v2022_09_01.Providers;


internal class PermissionModel
{
    [JsonPropertyName("actions")]
    public List<string>? Actions { get; set; }

    [JsonPropertyName("dataActions")]
    public List<string>? DataActions { get; set; }

    [JsonPropertyName("notActions")]
    public List<string>? NotActions { get; set; }

    [JsonPropertyName("notDataActions")]
    public List<string>? NotDataActions { get; set; }
}
