// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class PlannerExternalPlanSourceModel
{
    [JsonPropertyName("contextScenarioId")]
    public string? ContextScenarioId { get; set; }

    [JsonPropertyName("creationSourceKind")]
    public PlannerCreationSourceKindConstant? CreationSourceKind { get; set; }

    [JsonPropertyName("externalContextId")]
    public string? ExternalContextId { get; set; }

    [JsonPropertyName("externalObjectId")]
    public string? ExternalObjectId { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }
}
