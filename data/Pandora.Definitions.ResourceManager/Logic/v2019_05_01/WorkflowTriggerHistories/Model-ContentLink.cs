using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Logic.v2019_05_01.WorkflowTriggerHistories;


internal class ContentLinkModel
{
    [JsonPropertyName("contentHash")]
    public ContentHashModel? ContentHash { get; set; }

    [JsonPropertyName("contentSize")]
    public int? ContentSize { get; set; }

    [JsonPropertyName("contentVersion")]
    public string? ContentVersion { get; set; }

    [JsonPropertyName("metadata")]
    public object? Metadata { get; set; }

    [JsonPropertyName("uri")]
    public string? Uri { get; set; }
}
