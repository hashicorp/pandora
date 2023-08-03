// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class ServiceNowConnectionModel
{
    [JsonPropertyName("authenticationMethod")]
    public ServiceNowAuthenticationMethodModel? AuthenticationMethod { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("incidentApiUrl")]
    public string? IncidentApiUrl { get; set; }

    [JsonPropertyName("instanceUrl")]
    public string? InstanceUrl { get; set; }

    [JsonPropertyName("lastModifiedDateTime")]
    public DateTime? LastModifiedDateTime { get; set; }

    [JsonPropertyName("lastQueriedDateTime")]
    public DateTime? LastQueriedDateTime { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("serviceNowConnectionStatus")]
    public ServiceNowConnectionStatusConstant? ServiceNowConnectionStatus { get; set; }
}
