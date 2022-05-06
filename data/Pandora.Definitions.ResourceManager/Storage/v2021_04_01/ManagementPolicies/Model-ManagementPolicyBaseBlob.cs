using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Storage.v2021_04_01.ManagementPolicies;


internal class ManagementPolicyBaseBlobModel
{
    [JsonPropertyName("delete")]
    public DateAfterModificationModel? Delete { get; set; }

    [JsonPropertyName("enableAutoTierToHotFromCool")]
    public bool? EnableAutoTierToHotFromCool { get; set; }

    [JsonPropertyName("tierToArchive")]
    public DateAfterModificationModel? TierToArchive { get; set; }

    [JsonPropertyName("tierToCool")]
    public DateAfterModificationModel? TierToCool { get; set; }
}
