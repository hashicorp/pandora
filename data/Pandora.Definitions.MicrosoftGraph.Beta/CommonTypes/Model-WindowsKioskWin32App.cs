// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class WindowsKioskWin32AppModel
{
    [JsonPropertyName("appType")]
    public WindowsKioskWin32AppAppTypeConstant? AppType { get; set; }

    [JsonPropertyName("autoLaunch")]
    public bool? AutoLaunch { get; set; }

    [JsonPropertyName("classicAppPath")]
    public string? ClassicAppPath { get; set; }

    [JsonPropertyName("edgeKiosk")]
    public string? EdgeKiosk { get; set; }

    [JsonPropertyName("edgeKioskIdleTimeoutMinutes")]
    public int? EdgeKioskIdleTimeoutMinutes { get; set; }

    [JsonPropertyName("edgeKioskType")]
    public WindowsKioskWin32AppEdgeKioskTypeConstant? EdgeKioskType { get; set; }

    [JsonPropertyName("edgeNoFirstRun")]
    public bool? EdgeNoFirstRun { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("startLayoutTileSize")]
    public WindowsKioskWin32AppStartLayoutTileSizeConstant? StartLayoutTileSize { get; set; }
}
