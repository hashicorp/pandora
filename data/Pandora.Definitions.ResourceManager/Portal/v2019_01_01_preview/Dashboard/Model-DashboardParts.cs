using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Portal.v2019_01_01_preview.Dashboard;


internal class DashboardPartsModel
{
    [JsonPropertyName("metadata")]
    public object? Metadata { get; set; }

    [JsonPropertyName("position")]
    [Required]
    public DashboardPartsPositionModel Position { get; set; }
}
