// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class IncomingContextModel
{
    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("observedParticipantId")]
    public string? ObservedParticipantId { get; set; }

    [JsonPropertyName("onBehalfOf")]
    public IdentitySetModel? OnBehalfOf { get; set; }

    [JsonPropertyName("sourceParticipantId")]
    public string? SourceParticipantId { get; set; }

    [JsonPropertyName("transferor")]
    public IdentitySetModel? Transferor { get; set; }
}
