// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class AccessPackageResourceRequestModel
{
    [JsonPropertyName("accessPackageResource")]
    public AccessPackageResourceModel? AccessPackageResource { get; set; }

    [JsonPropertyName("catalogId")]
    public string? CatalogId { get; set; }

    [JsonPropertyName("executeImmediately")]
    public bool? ExecuteImmediately { get; set; }

    [JsonPropertyName("expirationDateTime")]
    public DateTime? ExpirationDateTime { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("isValidationOnly")]
    public bool? IsValidationOnly { get; set; }

    [JsonPropertyName("justification")]
    public string? Justification { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("requestState")]
    public string? RequestState { get; set; }

    [JsonPropertyName("requestStatus")]
    public string? RequestStatus { get; set; }

    [JsonPropertyName("requestType")]
    public string? RequestType { get; set; }

    [JsonPropertyName("requestor")]
    public AccessPackageSubjectModel? Requestor { get; set; }
}
