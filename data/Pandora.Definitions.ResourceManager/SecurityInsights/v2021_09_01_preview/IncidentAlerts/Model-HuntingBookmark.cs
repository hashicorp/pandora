using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2021_09_01_preview.IncidentAlerts;

[ValueForType("Bookmark")]
internal class HuntingBookmarkModel : EntityModel
{
    [JsonPropertyName("properties")]
    public HuntingBookmarkPropertiesModel? Properties { get; set; }
}
