using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2021_12_01.BackupProtectedItems;


internal class KPIResourceHealthDetailsModel
{
    [JsonPropertyName("resourceHealthDetails")]
    public List<ResourceHealthDetailsModel>? ResourceHealthDetails { get; set; }

    [JsonPropertyName("resourceHealthStatus")]
    public ResourceHealthStatusConstant? ResourceHealthStatus { get; set; }
}
