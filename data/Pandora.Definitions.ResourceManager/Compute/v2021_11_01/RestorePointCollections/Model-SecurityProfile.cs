using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Compute.v2021_11_01.RestorePointCollections;


internal class SecurityProfileModel
{
    [JsonPropertyName("encryptionAtHost")]
    public bool? EncryptionAtHost { get; set; }

    [JsonPropertyName("securityType")]
    public SecurityTypesConstant? SecurityType { get; set; }

    [JsonPropertyName("uefiSettings")]
    public UefiSettingsModel? UefiSettings { get; set; }
}
