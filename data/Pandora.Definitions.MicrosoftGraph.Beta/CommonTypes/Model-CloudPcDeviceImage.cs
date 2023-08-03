// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class CloudPcDeviceImageModel
{
    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("expirationDate")]
    public DateTime? ExpirationDate { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("lastModifiedDateTime")]
    public DateTime? LastModifiedDateTime { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("operatingSystem")]
    public string? OperatingSystem { get; set; }

    [JsonPropertyName("osBuildNumber")]
    public string? OsBuildNumber { get; set; }

    [JsonPropertyName("osStatus")]
    public CloudPcDeviceImageOsStatusConstant? OsStatus { get; set; }

    [JsonPropertyName("sourceImageResourceId")]
    public string? SourceImageResourceId { get; set; }

    [JsonPropertyName("status")]
    public CloudPcDeviceImageStatusConstant? Status { get; set; }

    [JsonPropertyName("statusDetails")]
    public CloudPcDeviceImageStatusDetailsConstant? StatusDetails { get; set; }

    [JsonPropertyName("version")]
    public string? Version { get; set; }
}
