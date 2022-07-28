using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2021_08_01.CustomIPPrefixes;


internal class CustomIPPrefixPropertiesFormatModel
{
    [JsonPropertyName("authorizationMessage")]
    public string? AuthorizationMessage { get; set; }

    [JsonPropertyName("childCustomIpPrefixes")]
    public List<SubResourceModel>? ChildCustomIPPrefixes { get; set; }

    [JsonPropertyName("cidr")]
    public string? Cidr { get; set; }

    [JsonPropertyName("commissionedState")]
    public CommissionedStateConstant? CommissionedState { get; set; }

    [JsonPropertyName("customIpPrefixParent")]
    public SubResourceModel? CustomIPPrefixParent { get; set; }

    [JsonPropertyName("failedReason")]
    public string? FailedReason { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("publicIpPrefixes")]
    public List<SubResourceModel>? PublicIPPrefixes { get; set; }

    [JsonPropertyName("resourceGuid")]
    public string? ResourceGuid { get; set; }

    [JsonPropertyName("signedMessage")]
    public string? SignedMessage { get; set; }
}
