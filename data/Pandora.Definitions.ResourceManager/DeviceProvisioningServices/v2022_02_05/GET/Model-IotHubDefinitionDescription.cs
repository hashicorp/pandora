using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DeviceProvisioningServices.v2022_02_05.GET;


internal class IotHubDefinitionDescriptionModel
{
    [JsonPropertyName("allocationWeight")]
    public int? AllocationWeight { get; set; }

    [JsonPropertyName("applyAllocationPolicy")]
    public bool? ApplyAllocationPolicy { get; set; }

    [JsonPropertyName("connectionString")]
    [Required]
    public string ConnectionString { get; set; }

    [JsonPropertyName("location")]
    [Required]
    public CustomTypes.Location Location { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }
}
