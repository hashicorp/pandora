using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.AzureStackHCI.v2023_08_01.Cluster;


internal class IsolatedVMAttestationConfigurationModel
{
    [JsonPropertyName("attestationResourceId")]
    public string? AttestationResourceId { get; set; }

    [JsonPropertyName("attestationServiceEndpoint")]
    public string? AttestationServiceEndpoint { get; set; }

    [JsonPropertyName("relyingPartyServiceEndpoint")]
    public string? RelyingPartyServiceEndpoint { get; set; }
}
