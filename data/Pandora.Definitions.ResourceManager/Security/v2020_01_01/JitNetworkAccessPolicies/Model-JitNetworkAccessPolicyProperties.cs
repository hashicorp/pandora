using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Security.v2020_01_01.JitNetworkAccessPolicies;


internal class JitNetworkAccessPolicyPropertiesModel
{
    [JsonPropertyName("provisioningState")]
    public string? ProvisioningState { get; set; }

    [JsonPropertyName("requests")]
    public List<JitNetworkAccessRequestModel>? Requests { get; set; }

    [JsonPropertyName("virtualMachines")]
    [Required]
    public List<JitNetworkAccessPolicyVirtualMachineModel> VirtualMachines { get; set; }
}
