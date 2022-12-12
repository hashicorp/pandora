using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MobileNetwork.v2022_11_01.SIMPolicy;


internal class DataNetworkConfigurationModel
{
    [MaxItems(1)]
    [JsonPropertyName("additionalAllowedSessionTypes")]
    public List<PduSessionTypeConstant>? AdditionalAllowedSessionTypes { get; set; }

    [JsonPropertyName("allocationAndRetentionPriorityLevel")]
    public int? AllocationAndRetentionPriorityLevel { get; set; }

    [MinItems(1)]
    [JsonPropertyName("allowedServices")]
    [Required]
    public List<ServiceResourceIdModel> AllowedServices { get; set; }

    [JsonPropertyName("dataNetwork")]
    [Required]
    public DataNetworkResourceIdModel DataNetwork { get; set; }

    [JsonPropertyName("defaultSessionType")]
    public PduSessionTypeConstant? DefaultSessionType { get; set; }

    [JsonPropertyName("5qi")]
    public int? Fiveqi { get; set; }

    [JsonPropertyName("maximumNumberOfBufferedPackets")]
    public int? MaximumNumberOfBufferedPackets { get; set; }

    [JsonPropertyName("preemptionCapability")]
    public PreemptionCapabilityConstant? PreemptionCapability { get; set; }

    [JsonPropertyName("preemptionVulnerability")]
    public PreemptionVulnerabilityConstant? PreemptionVulnerability { get; set; }

    [JsonPropertyName("sessionAmbr")]
    [Required]
    public AmbrModel SessionAmbr { get; set; }
}
