using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Compute.v2021_11_01.DedicatedHosts;


internal class DedicatedHostPropertiesModel
{
    [JsonPropertyName("autoReplaceOnFailure")]
    public bool? AutoReplaceOnFailure { get; set; }

    [JsonPropertyName("hostId")]
    public string? HostId { get; set; }

    [JsonPropertyName("instanceView")]
    public DedicatedHostInstanceViewModel? InstanceView { get; set; }

    [JsonPropertyName("licenseType")]
    public DedicatedHostLicenseTypesConstant? LicenseType { get; set; }

    [JsonPropertyName("platformFaultDomain")]
    public int? PlatformFaultDomain { get; set; }

    [JsonPropertyName("provisioningState")]
    public string? ProvisioningState { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("provisioningTime")]
    public DateTime? ProvisioningTime { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("timeCreated")]
    public DateTime? TimeCreated { get; set; }

    [JsonPropertyName("virtualMachines")]
    public List<SubResourceReadOnlyModel>? VirtualMachines { get; set; }
}
