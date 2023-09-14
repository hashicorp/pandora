using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Migrate.v2023_06_06.WebAppSitesController;


internal class WebAppSiteUsageModel
{
    [JsonPropertyName("runAsAccountCount")]
    public int? RunAsAccountCount { get; set; }

    [JsonPropertyName("webApplicationCount")]
    public int? WebApplicationCount { get; set; }

    [JsonPropertyName("webServerCount")]
    public int? WebServerCount { get; set; }
}
