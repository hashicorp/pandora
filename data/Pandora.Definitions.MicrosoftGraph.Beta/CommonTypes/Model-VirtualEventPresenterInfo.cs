// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class VirtualEventPresenterInfoModel
{
    [JsonPropertyName("identity")]
    public IdentitySetModel? Identity { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("presenterDetails")]
    public VirtualEventPresenterDetailsModel? PresenterDetails { get; set; }

    [JsonPropertyName("role")]
    public VirtualEventPresenterInfoRoleConstant? Role { get; set; }

    [JsonPropertyName("upn")]
    public string? Upn { get; set; }
}
