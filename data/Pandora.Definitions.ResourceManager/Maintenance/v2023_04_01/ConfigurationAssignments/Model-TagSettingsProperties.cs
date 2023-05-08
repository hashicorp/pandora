using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Maintenance.v2023_04_01.ConfigurationAssignments;


internal class TagSettingsPropertiesModel
{
    [JsonPropertyName("filterOperator")]
    public TagOperatorsConstant? FilterOperator { get; set; }

    [JsonPropertyName("tags")]
    public Dictionary<string, List<string>>? Tags { get; set; }
}
