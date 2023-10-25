using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Sql.v2021_11_01.ServerAutomaticTuning;


internal class AutomaticTuningServerPropertiesModel
{
    [JsonPropertyName("actualState")]
    public AutomaticTuningServerModeConstant? ActualState { get; set; }

    [JsonPropertyName("desiredState")]
    public AutomaticTuningServerModeConstant? DesiredState { get; set; }

    [JsonPropertyName("options")]
    public Dictionary<string, AutomaticTuningServerOptionsModel>? Options { get; set; }
}
