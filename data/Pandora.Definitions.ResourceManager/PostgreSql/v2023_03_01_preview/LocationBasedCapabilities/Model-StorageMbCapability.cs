using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.PostgreSql.v2023_03_01_preview.LocationBasedCapabilities;


internal class StorageMbCapabilityModel
{
    [JsonPropertyName("defaultIopsTier")]
    public string? DefaultIopsTier { get; set; }

    [JsonPropertyName("reason")]
    public string? Reason { get; set; }

    [JsonPropertyName("status")]
    public CapabilityStatusConstant? Status { get; set; }

    [JsonPropertyName("storageSizeMb")]
    public int? StorageSizeMb { get; set; }

    [JsonPropertyName("supportedIops")]
    public int? SupportedIops { get; set; }

    [JsonPropertyName("supportedIopsTiers")]
    public List<StorageTierCapabilityModel>? SupportedIopsTiers { get; set; }
}
