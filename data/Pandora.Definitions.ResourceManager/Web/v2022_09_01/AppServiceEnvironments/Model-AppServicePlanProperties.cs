using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Web.v2022_09_01.AppServiceEnvironments;


internal class AppServicePlanPropertiesModel
{
    [JsonPropertyName("elasticScaleEnabled")]
    public bool? ElasticScaleEnabled { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("freeOfferExpirationTime")]
    public DateTime? FreeOfferExpirationTime { get; set; }

    [JsonPropertyName("geoRegion")]
    public string? GeoRegion { get; set; }

    [JsonPropertyName("hostingEnvironmentProfile")]
    public HostingEnvironmentProfileModel? HostingEnvironmentProfile { get; set; }

    [JsonPropertyName("hyperV")]
    public bool? HyperV { get; set; }

    [JsonPropertyName("isSpot")]
    public bool? IsSpot { get; set; }

    [JsonPropertyName("isXenon")]
    public bool? IsXenon { get; set; }

    [JsonPropertyName("kubeEnvironmentProfile")]
    public KubeEnvironmentProfileModel? KubeEnvironmentProfile { get; set; }

    [JsonPropertyName("maximumElasticWorkerCount")]
    public int? MaximumElasticWorkerCount { get; set; }

    [JsonPropertyName("maximumNumberOfWorkers")]
    public int? MaximumNumberOfWorkers { get; set; }

    [JsonPropertyName("numberOfSites")]
    public int? NumberOfSites { get; set; }

    [JsonPropertyName("numberOfWorkers")]
    public int? NumberOfWorkers { get; set; }

    [JsonPropertyName("perSiteScaling")]
    public bool? PerSiteScaling { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("reserved")]
    public bool? Reserved { get; set; }

    [JsonPropertyName("resourceGroup")]
    public string? ResourceGroup { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("spotExpirationTime")]
    public DateTime? SpotExpirationTime { get; set; }

    [JsonPropertyName("status")]
    public StatusOptionsConstant? Status { get; set; }

    [JsonPropertyName("subscription")]
    public string? Subscription { get; set; }

    [JsonPropertyName("targetWorkerCount")]
    public int? TargetWorkerCount { get; set; }

    [JsonPropertyName("targetWorkerSizeId")]
    public int? TargetWorkerSizeId { get; set; }

    [JsonPropertyName("workerTierName")]
    public string? WorkerTierName { get; set; }

    [JsonPropertyName("zoneRedundant")]
    public bool? ZoneRedundant { get; set; }
}
