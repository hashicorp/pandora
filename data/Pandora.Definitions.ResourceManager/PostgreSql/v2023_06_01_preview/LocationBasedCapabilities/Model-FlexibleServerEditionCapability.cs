using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.PostgreSql.v2023_06_01_preview.LocationBasedCapabilities;


internal class FlexibleServerEditionCapabilityModel
{
    [JsonPropertyName("defaultSkuName")]
    public string? DefaultSkuName { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("reason")]
    public string? Reason { get; set; }

    [JsonPropertyName("status")]
    public CapabilityStatusConstant? Status { get; set; }

    [JsonPropertyName("supportedServerSkus")]
    public List<ServerSkuCapabilityModel>? SupportedServerSkus { get; set; }

    [JsonPropertyName("supportedStorageEditions")]
    public List<StorageEditionCapabilityModel>? SupportedStorageEditions { get; set; }
}
