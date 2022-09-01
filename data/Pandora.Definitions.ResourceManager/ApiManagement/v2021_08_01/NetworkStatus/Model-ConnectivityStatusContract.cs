using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApiManagement.v2021_08_01.NetworkStatus;


internal class ConnectivityStatusContractModel
{
    [JsonPropertyName("error")]
    public string? Error { get; set; }

    [JsonPropertyName("isOptional")]
    [Required]
    public bool IsOptional { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastStatusChange")]
    [Required]
    public DateTime LastStatusChange { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastUpdated")]
    [Required]
    public DateTime LastUpdated { get; set; }

    [JsonPropertyName("name")]
    [Required]
    public string Name { get; set; }

    [JsonPropertyName("resourceType")]
    [Required]
    public string ResourceType { get; set; }

    [JsonPropertyName("status")]
    [Required]
    public ConnectivityStatusTypeConstant Status { get; set; }
}
