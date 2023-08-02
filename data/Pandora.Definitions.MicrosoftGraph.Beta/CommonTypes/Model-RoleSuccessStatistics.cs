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
    public long? PermanentFail { get; set; }

    [JsonPropertyName("permanentSuccess")]
    public long? PermanentSuccess { get; set; }

    [JsonPropertyName("removeFail")]
    public long? RemoveFail { get; set; }

    [JsonPropertyName("removeSuccess")]
    public long? RemoveSuccess { get; set; }

    [JsonPropertyName("roleId")]
    public string? RoleId { get; set; }

    [JsonPropertyName("roleName")]
    public string? RoleName { get; set; }

    [JsonPropertyName("temporaryFail")]
    public long? TemporaryFail { get; set; }

    [JsonPropertyName("temporarySuccess")]
    public long? TemporarySuccess { get; set; }

    [JsonPropertyName("unknownFail")]
    public long? UnknownFail { get; set; }
}
