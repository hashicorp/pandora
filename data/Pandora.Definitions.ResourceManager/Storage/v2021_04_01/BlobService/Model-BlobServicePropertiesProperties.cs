using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Storage.v2021_04_01.BlobService;


internal class BlobServicePropertiesPropertiesModel
{
    [JsonPropertyName("automaticSnapshotPolicyEnabled")]
    public bool? AutomaticSnapshotPolicyEnabled { get; set; }

    [JsonPropertyName("changeFeed")]
    public ChangeFeedModel? ChangeFeed { get; set; }

    [JsonPropertyName("containerDeleteRetentionPolicy")]
    public DeleteRetentionPolicyModel? ContainerDeleteRetentionPolicy { get; set; }

    [JsonPropertyName("cors")]
    public CorsRulesModel? Cors { get; set; }

    [JsonPropertyName("defaultServiceVersion")]
    public string? DefaultServiceVersion { get; set; }

    [JsonPropertyName("deleteRetentionPolicy")]
    public DeleteRetentionPolicyModel? DeleteRetentionPolicy { get; set; }

    [JsonPropertyName("isVersioningEnabled")]
    public bool? IsVersioningEnabled { get; set; }

    [JsonPropertyName("lastAccessTimeTrackingPolicy")]
    public LastAccessTimeTrackingPolicyModel? LastAccessTimeTrackingPolicy { get; set; }

    [JsonPropertyName("restorePolicy")]
    public RestorePolicyPropertiesModel? RestorePolicy { get; set; }
}
