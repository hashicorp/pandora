// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class VirtualEndpointModel
{
    [JsonPropertyName("auditEvents")]
    public List<CloudPcAuditEventModel>? AuditEvents { get; set; }

    [JsonPropertyName("cloudPCs")]
    public List<CloudPCModel>? CloudPCs { get; set; }

    [JsonPropertyName("crossCloudGovernmentOrganizationMapping")]
    public CloudPcCrossCloudGovernmentOrganizationMappingModel? CrossCloudGovernmentOrganizationMapping { get; set; }

    [JsonPropertyName("deviceImages")]
    public List<CloudPcDeviceImageModel>? DeviceImages { get; set; }

    [JsonPropertyName("externalPartnerSettings")]
    public List<CloudPcExternalPartnerSettingModel>? ExternalPartnerSettings { get; set; }

    [JsonPropertyName("galleryImages")]
    public List<CloudPcGalleryImageModel>? GalleryImages { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("onPremisesConnections")]
    public List<CloudPcOnPremisesConnectionModel>? OnPremisesConnections { get; set; }

    [JsonPropertyName("organizationSettings")]
    public CloudPcOrganizationSettingsModel? OrganizationSettings { get; set; }

    [JsonPropertyName("provisioningPolicies")]
    public List<CloudPcProvisioningPolicyModel>? ProvisioningPolicies { get; set; }

    [JsonPropertyName("reports")]
    public CloudPcReportsModel? Reports { get; set; }

    [JsonPropertyName("servicePlans")]
    public List<CloudPcServicePlanModel>? ServicePlans { get; set; }

    [JsonPropertyName("sharedUseServicePlans")]
    public List<CloudPcSharedUseServicePlanModel>? SharedUseServicePlans { get; set; }

    [JsonPropertyName("snapshots")]
    public List<CloudPcSnapshotModel>? Snapshots { get; set; }

    [JsonPropertyName("supportedRegions")]
    public List<CloudPcSupportedRegionModel>? SupportedRegions { get; set; }

    [JsonPropertyName("userSettings")]
    public List<CloudPcUserSettingModel>? UserSettings { get; set; }
}
