using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.LabServices.v2022_08_01.VirtualMachine;


internal class VirtualMachinePropertiesModel
{
    [JsonPropertyName("claimedByUserId")]
    public string? ClaimedByUserId { get; set; }

    [JsonPropertyName("connectionProfile")]
    public VirtualMachineConnectionProfileModel? ConnectionProfile { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("state")]
    public VirtualMachineStateConstant? State { get; set; }

    [JsonPropertyName("vmType")]
    public VirtualMachineTypeConstant? VmType { get; set; }
}
