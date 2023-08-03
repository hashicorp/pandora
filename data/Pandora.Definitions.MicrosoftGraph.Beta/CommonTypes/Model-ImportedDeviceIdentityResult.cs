// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class ImportedDeviceIdentityResultModel
{
    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("enrollmentState")]
    public EnrollmentStateConstant? EnrollmentState { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("importedDeviceIdentifier")]
    public string? ImportedDeviceIdentifier { get; set; }

    [JsonPropertyName("importedDeviceIdentityType")]
    public ImportedDeviceIdentityTypeConstant? ImportedDeviceIdentityType { get; set; }

    [JsonPropertyName("lastContactedDateTime")]
    public DateTime? LastContactedDateTime { get; set; }

    [JsonPropertyName("lastModifiedDateTime")]
    public DateTime? LastModifiedDateTime { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("platform")]
    public PlatformConstant? Platform { get; set; }

    [JsonPropertyName("status")]
    public bool? Status { get; set; }
}
