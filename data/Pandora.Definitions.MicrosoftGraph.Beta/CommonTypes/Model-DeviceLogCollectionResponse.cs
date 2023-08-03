// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class DeviceLogCollectionResponseModel
{
    [JsonPropertyName("enrolledByUser")]
    public string? EnrolledByUser { get; set; }

    [JsonPropertyName("errorCode")]
    public long? ErrorCode { get; set; }

    [JsonPropertyName("expirationDateTimeUTC")]
    public DateTime? ExpirationDateTimeUTC { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("initiatedByUserPrincipalName")]
    public string? InitiatedByUserPrincipalName { get; set; }

    [JsonPropertyName("managedDeviceId")]
    public string? ManagedDeviceId { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("receivedDateTimeUTC")]
    public DateTime? ReceivedDateTimeUTC { get; set; }

    [JsonPropertyName("requestedDateTimeUTC")]
    public DateTime? RequestedDateTimeUTC { get; set; }

    [JsonPropertyName("status")]
    public AppLogUploadStateConstant? Status { get; set; }
}
