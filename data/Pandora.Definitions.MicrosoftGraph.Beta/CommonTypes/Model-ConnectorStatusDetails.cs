// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class ConnectorStatusDetailsModel
{
    [JsonPropertyName("connectorInstanceId")]
    public string? ConnectorInstanceId { get; set; }

    [JsonPropertyName("connectorName")]
    public ConnectorStatusDetailsConnectorNameConstant? ConnectorName { get; set; }

    [JsonPropertyName("eventDateTime")]
    public DateTime? EventDateTime { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("status")]
    public ConnectorStatusDetailsStatusConstant? Status { get; set; }
}
