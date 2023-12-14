// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class WindowsKioskUWPAppModel
{
    [JsonPropertyName("appId")]
    public string? AppId { get; set; }

    [JsonPropertyName("appType")]
    public WindowsKioskUWPAppAppTypeConstant? AppType { get; set; }

    [JsonPropertyName("appUserModelId")]
    public string? AppUserModelId { get; set; }

    [JsonPropertyName("autoLaunch")]
    public bool? AutoLaunch { get; set; }

    [JsonPropertyName("containedAppId")]
    public string? ContainedAppId { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("startLayoutTileSize")]
    public WindowsKioskUWPAppStartLayoutTileSizeConstant? StartLayoutTileSize { get; set; }
}
