// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class WindowsKioskMultipleAppsModel
{
    [JsonPropertyName("allowAccessToDownloadsFolder")]
    public bool? AllowAccessToDownloadsFolder { get; set; }

    [JsonPropertyName("apps")]
    public List<WindowsKioskAppBaseModel>? Apps { get; set; }

    [JsonPropertyName("disallowDesktopApps")]
    public bool? DisallowDesktopApps { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("showTaskBar")]
    public bool? ShowTaskBar { get; set; }

    [JsonPropertyName("startMenuLayoutXml")]
    public string? StartMenuLayoutXml { get; set; }
}
