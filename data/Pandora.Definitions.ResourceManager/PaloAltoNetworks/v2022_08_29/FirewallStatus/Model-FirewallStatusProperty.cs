using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.PaloAltoNetworks.v2022_08_29.FirewallStatus;


internal class FirewallStatusPropertyModel
{
    [JsonPropertyName("healthReason")]
    public string? HealthReason { get; set; }

    [JsonPropertyName("healthStatus")]
    public HealthStatusConstant? HealthStatus { get; set; }

    [JsonPropertyName("isPanoramaManaged")]
    public BooleanEnumConstant? IsPanoramaManaged { get; set; }

    [JsonPropertyName("panoramaStatus")]
    public PanoramaStatusModel? PanoramaStatus { get; set; }

    [JsonPropertyName("provisioningState")]
    public ReadOnlyProvisioningStateConstant? ProvisioningState { get; set; }
}
