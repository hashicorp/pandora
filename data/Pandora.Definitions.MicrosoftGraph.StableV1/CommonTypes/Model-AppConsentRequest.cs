// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class AppConsentRequestModel
{
    [JsonPropertyName("appDisplayName")]
    public string? AppDisplayName { get; set; }

    [JsonPropertyName("appId")]
    public string? AppId { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("pendingScopes")]
    public List<AppConsentRequestScopeModel>? PendingScopes { get; set; }

    [JsonPropertyName("userConsentRequests")]
    public List<UserConsentRequestModel>? UserConsentRequests { get; set; }
}
