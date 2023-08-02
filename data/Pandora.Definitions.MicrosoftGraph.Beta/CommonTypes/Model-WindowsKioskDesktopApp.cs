// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class WindowsKioskDesktopAppModel
{
    [JsonPropertyName("appType")]
    public WindowsKioskAppTypeConstant? AppType { get; set; }

    [JsonPropertyName("autoLaunch")]
    public bool? AutoLaunch { get; set; }

    [JsonPropertyName("desktopApplicationId")]
    public string? DesktopApplicationId { get; set; }

    [JsonPropertyName("desktopApplicationLinkPath")]
    public string? DesktopApplicationLinkPath { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("path")]
    public string? Path { get; set; }

    [JsonPropertyName("startLayoutTileSize")]
    public WindowsAppStartLayoutTileSizeConstant? StartLayoutTileSize { get; set; }
}
