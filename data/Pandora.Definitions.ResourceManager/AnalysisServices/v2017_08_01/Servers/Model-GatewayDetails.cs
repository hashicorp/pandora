using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.AnalysisServices.v2017_08_01.Servers;


internal class GatewayDetailsModel
{
    [JsonPropertyName("dmtsClusterUri")]
    public string? DmtsClusterUri { get; set; }

    [JsonPropertyName("gatewayObjectId")]
    public string? GatewayObjectId { get; set; }

    [JsonPropertyName("gatewayResourceId")]
    public string? GatewayResourceId { get; set; }
}
