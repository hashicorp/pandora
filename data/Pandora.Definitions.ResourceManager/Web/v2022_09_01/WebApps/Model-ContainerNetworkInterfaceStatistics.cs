using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Web.v2022_09_01.WebApps;


internal class ContainerNetworkInterfaceStatisticsModel
{
    [JsonPropertyName("rxBytes")]
    public int? RxBytes { get; set; }

    [JsonPropertyName("rxDropped")]
    public int? RxDropped { get; set; }

    [JsonPropertyName("rxErrors")]
    public int? RxErrors { get; set; }

    [JsonPropertyName("rxPackets")]
    public int? RxPackets { get; set; }

    [JsonPropertyName("txBytes")]
    public int? TxBytes { get; set; }

    [JsonPropertyName("txDropped")]
    public int? TxDropped { get; set; }

    [JsonPropertyName("txErrors")]
    public int? TxErrors { get; set; }

    [JsonPropertyName("txPackets")]
    public int? TxPackets { get; set; }
}
