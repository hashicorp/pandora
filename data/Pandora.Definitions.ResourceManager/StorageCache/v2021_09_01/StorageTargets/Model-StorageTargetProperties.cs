using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.StorageCache.v2021_09_01.StorageTargets;


internal class StorageTargetPropertiesModel
{
    [JsonPropertyName("blobNfs")]
    public BlobNfsTargetModel? BlobNfs { get; set; }

    [JsonPropertyName("clfs")]
    public ClfsTargetModel? Clfs { get; set; }

    [JsonPropertyName("junctions")]
    public List<NamespaceJunctionModel>? Junctions { get; set; }

    [JsonPropertyName("nfs3")]
    public Nfs3TargetModel? Nfs3 { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateTypeConstant? ProvisioningState { get; set; }

    [JsonPropertyName("state")]
    public OperationalStateTypeConstant? State { get; set; }

    [JsonPropertyName("targetType")]
    [Required]
    public StorageTargetTypeConstant TargetType { get; set; }

    [JsonPropertyName("unknown")]
    public UnknownTargetModel? Unknown { get; set; }
}
