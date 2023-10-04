using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ConnectedVmware.v2023_10_01.VirtualMachineInstances;


internal class OsProfileForVMInstanceModel
{
    [JsonPropertyName("adminPassword")]
    public string? AdminPassword { get; set; }

    [JsonPropertyName("adminUsername")]
    public string? AdminUsername { get; set; }

    [JsonPropertyName("computerName")]
    public string? ComputerName { get; set; }

    [JsonPropertyName("guestId")]
    public string? GuestId { get; set; }

    [JsonPropertyName("osSku")]
    public string? OsSku { get; set; }

    [JsonPropertyName("osType")]
    public OsTypeConstant? OsType { get; set; }

    [JsonPropertyName("toolsRunningStatus")]
    public string? ToolsRunningStatus { get; set; }

    [JsonPropertyName("toolsVersion")]
    public string? ToolsVersion { get; set; }

    [JsonPropertyName("toolsVersionStatus")]
    public string? ToolsVersionStatus { get; set; }
}
