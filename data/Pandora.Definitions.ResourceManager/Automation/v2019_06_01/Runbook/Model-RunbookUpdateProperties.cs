using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Automation.v2019_06_01.Runbook;


internal class RunbookUpdatePropertiesModel
{
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("logActivityTrace")]
    public int? LogActivityTrace { get; set; }

    [JsonPropertyName("logProgress")]
    public bool? LogProgress { get; set; }

    [JsonPropertyName("logVerbose")]
    public bool? LogVerbose { get; set; }
}
