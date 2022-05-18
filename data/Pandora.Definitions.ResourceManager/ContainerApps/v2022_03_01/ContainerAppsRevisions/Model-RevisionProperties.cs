using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ContainerApps.v2022_03_01.ContainerAppsRevisions;


internal class RevisionPropertiesModel
{
    [JsonPropertyName("active")]
    public bool? Active { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("createdTime")]
    public DateTime? CreatedTime { get; set; }

    [JsonPropertyName("fqdn")]
    public string? Fqdn { get; set; }

    [JsonPropertyName("healthState")]
    public RevisionHealthStateConstant? HealthState { get; set; }

    [JsonPropertyName("provisioningError")]
    public string? ProvisioningError { get; set; }

    [JsonPropertyName("provisioningState")]
    public RevisionProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("replicas")]
    public int? Replicas { get; set; }

    [JsonPropertyName("template")]
    public TemplateModel? Template { get; set; }

    [JsonPropertyName("trafficWeight")]
    public int? TrafficWeight { get; set; }
}
