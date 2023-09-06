using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.NetworkCloud.v2023_07_01.Networkclouds;


internal class BareMetalMachineConfigurationDataModel
{
    [JsonPropertyName("bmcConnectionString")]
    public string? BmcConnectionString { get; set; }

    [JsonPropertyName("bmcCredentials")]
    [Required]
    public AdministrativeCredentialsModel BmcCredentials { get; set; }

    [JsonPropertyName("bmcMacAddress")]
    [Required]
    public string BmcMacAddress { get; set; }

    [JsonPropertyName("bootMacAddress")]
    [Required]
    public string BootMacAddress { get; set; }

    [JsonPropertyName("machineDetails")]
    public string? MachineDetails { get; set; }

    [JsonPropertyName("machineName")]
    public string? MachineName { get; set; }

    [JsonPropertyName("rackSlot")]
    [Required]
    public int RackSlot { get; set; }

    [JsonPropertyName("serialNumber")]
    [Required]
    public string SerialNumber { get; set; }
}
