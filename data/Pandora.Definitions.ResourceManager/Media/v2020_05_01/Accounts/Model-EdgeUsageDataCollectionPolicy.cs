using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Media.v2020_05_01.Accounts;


internal class EdgeUsageDataCollectionPolicyModel
{
    [JsonPropertyName("dataCollectionFrequency")]
    public string? DataCollectionFrequency { get; set; }

    [JsonPropertyName("dataReportingFrequency")]
    public string? DataReportingFrequency { get; set; }

    [JsonPropertyName("eventHubDetails")]
    public EdgeUsageDataEventHubModel? EventHubDetails { get; set; }

    [JsonPropertyName("maxAllowedUnreportedUsageDuration")]
    public string? MaxAllowedUnreportedUsageDuration { get; set; }
}
