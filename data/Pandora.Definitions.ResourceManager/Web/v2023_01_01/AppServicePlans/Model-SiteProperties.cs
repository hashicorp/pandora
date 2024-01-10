using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Web.v2023_01_01.AppServicePlans;


internal class SitePropertiesModel
{
    [JsonPropertyName("availabilityState")]
    public SiteAvailabilityStateConstant? AvailabilityState { get; set; }

    [JsonPropertyName("clientAffinityEnabled")]
    public bool? ClientAffinityEnabled { get; set; }

    [JsonPropertyName("clientCertEnabled")]
    public bool? ClientCertEnabled { get; set; }

    [JsonPropertyName("clientCertExclusionPaths")]
    public string? ClientCertExclusionPaths { get; set; }

    [JsonPropertyName("clientCertMode")]
    public ClientCertModeConstant? ClientCertMode { get; set; }

    [JsonPropertyName("cloningInfo")]
    public CloningInfoModel? CloningInfo { get; set; }

    [JsonPropertyName("containerSize")]
    public int? ContainerSize { get; set; }

    [JsonPropertyName("customDomainVerificationId")]
    public string? CustomDomainVerificationId { get; set; }

    [JsonPropertyName("dailyMemoryTimeQuota")]
    public int? DailyMemoryTimeQuota { get; set; }

    [JsonPropertyName("daprConfig")]
    public DaprConfigModel? DaprConfig { get; set; }

    [JsonPropertyName("defaultHostName")]
    public string? DefaultHostName { get; set; }

    [JsonPropertyName("enabled")]
    public bool? Enabled { get; set; }

    [JsonPropertyName("enabledHostNames")]
    public List<string>? EnabledHostNames { get; set; }

    [JsonPropertyName("httpsOnly")]
    public bool? HTTPSOnly { get; set; }

    [JsonPropertyName("hostNameSslStates")]
    public List<HostNameSslStateModel>? HostNameSslStates { get; set; }

    [JsonPropertyName("hostNames")]
    public List<string>? HostNames { get; set; }

    [JsonPropertyName("hostNamesDisabled")]
    public bool? HostNamesDisabled { get; set; }

    [JsonPropertyName("hostingEnvironmentProfile")]
    public HostingEnvironmentProfileModel? HostingEnvironmentProfile { get; set; }

    [JsonPropertyName("hyperV")]
    public bool? HyperV { get; set; }

    [JsonPropertyName("inProgressOperationId")]
    public string? InProgressOperationId { get; set; }

    [JsonPropertyName("isDefaultContainer")]
    public bool? IsDefaultContainer { get; set; }

    [JsonPropertyName("isXenon")]
    public bool? IsXenon { get; set; }

    [JsonPropertyName("keyVaultReferenceIdentity")]
    public string? KeyVaultReferenceIdentity { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastModifiedTimeUtc")]
    public DateTime? LastModifiedTimeUtc { get; set; }

    [JsonPropertyName("managedEnvironmentId")]
    public string? ManagedEnvironmentId { get; set; }

    [JsonPropertyName("maxNumberOfWorkers")]
    public int? MaxNumberOfWorkers { get; set; }

    [JsonPropertyName("outboundIpAddresses")]
    public string? OutboundIPAddresses { get; set; }

    [JsonPropertyName("possibleOutboundIpAddresses")]
    public string? PossibleOutboundIPAddresses { get; set; }

    [JsonPropertyName("publicNetworkAccess")]
    public string? PublicNetworkAccess { get; set; }

    [JsonPropertyName("redundancyMode")]
    public RedundancyModeConstant? RedundancyMode { get; set; }

    [JsonPropertyName("repositorySiteName")]
    public string? RepositorySiteName { get; set; }

    [JsonPropertyName("reserved")]
    public bool? Reserved { get; set; }

    [JsonPropertyName("resourceConfig")]
    public ResourceConfigModel? ResourceConfig { get; set; }

    [JsonPropertyName("resourceGroup")]
    public string? ResourceGroup { get; set; }

    [JsonPropertyName("scmSiteAlsoStopped")]
    public bool? ScmSiteAlsoStopped { get; set; }

    [JsonPropertyName("serverFarmId")]
    public string? ServerFarmId { get; set; }

    [JsonPropertyName("siteConfig")]
    public SiteConfigModel? SiteConfig { get; set; }

    [JsonPropertyName("slotSwapStatus")]
    public SlotSwapStatusModel? SlotSwapStatus { get; set; }

    [JsonPropertyName("state")]
    public string? State { get; set; }

    [JsonPropertyName("storageAccountRequired")]
    public bool? StorageAccountRequired { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("suspendedTill")]
    public DateTime? SuspendedTill { get; set; }

    [JsonPropertyName("targetSwapSlot")]
    public string? TargetSwapSlot { get; set; }

    [JsonPropertyName("trafficManagerHostNames")]
    public List<string>? TrafficManagerHostNames { get; set; }

    [JsonPropertyName("usageState")]
    public UsageStateConstant? UsageState { get; set; }

    [JsonPropertyName("virtualNetworkSubnetId")]
    public string? VirtualNetworkSubnetId { get; set; }

    [JsonPropertyName("vnetContentShareEnabled")]
    public bool? VnetContentShareEnabled { get; set; }

    [JsonPropertyName("vnetImagePullEnabled")]
    public bool? VnetImagePullEnabled { get; set; }

    [JsonPropertyName("vnetRouteAllEnabled")]
    public bool? VnetRouteAllEnabled { get; set; }

    [JsonPropertyName("workloadProfileName")]
    public string? WorkloadProfileName { get; set; }
}
