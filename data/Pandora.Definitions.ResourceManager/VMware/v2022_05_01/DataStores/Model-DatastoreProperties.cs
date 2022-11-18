using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.VMware.v2022_05_01.DataStores;


internal class DatastorePropertiesModel
{
    [JsonPropertyName("diskPoolVolume")]
    public DiskPoolVolumeModel? DiskPoolVolume { get; set; }

    [JsonPropertyName("netAppVolume")]
    public NetAppVolumeModel? NetAppVolume { get; set; }

    [JsonPropertyName("provisioningState")]
    public DatastoreProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("status")]
    public DatastoreStatusConstant? Status { get; set; }
}
