using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Batch.v2022_10_01.Pool;


internal class UserAccountModel
{
    [JsonPropertyName("elevationLevel")]
    public ElevationLevelConstant? ElevationLevel { get; set; }

    [JsonPropertyName("linuxUserConfiguration")]
    public LinuxUserConfigurationModel? LinuxUserConfiguration { get; set; }

    [JsonPropertyName("name")]
    [Required]
    public string Name { get; set; }

    [JsonPropertyName("password")]
    [Required]
    public string Password { get; set; }

    [JsonPropertyName("windowsUserConfiguration")]
    public WindowsUserConfigurationModel? WindowsUserConfiguration { get; set; }
}
