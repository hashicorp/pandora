using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2021_08_01.ExpressRoutePorts;


internal class ExpressRouteLinkPropertiesFormatModel
{
    [JsonPropertyName("adminState")]
    public ExpressRouteLinkAdminStateConstant? AdminState { get; set; }

    [JsonPropertyName("connectorType")]
    public ExpressRouteLinkConnectorTypeConstant? ConnectorType { get; set; }

    [JsonPropertyName("interfaceName")]
    public string? InterfaceName { get; set; }

    [JsonPropertyName("macSecConfig")]
    public ExpressRouteLinkMacSecConfigModel? MacSecConfig { get; set; }

    [JsonPropertyName("patchPanelId")]
    public string? PatchPanelId { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("rackId")]
    public string? RackId { get; set; }

    [JsonPropertyName("routerName")]
    public string? RouterName { get; set; }
}
