// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class WorkbookDocumentTaskModel
{
    [JsonPropertyName("assignees")]
    public List<WorkbookEmailIdentityModel>? Assignees { get; set; }

    [JsonPropertyName("changes")]
    public List<WorkbookDocumentTaskChangeModel>? Changes { get; set; }

    [JsonPropertyName("comment")]
    public WorkbookCommentModel? Comment { get; set; }

    [JsonPropertyName("completedBy")]
    public WorkbookEmailIdentityModel? CompletedBy { get; set; }

    [JsonPropertyName("completedDateTime")]
    public DateTime? CompletedDateTime { get; set; }

    [JsonPropertyName("createdBy")]
    public WorkbookEmailIdentityModel? CreatedBy { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("percentComplete")]
    public int? PercentComplete { get; set; }

    [JsonPropertyName("priority")]
    public int? Priority { get; set; }

    [JsonPropertyName("startAndDueDateTime")]
    public WorkbookDocumentTaskScheduleModel? StartAndDueDateTime { get; set; }

    [JsonPropertyName("title")]
    public string? Title { get; set; }
}
