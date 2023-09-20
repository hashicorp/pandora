// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class DefaultUserRolePermissionsModel
{
    [JsonPropertyName("allowedToCreateApps")]
    public bool? AllowedToCreateApps { get; set; }

    [JsonPropertyName("allowedToCreateSecurityGroups")]
    public bool? AllowedToCreateSecurityGroups { get; set; }

    [JsonPropertyName("allowedToCreateTenants")]
    public bool? AllowedToCreateTenants { get; set; }

    [JsonPropertyName("allowedToReadBitlockerKeysForOwnedDevice")]
    public bool? AllowedToReadBitlockerKeysForOwnedDevice { get; set; }

    [JsonPropertyName("allowedToReadOtherUsers")]
    public bool? AllowedToReadOtherUsers { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }
}
