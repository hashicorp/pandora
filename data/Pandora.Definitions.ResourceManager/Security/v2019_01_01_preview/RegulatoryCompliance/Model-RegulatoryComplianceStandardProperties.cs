using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Security.v2019_01_01_preview.RegulatoryCompliance;


internal class RegulatoryComplianceStandardPropertiesModel
{
    [JsonPropertyName("failedControls")]
    public int? FailedControls { get; set; }

    [JsonPropertyName("passedControls")]
    public int? PassedControls { get; set; }

    [JsonPropertyName("skippedControls")]
    public int? SkippedControls { get; set; }

    [JsonPropertyName("state")]
    public StateConstant? State { get; set; }

    [JsonPropertyName("unsupportedControls")]
    public int? UnsupportedControls { get; set; }
}
