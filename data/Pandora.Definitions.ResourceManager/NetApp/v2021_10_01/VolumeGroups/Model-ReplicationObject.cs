using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.NetApp.v2021_10_01.VolumeGroups;


internal class ReplicationObjectModel
{
    [JsonPropertyName("endpointType")]
    public EndpointTypeConstant? EndpointType { get; set; }

    [JsonPropertyName("remoteVolumeRegion")]
    public string? RemoteVolumeRegion { get; set; }

    [JsonPropertyName("remoteVolumeResourceId")]
    [Required]
    public string RemoteVolumeResourceId { get; set; }

    [JsonPropertyName("replicationId")]
    public string? ReplicationId { get; set; }

    [JsonPropertyName("replicationSchedule")]
    public ReplicationScheduleConstant? ReplicationSchedule { get; set; }
}
