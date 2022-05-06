using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.AnalysisServices.v2017_08_01.Servers;


internal class AnalysisServicesServerPropertiesModel
{
    [JsonPropertyName("asAdministrators")]
    public ServerAdministratorsModel? AsAdministrators { get; set; }

    [JsonPropertyName("backupBlobContainerUri")]
    public string? BackupBlobContainerUri { get; set; }

    [JsonPropertyName("gatewayDetails")]
    public GatewayDetailsModel? GatewayDetails { get; set; }

    [JsonPropertyName("ipV4FirewallSettings")]
    public IPv4FirewallSettingsModel? IpV4FirewallSettings { get; set; }

    [JsonPropertyName("managedMode")]
    public ManagedModeConstant? ManagedMode { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("querypoolConnectionMode")]
    public ConnectionModeConstant? QuerypoolConnectionMode { get; set; }

    [JsonPropertyName("serverFullName")]
    public string? ServerFullName { get; set; }

    [JsonPropertyName("serverMonitorMode")]
    public ServerMonitorModeConstant? ServerMonitorMode { get; set; }

    [JsonPropertyName("sku")]
    public ResourceSkuModel? Sku { get; set; }

    [JsonPropertyName("state")]
    public StateConstant? State { get; set; }
}
