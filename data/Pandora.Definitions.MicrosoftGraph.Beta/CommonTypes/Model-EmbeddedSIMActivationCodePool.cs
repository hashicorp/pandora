// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class EmbeddedSIMActivationCodePoolModel
{
    [JsonPropertyName("activationCodeCount")]
    public int? ActivationCodeCount { get; set; }

    [JsonPropertyName("activationCodes")]
    public List<EmbeddedSIMActivationCodeModel>? ActivationCodes { get; set; }

    [JsonPropertyName("assignments")]
    public List<EmbeddedSIMActivationCodePoolAssignmentModel>? Assignments { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("deviceStates")]
    public List<EmbeddedSIMDeviceStateModel>? DeviceStates { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("modifiedDateTime")]
    public DateTime? ModifiedDateTime { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }
}
