// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class WorkbookModel
{
    [JsonPropertyName("application")]
    public WorkbookApplicationModel? Application { get; set; }

    [JsonPropertyName("comments")]
    public List<WorkbookCommentModel>? Comments { get; set; }

    [JsonPropertyName("functions")]
    public WorkbookFunctionsModel? Functions { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("names")]
    public List<WorkbookNamedItemModel>? Names { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("operations")]
    public List<WorkbookOperationModel>? Operations { get; set; }

    [JsonPropertyName("tables")]
    public List<WorkbookTableModel>? Tables { get; set; }

    [JsonPropertyName("worksheets")]
    public List<WorkbookWorksheetModel>? Worksheets { get; set; }
}
