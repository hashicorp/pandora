using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.NetworkWatchers;


internal class ConnectivityIssueModel
{
    [JsonPropertyName("context")]
    public List<Dictionary<string, string>>? Context { get; set; }

    [JsonPropertyName("origin")]
    public OriginConstant? Origin { get; set; }

    [JsonPropertyName("severity")]
    public SeverityConstant? Severity { get; set; }

    [JsonPropertyName("type")]
    public IssueTypeConstant? Type { get; set; }
}
