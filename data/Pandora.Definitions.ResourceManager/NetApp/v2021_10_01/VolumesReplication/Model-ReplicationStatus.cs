using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.NetApp.v2021_10_01.VolumesReplication;


internal class ReplicationStatusModel
{
    [JsonPropertyName("errorMessage")]
    public string? ErrorMessage { get; set; }

    [JsonPropertyName("healthy")]
    public bool? Healthy { get; set; }

    [JsonPropertyName("mirrorState")]
    public MirrorStateConstant? MirrorState { get; set; }

    [JsonPropertyName("relationshipStatus")]
    public RelationshipStatusConstant? RelationshipStatus { get; set; }

    [JsonPropertyName("totalProgress")]
    public string? TotalProgress { get; set; }
}
