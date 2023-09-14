using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.AzureStackHCI.v2023_06_01.Clusters;


internal class ClusterPatchModel
{
    [JsonPropertyName("identity")]
    public CustomTypes.SystemAndUserAssignedIdentityMap? Identity { get; set; }

    [JsonPropertyName("properties")]
    public ClusterPatchPropertiesModel? Properties { get; set; }

    [JsonPropertyName("tags")]
    public CustomTypes.Tags? Tags { get; set; }
}
