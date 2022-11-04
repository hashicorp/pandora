using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.LabServices.v2022_08_01.Lab;


internal class LabPropertiesModel
{
    [JsonPropertyName("autoShutdownProfile")]
    [Required]
    public AutoShutdownProfileModel AutoShutdownProfile { get; set; }

    [JsonPropertyName("connectionProfile")]
    [Required]
    public ConnectionProfileModel ConnectionProfile { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("labPlanId")]
    public string? LabPlanId { get; set; }

    [JsonPropertyName("networkProfile")]
    public LabNetworkProfileModel? NetworkProfile { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("rosterProfile")]
    public RosterProfileModel? RosterProfile { get; set; }

    [JsonPropertyName("securityProfile")]
    [Required]
    public SecurityProfileModel SecurityProfile { get; set; }

    [JsonPropertyName("state")]
    public LabStateConstant? State { get; set; }

    [JsonPropertyName("title")]
    public string? Title { get; set; }

    [JsonPropertyName("virtualMachineProfile")]
    [Required]
    public VirtualMachineProfileModel VirtualMachineProfile { get; set; }
}
