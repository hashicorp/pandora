using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Nginx.v2022_08_01.NginxDeployment;


internal class NginxDeploymentPropertiesModel
{
    [JsonPropertyName("enableDiagnosticsSupport")]
    public bool? EnableDiagnosticsSupport { get; set; }

    [JsonPropertyName("ipAddress")]
    public string? IPAddress { get; set; }

    [JsonPropertyName("logging")]
    public NginxLoggingModel? Logging { get; set; }

    [JsonPropertyName("managedResourceGroup")]
    public string? ManagedResourceGroup { get; set; }

    [JsonPropertyName("networkProfile")]
    public NginxNetworkProfileModel? NetworkProfile { get; set; }

    [JsonPropertyName("nginxVersion")]
    public string? NginxVersion { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }
}
