using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Automation.v2019_06_01.Runbook;


internal class RunbookDraftModel
{
    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("creationTime")]
    public DateTime? CreationTime { get; set; }

    [JsonPropertyName("draftContentLink")]
    public ContentLinkModel? DraftContentLink { get; set; }

    [JsonPropertyName("inEdit")]
    public bool? InEdit { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastModifiedTime")]
    public DateTime? LastModifiedTime { get; set; }

    [JsonPropertyName("outputTypes")]
    public List<string>? OutputTypes { get; set; }

    [JsonPropertyName("parameters")]
    public Dictionary<string, RunbookParameterModel>? Parameters { get; set; }
}
