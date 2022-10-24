using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2022_07_01_preview.IncidentComments;


internal class IncidentCommentPropertiesModel
{
    [JsonPropertyName("author")]
    public ClientInfoModel? Author { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("createdTimeUtc")]
    public DateTime? CreatedTimeUtc { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastModifiedTimeUtc")]
    public DateTime? LastModifiedTimeUtc { get; set; }

    [JsonPropertyName("message")]
    [Required]
    public string Message { get; set; }
}
