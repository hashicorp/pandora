// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class CustomExtensionCalloutResultModel
{
    [JsonPropertyName("calloutDateTime")]
    public DateTime? CalloutDateTime { get; set; }

    [JsonPropertyName("customExtensionId")]
    public string? CustomExtensionId { get; set; }

    [JsonPropertyName("errorCode")]
    public int? ErrorCode { get; set; }

    [JsonPropertyName("httpStatus")]
    public int? HttpStatus { get; set; }

    [JsonPropertyName("numberOfAttempts")]
    public int? NumberOfAttempts { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }
}
