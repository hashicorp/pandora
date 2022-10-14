using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.VMware.v2021_12_01.PrivateClouds;


internal class AdminCredentialsModel
{
    [JsonPropertyName("nsxtPassword")]
    public string? NsxtPassword { get; set; }

    [JsonPropertyName("nsxtUsername")]
    public string? NsxtUsername { get; set; }

    [JsonPropertyName("vcenterPassword")]
    public string? VcenterPassword { get; set; }

    [JsonPropertyName("vcenterUsername")]
    public string? VcenterUsername { get; set; }
}
