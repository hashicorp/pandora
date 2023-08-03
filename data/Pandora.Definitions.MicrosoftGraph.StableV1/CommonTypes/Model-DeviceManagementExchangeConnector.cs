// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class DeviceManagementExchangeConnectorModel
{
    [JsonPropertyName("connectorServerName")]
    public string? ConnectorServerName { get; set; }

    [JsonPropertyName("exchangeAlias")]
    public string? ExchangeAlias { get; set; }

    [JsonPropertyName("exchangeConnectorType")]
    public DeviceManagementExchangeConnectorTypeConstant? ExchangeConnectorType { get; set; }

    [JsonPropertyName("exchangeOrganization")]
    public string? ExchangeOrganization { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("lastSyncDateTime")]
    public DateTime? LastSyncDateTime { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("primarySmtpAddress")]
    public string? PrimarySmtpAddress { get; set; }

    [JsonPropertyName("serverName")]
    public string? ServerName { get; set; }

    [JsonPropertyName("status")]
    public DeviceManagementExchangeConnectorStatusConstant? Status { get; set; }

    [JsonPropertyName("version")]
    public string? Version { get; set; }
}
