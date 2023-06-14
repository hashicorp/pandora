using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.PaloAltoNetworks.v2022_08_29.Firewalls;


internal class LogDestinationModel
{
    [JsonPropertyName("eventHubConfigurations")]
    public EventHubModel? EventHubConfigurations { get; set; }

    [JsonPropertyName("monitorConfigurations")]
    public MonitorLogModel? MonitorConfigurations { get; set; }

    [JsonPropertyName("storageConfigurations")]
    public StorageAccountModel? StorageConfigurations { get; set; }
}
