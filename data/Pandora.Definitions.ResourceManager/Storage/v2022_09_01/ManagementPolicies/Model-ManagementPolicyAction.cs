using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Storage.v2022_09_01.ManagementPolicies;


internal class ManagementPolicyActionModel
{
    [JsonPropertyName("baseBlob")]
    public ManagementPolicyBaseBlobModel? BaseBlob { get; set; }

    [JsonPropertyName("snapshot")]
    public ManagementPolicySnapShotModel? Snapshot { get; set; }

    [JsonPropertyName("version")]
    public ManagementPolicyVersionModel? Version { get; set; }
}
