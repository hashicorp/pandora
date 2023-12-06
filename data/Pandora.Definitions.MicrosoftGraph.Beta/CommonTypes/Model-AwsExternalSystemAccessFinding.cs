// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class AwsExternalSystemAccessFindingModel
{
    [JsonPropertyName("accessMethods")]
    public AwsExternalSystemAccessFindingAccessMethodsConstant? AccessMethods { get; set; }

    [JsonPropertyName("affectedSystem")]
    public AuthorizationSystemModel? AffectedSystem { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("systemWithAccess")]
    public AuthorizationSystemInfoModel? SystemWithAccess { get; set; }

    [JsonPropertyName("trustedIdentityCount")]
    public int? TrustedIdentityCount { get; set; }

    [JsonPropertyName("trustsAllIdentities")]
    public bool? TrustsAllIdentities { get; set; }
}
