// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class SecurityFileModel
{
    [JsonPropertyName("content")]
    public string? Content { get; set; }

    [JsonPropertyName("dateTime")]
    public DateTime? DateTime { get; set; }

    [JsonPropertyName("extension")]
    public string? Extension { get; set; }

    [JsonPropertyName("extractedTextContent")]
    public string? ExtractedTextContent { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("mediaType")]
    public string? MediaType { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("otherProperties")]
    public SecurityStringValueDictionaryModel? OtherProperties { get; set; }

    [JsonPropertyName("processingStatus")]
    public SecurityFileProcessingStatusConstant? ProcessingStatus { get; set; }

    [JsonPropertyName("senderOrAuthors")]
    public List<string>? SenderOrAuthors { get; set; }

    [JsonPropertyName("size")]
    public int? Size { get; set; }

    [JsonPropertyName("sourceType")]
    public SecurityFileSourceTypeConstant? SourceType { get; set; }

    [JsonPropertyName("subjectTitle")]
    public string? SubjectTitle { get; set; }
}
