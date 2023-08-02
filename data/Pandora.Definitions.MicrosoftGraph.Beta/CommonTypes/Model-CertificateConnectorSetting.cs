// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class CertificateConnectorSettingModel
{
    [JsonPropertyName("certExpiryTime")]
    public DateTime? CertExpiryTime { get; set; }

    [JsonPropertyName("connectorVersion")]
    public string? ConnectorVersion { get; set; }

    [JsonPropertyName("enrollmentError")]
    public string? EnrollmentError { get; set; }

    [JsonPropertyName("lastConnectorConnectionTime")]
    public DateTime? LastConnectorConnectionTime { get; set; }

    [JsonPropertyName("lastUploadVersion")]
    public long? LastUploadVersion { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("status")]
    public int? Status { get; set; }
}
