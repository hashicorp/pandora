// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class AwsAssociatedIdentitiesModel
{
    [JsonPropertyName("all")]
    public List<AwsIdentityModel>? All { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("roles")]
    public List<AwsRoleModel>? Roles { get; set; }

    [JsonPropertyName("users")]
    public List<AwsUserModel>? Users { get; set; }
}
