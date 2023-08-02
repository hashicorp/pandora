using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApiManagement.v2022_08_01.QuotaByCounterKeys;


internal class QuotaCounterValueContractPropertiesModel
{
    [JsonPropertyName("callsCount")]
    public int? CallsCount { get; set; }

    [JsonPropertyName("kbTransferred")]
    public float? KbTransferred { get; set; }
}
