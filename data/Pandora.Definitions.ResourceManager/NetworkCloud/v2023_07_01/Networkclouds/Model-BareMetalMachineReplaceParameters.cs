using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.NetworkCloud.v2023_07_01.Networkclouds;


internal class BareMetalMachineReplaceParametersModel
{
    [JsonPropertyName("bmcCredentials")]
    public AdministrativeCredentialsModel? BmcCredentials { get; set; }

    [JsonPropertyName("bmcMacAddress")]
    public string? BmcMacAddress { get; set; }

    [JsonPropertyName("bootMacAddress")]
    public string? BootMacAddress { get; set; }

    [JsonPropertyName("machineName")]
    public string? MachineName { get; set; }

    [JsonPropertyName("serialNumber")]
    public string? SerialNumber { get; set; }
}
