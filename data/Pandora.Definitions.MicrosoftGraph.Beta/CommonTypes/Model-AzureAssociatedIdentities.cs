// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class AzureAssociatedIdentitiesModel
{
    [JsonPropertyName("all")]
    public List<AzureIdentityModel>? All { get; set; }

    [JsonPropertyName("managedIdentities")]
    public List<AzureManagedIdentityModel>? ManagedIdentities { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("servicePrincipals")]
    public List<AzureServicePrincipalModel>? ServicePrincipals { get; set; }

    [JsonPropertyName("users")]
    public List<AzureUserModel>? Users { get; set; }
}
