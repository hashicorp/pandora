// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class AwsAuthorizationSystemModel
{
    [JsonPropertyName("actions")]
    public List<AwsAuthorizationSystemTypeActionModel>? Actions { get; set; }

    [JsonPropertyName("associatedIdentities")]
    public AwsAssociatedIdentitiesModel? AssociatedIdentities { get; set; }

    [JsonPropertyName("authorizationSystemId")]
    public string? AuthorizationSystemId { get; set; }

    [JsonPropertyName("authorizationSystemName")]
    public string? AuthorizationSystemName { get; set; }

    [JsonPropertyName("authorizationSystemType")]
    public string? AuthorizationSystemType { get; set; }

    [JsonPropertyName("dataCollectionInfo")]
    public DataCollectionInfoModel? DataCollectionInfo { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("policies")]
    public List<AwsPolicyModel>? Policies { get; set; }

    [JsonPropertyName("resources")]
    public List<AwsAuthorizationSystemResourceModel>? Resources { get; set; }

    [JsonPropertyName("services")]
    public List<AuthorizationSystemTypeServiceModel>? Services { get; set; }
}
