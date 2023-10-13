// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class AwsPermissionsDefinitionModel
{
    [JsonPropertyName("actionInfo")]
    public AwsPermissionsDefinitionActionModel? ActionInfo { get; set; }

    [JsonPropertyName("authorizationSystemInfo")]
    public PermissionsDefinitionAuthorizationSystemModel? AuthorizationSystemInfo { get; set; }

    [JsonPropertyName("identityInfo")]
    public PermissionsDefinitionAuthorizationSystemIdentityModel? IdentityInfo { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }
}
