using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DesktopVirtualization.v2022_09_09.MsixImage;


internal class MsixPackageApplicationsModel
{
    [JsonPropertyName("appId")]
    public string? AppId { get; set; }

    [JsonPropertyName("appUserModelID")]
    public string? AppUserModelID { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("friendlyName")]
    public string? FriendlyName { get; set; }

    [JsonPropertyName("iconImageName")]
    public string? IconImageName { get; set; }

    [JsonPropertyName("rawIcon")]
    public string? RawIcon { get; set; }

    [JsonPropertyName("rawPng")]
    public string? RawPng { get; set; }
}
