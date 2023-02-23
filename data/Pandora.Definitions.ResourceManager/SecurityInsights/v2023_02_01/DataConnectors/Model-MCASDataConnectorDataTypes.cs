using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2023_02_01.DataConnectors;


internal class MCASDataConnectorDataTypesModel
{
    [JsonPropertyName("alerts")]
    public DataConnectorDataTypeCommonModel? Alerts { get; set; }

    [JsonPropertyName("discoveryLogs")]
    public DataConnectorDataTypeCommonModel? DiscoveryLogs { get; set; }
}
