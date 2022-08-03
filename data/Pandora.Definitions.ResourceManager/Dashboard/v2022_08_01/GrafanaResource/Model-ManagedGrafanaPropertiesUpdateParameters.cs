using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Dashboard.v2022_08_01.GrafanaResource;


internal class ManagedGrafanaPropertiesUpdateParametersModel
{
    [JsonPropertyName("apiKey")]
    public ApiKeyConstant? ApiKey { get; set; }

    [JsonPropertyName("deterministicOutboundIP")]
    public DeterministicOutboundIPConstant? DeterministicOutboundIP { get; set; }

    [JsonPropertyName("grafanaIntegrations")]
    public GrafanaIntegrationsModel? GrafanaIntegrations { get; set; }

    [JsonPropertyName("publicNetworkAccess")]
    public PublicNetworkAccessConstant? PublicNetworkAccess { get; set; }

    [JsonPropertyName("zoneRedundancy")]
    public ZoneRedundancyConstant? ZoneRedundancy { get; set; }
}
