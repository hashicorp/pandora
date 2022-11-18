using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Storage.v2022_09_01.ManagementPolicies;


internal class ManagementPolicySnapShotModel
{
    [JsonPropertyName("delete")]
    public DateAfterCreationModel? Delete { get; set; }

    [JsonPropertyName("tierToArchive")]
    public DateAfterCreationModel? TierToArchive { get; set; }

    [JsonPropertyName("tierToCold")]
    public DateAfterCreationModel? TierToCold { get; set; }

    [JsonPropertyName("tierToCool")]
    public DateAfterCreationModel? TierToCool { get; set; }

    [JsonPropertyName("tierToHot")]
    public DateAfterCreationModel? TierToHot { get; set; }
}
