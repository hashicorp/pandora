// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class RoleSuccessStatisticsModel
{
    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("permanentFail")]
    public int? PermanentFail { get; set; }

    [JsonPropertyName("permanentSuccess")]
    public int? PermanentSuccess { get; set; }

    [JsonPropertyName("removeFail")]
    public int? RemoveFail { get; set; }

    [JsonPropertyName("removeSuccess")]
    public int? RemoveSuccess { get; set; }

    [JsonPropertyName("roleId")]
    public string? RoleId { get; set; }

    [JsonPropertyName("roleName")]
    public string? RoleName { get; set; }

    [JsonPropertyName("temporaryFail")]
    public int? TemporaryFail { get; set; }

    [JsonPropertyName("temporarySuccess")]
    public int? TemporarySuccess { get; set; }

    [JsonPropertyName("unknownFail")]
    public int? UnknownFail { get; set; }
}
