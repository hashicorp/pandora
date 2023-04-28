using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2022_09_01.ConnectionMonitors;


internal class ConnectionMonitorHTTPConfigurationModel
{
    [JsonPropertyName("method")]
    public HTTPConfigurationMethodConstant? Method { get; set; }

    [JsonPropertyName("path")]
    public string? Path { get; set; }

    [JsonPropertyName("port")]
    public int? Port { get; set; }

    [JsonPropertyName("preferHTTPS")]
    public bool? PreferHTTPS { get; set; }

    [JsonPropertyName("requestHeaders")]
    public List<HTTPHeaderModel>? RequestHeaders { get; set; }

    [JsonPropertyName("validStatusCodeRanges")]
    public List<string>? ValidStatusCodeRanges { get; set; }
}
