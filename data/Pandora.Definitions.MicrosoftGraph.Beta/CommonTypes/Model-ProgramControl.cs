// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class ProgramControlModel
{
    [JsonPropertyName("controlId")]
    public string? ControlId { get; set; }

    [JsonPropertyName("controlTypeId")]
    public string? ControlTypeId { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("owner")]
    public UserIdentityModel? Owner { get; set; }

    [JsonPropertyName("program")]
    public ProgramModel? Program { get; set; }

    [JsonPropertyName("programId")]
    public string? ProgramId { get; set; }

    [JsonPropertyName("resource")]
    public ProgramResourceModel? Resource { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }
}
