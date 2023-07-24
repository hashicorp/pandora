using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Web.v2022_09_01.WebApps;


internal class ContainerInfoModel
{
    [JsonPropertyName("currentCpuStats")]
    public ContainerCPUStatisticsModel? CurrentCPUStats { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("currentTimeStamp")]
    public DateTime? CurrentTimeStamp { get; set; }

    [JsonPropertyName("eth0")]
    public ContainerNetworkInterfaceStatisticsModel? Eth0 { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("memoryStats")]
    public ContainerMemoryStatisticsModel? MemoryStats { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("previousCpuStats")]
    public ContainerCPUStatisticsModel? PreviousCPUStats { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("previousTimeStamp")]
    public DateTime? PreviousTimeStamp { get; set; }
}
