using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApiManagement.v2022_08_01.QuotaByPeriodKeys;


internal class QuotaCounterContractModel
{
    [JsonPropertyName("counterKey")]
    [Required]
    public string CounterKey { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("periodEndTime")]
    [Required]
    public DateTime PeriodEndTime { get; set; }

    [JsonPropertyName("periodKey")]
    [Required]
    public string PeriodKey { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("periodStartTime")]
    [Required]
    public DateTime PeriodStartTime { get; set; }

    [JsonPropertyName("value")]
    public QuotaCounterValueContractPropertiesModel? Value { get; set; }
}
