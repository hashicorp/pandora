// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class IdentityProtectionRootModel
{
    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("riskDetections")]
    public List<RiskDetectionModel>? RiskDetections { get; set; }

    [JsonPropertyName("riskyServicePrincipals")]
    public List<RiskyServicePrincipalModel>? RiskyServicePrincipals { get; set; }

    [JsonPropertyName("riskyUsers")]
    public List<RiskyUserModel>? RiskyUsers { get; set; }

    [JsonPropertyName("servicePrincipalRiskDetections")]
    public List<ServicePrincipalRiskDetectionModel>? ServicePrincipalRiskDetections { get; set; }
}
