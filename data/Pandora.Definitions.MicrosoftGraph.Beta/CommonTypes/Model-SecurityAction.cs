// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class SecurityActionModel
{
    [JsonPropertyName("actionReason")]
    public string? ActionReason { get; set; }

    [JsonPropertyName("appId")]
    public string? AppId { get; set; }

    [JsonPropertyName("azureTenantId")]
    public string? AzureTenantId { get; set; }

    [JsonPropertyName("clientContext")]
    public string? ClientContext { get; set; }

    [JsonPropertyName("completedDateTime")]
    public DateTime? CompletedDateTime { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("errorInfo")]
    public ResultInfoModel? ErrorInfo { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("lastActionDateTime")]
    public DateTime? LastActionDateTime { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("parameters")]
    public List<KeyValuePairModel>? Parameters { get; set; }

    [JsonPropertyName("states")]
    public List<SecurityActionStateModel>? States { get; set; }

    [JsonPropertyName("status")]
    public SecurityActionStatusConstant? Status { get; set; }

    [JsonPropertyName("user")]
    public string? User { get; set; }

    [JsonPropertyName("vendorInformation")]
    public SecurityVendorInformationModel? VendorInformation { get; set; }
}
