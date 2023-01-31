using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataBoxEdge.v2022_03_01.Devices;


internal class UploadCertificateResponseModel
{
    [JsonPropertyName("aadAudience")]
    public string? AadAudience { get; set; }

    [JsonPropertyName("aadAuthority")]
    public string? AadAuthority { get; set; }

    [JsonPropertyName("aadTenantId")]
    public string? AadTenantId { get; set; }

    [JsonPropertyName("authType")]
    public AuthenticationTypeConstant? AuthType { get; set; }

    [JsonPropertyName("azureManagementEndpointAudience")]
    public string? AzureManagementEndpointAudience { get; set; }

    [JsonPropertyName("resourceId")]
    public string? ResourceId { get; set; }

    [JsonPropertyName("servicePrincipalClientId")]
    public string? ServicePrincipalClientId { get; set; }

    [JsonPropertyName("servicePrincipalObjectId")]
    public string? ServicePrincipalObjectId { get; set; }
}
