// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class WorkbookWorksheetProtectionOptionsModel
{
    [JsonPropertyName("allowAutoFilter")]
    public bool? AllowAutoFilter { get; set; }

    [JsonPropertyName("allowDeleteColumns")]
    public bool? AllowDeleteColumns { get; set; }

    [JsonPropertyName("allowDeleteRows")]
    public bool? AllowDeleteRows { get; set; }

    [JsonPropertyName("allowFormatCells")]
    public bool? AllowFormatCells { get; set; }

    [JsonPropertyName("allowFormatColumns")]
    public bool? AllowFormatColumns { get; set; }

    [JsonPropertyName("allowFormatRows")]
    public bool? AllowFormatRows { get; set; }

    [JsonPropertyName("allowInsertColumns")]
    public bool? AllowInsertColumns { get; set; }

    [JsonPropertyName("allowInsertHyperlinks")]
    public bool? AllowInsertHyperlinks { get; set; }

    [JsonPropertyName("allowInsertRows")]
    public bool? AllowInsertRows { get; set; }

    [JsonPropertyName("allowPivotTables")]
    public bool? AllowPivotTables { get; set; }

    [JsonPropertyName("allowSort")]
    public bool? AllowSort { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }
}
