using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ContainerService.v2023_02_02_preview.ManagedClusters;


internal class ContainerServiceNetworkProfileKubeProxyConfigIPvsConfigModel
{
    [JsonPropertyName("scheduler")]
    public IPvsSchedulerConstant? Scheduler { get; set; }

    [JsonPropertyName("tcpFinTimeoutSeconds")]
    public int? TcpFinTimeoutSeconds { get; set; }

    [JsonPropertyName("tcpTimeoutSeconds")]
    public int? TcpTimeoutSeconds { get; set; }

    [JsonPropertyName("udpTimeoutSeconds")]
    public int? UdpTimeoutSeconds { get; set; }
}
