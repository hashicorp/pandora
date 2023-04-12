using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Automation.v2022_08_08.Operations;


internal class RawGraphicalRunbookContentModel
{
    [JsonPropertyName("runbookDefinition")]
    public string? RunbookDefinition { get; set; }

    [JsonPropertyName("runbookType")]
    public GraphRunbookTypeConstant? RunbookType { get; set; }

    [JsonPropertyName("schemaVersion")]
    public string? SchemaVersion { get; set; }
}
