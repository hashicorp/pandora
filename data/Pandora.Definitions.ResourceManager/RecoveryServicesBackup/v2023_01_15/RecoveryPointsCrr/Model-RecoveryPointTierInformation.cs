using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2023_01_15.RecoveryPointsCrr;


internal class RecoveryPointTierInformationModel
{
    [JsonPropertyName("extendedInfo")]
    public Dictionary<string, string>? ExtendedInfo { get; set; }

    [JsonPropertyName("status")]
    public RecoveryPointTierStatusConstant? Status { get; set; }

    [JsonPropertyName("type")]
    public RecoveryPointTierTypeConstant? Type { get; set; }
}
