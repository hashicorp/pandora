using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.NetworkCloud.v2023_07_01.Networkclouds;


internal class ConsolePropertiesModel
{
    [JsonPropertyName("detailedStatus")]
    public ConsoleDetailedStatusConstant? DetailedStatus { get; set; }

    [JsonPropertyName("detailedStatusMessage")]
    public string? DetailedStatusMessage { get; set; }

    [JsonPropertyName("enabled")]
    [Required]
    public ConsoleEnabledConstant Enabled { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("expiration")]
    public DateTime? Expiration { get; set; }

    [JsonPropertyName("privateLinkServiceId")]
    public string? PrivateLinkServiceId { get; set; }

    [JsonPropertyName("provisioningState")]
    public ConsoleProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("sshPublicKey")]
    [Required]
    public SshPublicKeyModel SshPublicKey { get; set; }

    [JsonPropertyName("virtualMachineAccessId")]
    public string? VirtualMachineAccessId { get; set; }
}
