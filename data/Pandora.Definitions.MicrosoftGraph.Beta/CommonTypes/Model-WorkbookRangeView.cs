// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class WorkbookRangeViewModel
{
    [JsonPropertyName("cellAddresses")]
    public JsonModel? CellAddresses { get; set; }

    [JsonPropertyName("columnCount")]
    public int? ColumnCount { get; set; }

    [JsonPropertyName("formulas")]
    public JsonModel? Formulas { get; set; }

    [JsonPropertyName("formulasLocal")]
    public JsonModel? FormulasLocal { get; set; }

    [JsonPropertyName("formulasR1C1")]
    public JsonModel? FormulasR1C1 { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("index")]
    public int? Index { get; set; }

    [JsonPropertyName("numberFormat")]
    public JsonModel? NumberFormat { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("rowCount")]
    public int? RowCount { get; set; }

    [JsonPropertyName("rows")]
    public List<WorkbookRangeViewModel>? Rows { get; set; }

    [JsonPropertyName("text")]
    public JsonModel? Text { get; set; }

    [JsonPropertyName("valueTypes")]
    public JsonModel? ValueTypes { get; set; }

    [JsonPropertyName("values")]
    public JsonModel? Values { get; set; }
}
