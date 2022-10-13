using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.AppPlatform.v2022_09_01_preview.AppPlatform;


internal class ApiPortalPropertiesModel
{
    [JsonPropertyName("gatewayIds")]
    public List<string>? GatewayIds { get; set; }

    [JsonPropertyName("httpsOnly")]
    public bool? HTTPSOnly { get; set; }

    [JsonPropertyName("instances")]
    public List<ApiPortalInstanceModel>? Instances { get; set; }

    [JsonPropertyName("provisioningState")]
    public ApiPortalProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("public")]
    public bool? Public { get; set; }

    [JsonPropertyName("resourceRequests")]
    public ApiPortalResourceRequestsModel? ResourceRequests { get; set; }

    [JsonPropertyName("sourceUrls")]
    public List<string>? SourceUrls { get; set; }

    [JsonPropertyName("ssoProperties")]
    public SsoPropertiesModel? SsoProperties { get; set; }

    [JsonPropertyName("url")]
    public string? Url { get; set; }
}
