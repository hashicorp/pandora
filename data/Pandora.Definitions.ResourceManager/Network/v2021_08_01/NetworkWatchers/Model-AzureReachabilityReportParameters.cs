using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2021_08_01.NetworkWatchers;


internal class AzureReachabilityReportParametersModel
{
    [JsonPropertyName("azureLocations")]
    public List<string>? AzureLocations { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("endTime")]
    [Required]
    public DateTime EndTime { get; set; }

    [JsonPropertyName("providerLocation")]
    [Required]
    public AzureReachabilityReportLocationModel ProviderLocation { get; set; }

    [JsonPropertyName("providers")]
    public List<string>? Providers { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("startTime")]
    [Required]
    public DateTime StartTime { get; set; }
}
