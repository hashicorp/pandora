using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DesktopVirtualization.v2022_02_10_preview.StartMenuItem;


internal class StartMenuItemPropertiesModel
{
    [JsonPropertyName("appAlias")]
    public string? AppAlias { get; set; }

    [JsonPropertyName("commandLineArguments")]
    public string? CommandLineArguments { get; set; }

    [JsonPropertyName("filePath")]
    public string? FilePath { get; set; }

    [JsonPropertyName("iconIndex")]
    public int? IconIndex { get; set; }

    [JsonPropertyName("iconPath")]
    public string? IconPath { get; set; }
}
