// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class WorkbookRangeFormatModel
{
    [JsonPropertyName("borders")]
    public List<WorkbookRangeBorderModel>? Borders { get; set; }

    [JsonPropertyName("fill")]
    public WorkbookRangeFillModel? Fill { get; set; }

    [JsonPropertyName("font")]
    public WorkbookRangeFontModel? Font { get; set; }

    [JsonPropertyName("horizontalAlignment")]
    public string? HorizontalAlignment { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("protection")]
    public WorkbookFormatProtectionModel? Protection { get; set; }

    [JsonPropertyName("verticalAlignment")]
    public string? VerticalAlignment { get; set; }

    [JsonPropertyName("wrapText")]
    public bool? WrapText { get; set; }
}
