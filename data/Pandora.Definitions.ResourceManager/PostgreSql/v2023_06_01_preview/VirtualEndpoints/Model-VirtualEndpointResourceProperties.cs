using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.PostgreSql.v2023_06_01_preview.VirtualEndpoints;


internal class VirtualEndpointResourcePropertiesModel
{
    [JsonPropertyName("endpointType")]
    public VirtualEndpointTypeConstant? EndpointType { get; set; }

    [JsonPropertyName("members")]
    public List<string>? Members { get; set; }

    [JsonPropertyName("virtualEndpoints")]
    public List<string>? VirtualEndpoints { get; set; }
}
