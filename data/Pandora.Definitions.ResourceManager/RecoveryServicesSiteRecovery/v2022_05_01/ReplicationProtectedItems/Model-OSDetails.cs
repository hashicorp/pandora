using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_05_01.ReplicationProtectedItems;


internal class OSDetailsModel
{
    [JsonPropertyName("oSMajorVersion")]
    public string? OSMajorVersion { get; set; }

    [JsonPropertyName("oSMinorVersion")]
    public string? OSMinorVersion { get; set; }

    [JsonPropertyName("oSVersion")]
    public string? OSVersion { get; set; }

    [JsonPropertyName("osEdition")]
    public string? OsEdition { get; set; }

    [JsonPropertyName("osType")]
    public string? OsType { get; set; }

    [JsonPropertyName("productType")]
    public string? ProductType { get; set; }
}
