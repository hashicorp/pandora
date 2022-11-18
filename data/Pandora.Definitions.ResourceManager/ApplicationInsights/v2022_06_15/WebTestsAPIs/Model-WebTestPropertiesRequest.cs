using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApplicationInsights.v2022_06_15.WebTestsAPIs;


internal class WebTestPropertiesRequestModel
{
    [JsonPropertyName("FollowRedirects")]
    public bool? FollowRedirects { get; set; }

    [JsonPropertyName("HttpVerb")]
    public string? HTTPVerb { get; set; }

    [JsonPropertyName("Headers")]
    public List<HeaderFieldModel>? Headers { get; set; }

    [JsonPropertyName("ParseDependentRequests")]
    public bool? ParseDependentRequests { get; set; }

    [JsonPropertyName("RequestBody")]
    public string? RequestBody { get; set; }

    [JsonPropertyName("RequestUrl")]
    public string? RequestUrl { get; set; }
}
