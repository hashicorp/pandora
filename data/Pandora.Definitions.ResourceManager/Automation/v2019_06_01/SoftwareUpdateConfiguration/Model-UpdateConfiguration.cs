using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Automation.v2019_06_01.SoftwareUpdateConfiguration;


internal class UpdateConfigurationModel
{
    [JsonPropertyName("azureVirtualMachines")]
    public List<string>? AzureVirtualMachines { get; set; }

    [JsonPropertyName("duration")]
    public string? Duration { get; set; }

    [JsonPropertyName("linux")]
    public LinuxPropertiesModel? Linux { get; set; }

    [JsonPropertyName("nonAzureComputerNames")]
    public List<string>? NonAzureComputerNames { get; set; }

    [JsonPropertyName("operatingSystem")]
    [Required]
    public OperatingSystemTypeConstant OperatingSystem { get; set; }

    [JsonPropertyName("targets")]
    public TargetPropertiesModel? Targets { get; set; }

    [JsonPropertyName("windows")]
    public WindowsPropertiesModel? Windows { get; set; }
}
