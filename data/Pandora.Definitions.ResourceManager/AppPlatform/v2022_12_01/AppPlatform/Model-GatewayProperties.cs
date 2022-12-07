using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.AppPlatform.v2022_12_01.AppPlatform;


internal class GatewayPropertiesModel
{
    [JsonPropertyName("apiMetadataProperties")]
    public GatewayApiMetadataPropertiesModel? ApiMetadataProperties { get; set; }

    [JsonPropertyName("corsProperties")]
    public GatewayCorsPropertiesModel? CorsProperties { get; set; }

    [JsonPropertyName("httpsOnly")]
    public bool? HTTPSOnly { get; set; }

    [JsonPropertyName("instances")]
    public List<GatewayInstanceModel>? Instances { get; set; }

    [JsonPropertyName("operatorProperties")]
    public GatewayOperatorPropertiesModel? OperatorProperties { get; set; }

    [JsonPropertyName("provisioningState")]
    public GatewayProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("public")]
    public bool? Public { get; set; }

    [JsonPropertyName("resourceRequests")]
    public GatewayResourceRequestsModel? ResourceRequests { get; set; }

    [JsonPropertyName("ssoProperties")]
    public SsoPropertiesModel? SsoProperties { get; set; }

    [JsonPropertyName("url")]
    public string? Url { get; set; }
}
