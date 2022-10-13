using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.AppPlatform.v2022_09_01_preview.AppPlatform;


internal class GatewayRouteConfigPropertiesModel
{
    [JsonPropertyName("appResourceId")]
    public string? AppResourceId { get; set; }

    [JsonPropertyName("openApi")]
    public GatewayRouteConfigOpenApiPropertiesModel? OpenApi { get; set; }

    [JsonPropertyName("protocol")]
    public GatewayRouteConfigProtocolConstant? Protocol { get; set; }

    [JsonPropertyName("provisioningState")]
    public GatewayProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("routes")]
    public List<GatewayApiRouteModel>? Routes { get; set; }
}
