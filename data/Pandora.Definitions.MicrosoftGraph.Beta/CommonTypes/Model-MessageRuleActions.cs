// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class MessageRuleActionsModel
{
    [JsonPropertyName("assignCategories")]
    public List<string>? AssignCategories { get; set; }

    [JsonPropertyName("copyToFolder")]
    public string? CopyToFolder { get; set; }

    [JsonPropertyName("delete")]
    public bool? Delete { get; set; }

    [JsonPropertyName("forwardAsAttachmentTo")]
    public List<RecipientModel>? ForwardAsAttachmentTo { get; set; }

    [JsonPropertyName("forwardTo")]
    public List<RecipientModel>? ForwardTo { get; set; }

    [JsonPropertyName("markAsRead")]
    public bool? MarkAsRead { get; set; }

    [JsonPropertyName("markImportance")]
    public MessageRuleActionsMarkImportanceConstant? MarkImportance { get; set; }

    [JsonPropertyName("moveToFolder")]
    public string? MoveToFolder { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("permanentDelete")]
    public bool? PermanentDelete { get; set; }

    [JsonPropertyName("redirectTo")]
    public List<RecipientModel>? RedirectTo { get; set; }

    [JsonPropertyName("stopProcessingRules")]
    public bool? StopProcessingRules { get; set; }
}
