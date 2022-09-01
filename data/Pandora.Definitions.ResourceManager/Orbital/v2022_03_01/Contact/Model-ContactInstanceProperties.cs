using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Orbital.v2022_03_01.Contact;


internal class ContactInstancePropertiesModel
{
    [JsonPropertyName("endAzimuthDegrees")]
    public float? EndAzimuthDegrees { get; set; }

    [JsonPropertyName("endElevationDegrees")]
    public float? EndElevationDegrees { get; set; }

    [JsonPropertyName("maximumElevationDegrees")]
    public float? MaximumElevationDegrees { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("rxEndTime")]
    public DateTime? RxEndTime { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("rxStartTime")]
    public DateTime? RxStartTime { get; set; }

    [JsonPropertyName("startAzimuthDegrees")]
    public float? StartAzimuthDegrees { get; set; }

    [JsonPropertyName("startElevationDegrees")]
    public float? StartElevationDegrees { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("txEndTime")]
    public DateTime? TxEndTime { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("txStartTime")]
    public DateTime? TxStartTime { get; set; }
}
