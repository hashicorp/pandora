using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Compute.v2021_07_01.DedicatedHostGroups;


internal class DedicatedHostGroupPropertiesModel
{
    [JsonPropertyName("hosts")]
    public List<SubResourceReadOnlyModel>? Hosts { get; set; }

    [JsonPropertyName("instanceView")]
    public DedicatedHostGroupInstanceViewModel? InstanceView { get; set; }

    [JsonPropertyName("platformFaultDomainCount")]
    [Required]
    public int PlatformFaultDomainCount { get; set; }

    [JsonPropertyName("supportAutomaticPlacement")]
    public bool? SupportAutomaticPlacement { get; set; }
}
