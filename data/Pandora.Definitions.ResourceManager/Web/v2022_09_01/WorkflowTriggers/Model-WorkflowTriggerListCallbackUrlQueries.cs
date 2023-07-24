using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Web.v2022_09_01.WorkflowTriggers;


internal class WorkflowTriggerListCallbackUrlQueriesModel
{
    [JsonPropertyName("api-version")]
    public string? ApiVersion { get; set; }

    [JsonPropertyName("se")]
    public string? Se { get; set; }

    [JsonPropertyName("sig")]
    public string? Sig { get; set; }

    [JsonPropertyName("sp")]
    public string? Sp { get; set; }

    [JsonPropertyName("sv")]
    public string? Sv { get; set; }
}
