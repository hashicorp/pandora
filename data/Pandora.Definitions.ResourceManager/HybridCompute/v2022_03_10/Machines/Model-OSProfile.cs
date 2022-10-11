using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.HybridCompute.v2022_03_10.Machines;


internal class OSProfileModel
{
    [JsonPropertyName("computerName")]
    public string? ComputerName { get; set; }

    [JsonPropertyName("linuxConfiguration")]
    public OSProfileLinuxConfigurationModel? LinuxConfiguration { get; set; }

    [JsonPropertyName("windowsConfiguration")]
    public OSProfileWindowsConfigurationModel? WindowsConfiguration { get; set; }
}
