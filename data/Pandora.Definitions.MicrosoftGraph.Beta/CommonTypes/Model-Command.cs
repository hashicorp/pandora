// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class CommandModel
{
    [JsonPropertyName("appServiceName")]
    public string? AppServiceName { get; set; }

    [JsonPropertyName("error")]
    public string? Error { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("packageFamilyName")]
    public string? PackageFamilyName { get; set; }

    [JsonPropertyName("payload")]
    public PayloadRequestModel? Payload { get; set; }

    [JsonPropertyName("permissionTicket")]
    public string? PermissionTicket { get; set; }

    [JsonPropertyName("postBackUri")]
    public string? PostBackUri { get; set; }

    [JsonPropertyName("responsepayload")]
    public PayloadResponseModel? Responsepayload { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("type")]
    public string? Type { get; set; }
}
