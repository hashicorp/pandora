using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2023_04_01.ProtectionContainers;

[ValueForType("Microsoft.ClassicCompute/virtualMachines")]
internal class AzureIaaSClassicComputeVMContainerModel : ProtectionContainerModel
{
    [JsonPropertyName("resourceGroup")]
    public string? ResourceGroup { get; set; }

    [JsonPropertyName("virtualMachineId")]
    public string? VirtualMachineId { get; set; }

    [JsonPropertyName("virtualMachineVersion")]
    public string? VirtualMachineVersion { get; set; }
}
