using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DevCenter.v2023_04_01.AttachedNetworkConnections;


internal class AttachedNetworkConnectionPropertiesModel
{
    [JsonPropertyName("domainJoinType")]
    public DomainJoinTypeConstant? DomainJoinType { get; set; }

    [JsonPropertyName("healthCheckStatus")]
    public HealthCheckStatusConstant? HealthCheckStatus { get; set; }

    [JsonPropertyName("networkConnectionId")]
    [Required]
    public string NetworkConnectionId { get; set; }

    [JsonPropertyName("networkConnectionLocation")]
    public string? NetworkConnectionLocation { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }
}
