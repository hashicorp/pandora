using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.OperationalInsights.v2022_10_01.Tables;


internal class ResultStatisticsModel
{
    [JsonPropertyName("ingestedRecords")]
    public int? IngestedRecords { get; set; }

    [JsonPropertyName("progress")]
    public float? Progress { get; set; }

    [JsonPropertyName("scannedGb")]
    public float? ScannedGb { get; set; }
}
