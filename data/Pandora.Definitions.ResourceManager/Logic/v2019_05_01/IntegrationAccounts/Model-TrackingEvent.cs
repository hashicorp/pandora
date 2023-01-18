using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Logic.v2019_05_01.IntegrationAccounts;


internal class TrackingEventModel
{
    [JsonPropertyName("error")]
    public TrackingEventErrorInfoModel? Error { get; set; }

    [JsonPropertyName("eventLevel")]
    [Required]
    public EventLevelConstant EventLevel { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("eventTime")]
    [Required]
    public DateTime EventTime { get; set; }

    [JsonPropertyName("record")]
    public object? Record { get; set; }

    [JsonPropertyName("recordType")]
    [Required]
    public TrackingRecordTypeConstant RecordType { get; set; }
}
