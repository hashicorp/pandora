using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApplicationInsights.v2015_05_01.ComponentAnnotationsAPIs;


internal class AnnotationModel
{
    [JsonPropertyName("AnnotationName")]
    public string? AnnotationName { get; set; }

    [JsonPropertyName("Category")]
    public string? Category { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("EventTime")]
    public DateTime? EventTime { get; set; }

    [JsonPropertyName("Id")]
    public string? Id { get; set; }

    [JsonPropertyName("Properties")]
    public string? Properties { get; set; }

    [JsonPropertyName("RelatedAnnotation")]
    public string? RelatedAnnotation { get; set; }
}
