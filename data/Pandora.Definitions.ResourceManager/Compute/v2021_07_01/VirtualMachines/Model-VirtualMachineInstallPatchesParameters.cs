using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Compute.v2021_07_01.VirtualMachines;


internal class VirtualMachineInstallPatchesParametersModel
{
    [JsonPropertyName("linuxParameters")]
    public LinuxParametersModel? LinuxParameters { get; set; }

    [JsonPropertyName("maximumDuration")]
    public string? MaximumDuration { get; set; }

    [JsonPropertyName("rebootSetting")]
    [Required]
    public VMGuestPatchRebootSettingConstant RebootSetting { get; set; }

    [JsonPropertyName("windowsParameters")]
    public WindowsParametersModel? WindowsParameters { get; set; }
}
