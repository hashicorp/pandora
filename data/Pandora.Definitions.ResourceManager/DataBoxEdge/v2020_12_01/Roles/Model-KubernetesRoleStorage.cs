using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataBoxEdge.v2020_12_01.Roles;


internal class KubernetesRoleStorageModel
{
    [JsonPropertyName("endpoints")]
    public List<MountPointMapModel>? Endpoints { get; set; }

    [JsonPropertyName("storageClasses")]
    public List<KubernetesRoleStorageClassInfoModel>? StorageClasses { get; set; }
}
