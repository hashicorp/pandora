using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MobileNetwork.v2023_06_01.SIMs;


internal class SimDeleteListModel
{
    [MinItems(1)]
    [JsonPropertyName("sims")]
    [Required]
    public List<string> Sims { get; set; }
}
