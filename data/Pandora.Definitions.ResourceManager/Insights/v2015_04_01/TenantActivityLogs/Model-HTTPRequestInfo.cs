using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Insights.v2015_04_01.TenantActivityLogs;


internal class HTTPRequestInfoModel
{
    [JsonPropertyName("clientIpAddress")]
    public string? ClientIPAddress { get; set; }

    [JsonPropertyName("clientRequestId")]
    public string? ClientRequestId { get; set; }

    [JsonPropertyName("method")]
    public string? Method { get; set; }

    [JsonPropertyName("uri")]
    public string? Uri { get; set; }
}
