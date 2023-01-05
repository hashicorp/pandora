using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MySql.v2021_12_01_preview.LocationBasedCapabilities;


internal class ServerEditionCapabilityModel
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("supportedServerVersions")]
    public List<ServerVersionCapabilityModel>? SupportedServerVersions { get; set; }

    [JsonPropertyName("supportedStorageEditions")]
    public List<StorageEditionCapabilityModel>? SupportedStorageEditions { get; set; }
}
