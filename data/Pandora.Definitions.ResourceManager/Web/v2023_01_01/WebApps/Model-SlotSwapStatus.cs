using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Web.v2023_01_01.WebApps;


internal class SlotSwapStatusModel
{
    [JsonPropertyName("destinationSlotName")]
    public string? DestinationSlotName { get; set; }

    [JsonPropertyName("sourceSlotName")]
    public string? SourceSlotName { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("timestampUtc")]
    public DateTime? TimestampUtc { get; set; }
}
