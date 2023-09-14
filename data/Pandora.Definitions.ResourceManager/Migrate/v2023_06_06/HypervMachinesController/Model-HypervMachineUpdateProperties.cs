using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Migrate.v2023_06_06.HypervMachinesController;


internal class HypervMachineUpdatePropertiesModel
{
    [JsonPropertyName("allocatedMemoryInMb")]
    public float? AllocatedMemoryInMb { get; set; }

    [JsonPropertyName("biosGuid")]
    public string? BiosGuid { get; set; }

    [JsonPropertyName("biosSerialNumber")]
    public string? BiosSerialNumber { get; set; }

    [JsonPropertyName("firmware")]
    public string? Firmware { get; set; }

    [JsonPropertyName("numberOfProcessorCore")]
    public int? NumberOfProcessorCore { get; set; }

    [JsonPropertyName("operatingSystemDetails")]
    public OperatingSystemModel? OperatingSystemDetails { get; set; }

    [JsonPropertyName("productSupportStatus")]
    public ProductSupportStatusModel? ProductSupportStatus { get; set; }

    [JsonPropertyName("runAsAccountId")]
    public string? RunAsAccountId { get; set; }

    [JsonPropertyName("tags")]
    public CustomTypes.Tags? Tags { get; set; }
}
