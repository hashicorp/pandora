using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_09_10.ReplicationProtectedItems;


internal class IPConfigDetailsModel
{
    [JsonPropertyName("ipAddressType")]
    public string? IPAddressType { get; set; }

    [JsonPropertyName("isPrimary")]
    public bool? IsPrimary { get; set; }

    [JsonPropertyName("isSeletedForFailover")]
    public bool? IsSeletedForFailover { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("recoveryIPAddressType")]
    public string? RecoveryIPAddressType { get; set; }

    [JsonPropertyName("recoveryLBBackendAddressPoolIds")]
    public List<string>? RecoveryLBBackendAddressPoolIds { get; set; }

    [JsonPropertyName("recoveryPublicIPAddressId")]
    public string? RecoveryPublicIPAddressId { get; set; }

    [JsonPropertyName("recoveryStaticIPAddress")]
    public string? RecoveryStaticIPAddress { get; set; }

    [JsonPropertyName("recoverySubnetName")]
    public string? RecoverySubnetName { get; set; }

    [JsonPropertyName("staticIPAddress")]
    public string? StaticIPAddress { get; set; }

    [JsonPropertyName("subnetName")]
    public string? SubnetName { get; set; }

    [JsonPropertyName("tfoLBBackendAddressPoolIds")]
    public List<string>? TfoLBBackendAddressPoolIds { get; set; }

    [JsonPropertyName("tfoPublicIPAddressId")]
    public string? TfoPublicIPAddressId { get; set; }

    [JsonPropertyName("tfoStaticIPAddress")]
    public string? TfoStaticIPAddress { get; set; }

    [JsonPropertyName("tfoSubnetName")]
    public string? TfoSubnetName { get; set; }
}
