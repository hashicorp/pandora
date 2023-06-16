using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.NetApp.v2022_11_01.VolumeGroups;


internal class VolumeRelocationPropertiesModel
{
    [JsonPropertyName("readyToBeFinalized")]
    public bool? ReadyToBeFinalized { get; set; }

    [JsonPropertyName("relocationRequested")]
    public bool? RelocationRequested { get; set; }
}
