using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Automation.v2021_06_22.Operations;


internal class GraphicalRunbookContentModel
{
    [JsonPropertyName("graphRunbookJson")]
    public string? GraphRunbookJson { get; set; }

    [JsonPropertyName("rawContent")]
    public RawGraphicalRunbookContentModel? RawContent { get; set; }
}
