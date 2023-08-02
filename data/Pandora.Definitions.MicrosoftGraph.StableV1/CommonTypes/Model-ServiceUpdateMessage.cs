// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class ServiceUpdateMessageModel
{
    [JsonPropertyName("actionRequiredByDateTime")]
    public DateTime? ActionRequiredByDateTime { get; set; }

    [JsonPropertyName("attachments")]
    public List<ServiceAnnouncementAttachmentModel>? Attachments { get; set; }

    [JsonPropertyName("attachmentsArchive")]
    public string? AttachmentsArchive { get; set; }

    [JsonPropertyName("body")]
    public ItemBodyModel? Body { get; set; }

    [JsonPropertyName("category")]
    public ServiceUpdateCategoryConstant? Category { get; set; }

    [JsonPropertyName("details")]
    public List<KeyValuePairModel>? Details { get; set; }

    [JsonPropertyName("endDateTime")]
    public DateTime? EndDateTime { get; set; }

    [JsonPropertyName("hasAttachments")]
    public bool? HasAttachments { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("isMajorChange")]
    public bool? IsMajorChange { get; set; }

    [JsonPropertyName("lastModifiedDateTime")]
    public DateTime? LastModifiedDateTime { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("services")]
    public List<string>? Services { get; set; }

    [JsonPropertyName("severity")]
    public ServiceUpdateSeverityConstant? Severity { get; set; }

    [JsonPropertyName("startDateTime")]
    public DateTime? StartDateTime { get; set; }

    [JsonPropertyName("tags")]
    public List<string>? Tags { get; set; }

    [JsonPropertyName("title")]
    public string? Title { get; set; }

    [JsonPropertyName("viewPoint")]
    public ServiceUpdateMessageViewpointModel? ViewPoint { get; set; }
}
