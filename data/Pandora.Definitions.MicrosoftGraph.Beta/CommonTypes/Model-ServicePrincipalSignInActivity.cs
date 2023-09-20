// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class ServicePrincipalSignInActivityModel
{
    [JsonPropertyName("appId")]
    public string? AppId { get; set; }

    [JsonPropertyName("applicationAuthenticationClientSignInActivity")]
    public SignInActivityModel? ApplicationAuthenticationClientSignInActivity { get; set; }

    [JsonPropertyName("applicationAuthenticationResourceSignInActivity")]
    public SignInActivityModel? ApplicationAuthenticationResourceSignInActivity { get; set; }

    [JsonPropertyName("delegatedClientSignInActivity")]
    public SignInActivityModel? DelegatedClientSignInActivity { get; set; }

    [JsonPropertyName("delegatedResourceSignInActivity")]
    public SignInActivityModel? DelegatedResourceSignInActivity { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("lastSignInActivity")]
    public SignInActivityModel? LastSignInActivity { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }
}
