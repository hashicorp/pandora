using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.PostgreSql.v2022_03_08_preview.ServerRestart;


internal class RestartParameterModel
{
    [JsonPropertyName("failoverMode")]
    public FailoverModeConstant? FailoverMode { get; set; }

    [JsonPropertyName("restartWithFailover")]
    public bool? RestartWithFailover { get; set; }
}
