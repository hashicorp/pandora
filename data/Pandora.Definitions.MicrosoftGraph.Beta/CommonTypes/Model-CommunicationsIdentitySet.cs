// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class CommunicationsIdentitySetModel
{
    [JsonPropertyName("application")]
    public IdentityModel? Application { get; set; }

    [JsonPropertyName("applicationInstance")]
    public IdentityModel? ApplicationInstance { get; set; }

    [JsonPropertyName("assertedIdentity")]
    public IdentityModel? AssertedIdentity { get; set; }

    [JsonPropertyName("azureCommunicationServicesUser")]
    public IdentityModel? AzureCommunicationServicesUser { get; set; }

    [JsonPropertyName("device")]
    public IdentityModel? Device { get; set; }

    [JsonPropertyName("encrypted")]
    public IdentityModel? Encrypted { get; set; }

    [JsonPropertyName("endpointType")]
    public CommunicationsIdentitySetEndpointTypeConstant? EndpointType { get; set; }

    [JsonPropertyName("guest")]
    public IdentityModel? Guest { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("onPremises")]
    public IdentityModel? OnPremises { get; set; }

    [JsonPropertyName("phone")]
    public IdentityModel? Phone { get; set; }

    [JsonPropertyName("user")]
    public IdentityModel? User { get; set; }
}
