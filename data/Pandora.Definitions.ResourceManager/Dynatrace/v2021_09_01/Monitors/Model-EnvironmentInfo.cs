using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Dynatrace.v2021_09_01.Monitors;


internal class EnvironmentInfoModel
{
    [JsonPropertyName("environmentId")]
    public string? EnvironmentId { get; set; }

    [JsonPropertyName("ingestionKey")]
    public string? IngestionKey { get; set; }

    [JsonPropertyName("landingURL")]
    public string? LandingURL { get; set; }

    [JsonPropertyName("logsIngestionEndpoint")]
    public string? LogsIngestionEndpoint { get; set; }
}
