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
    public List<CloudPCAuditEventModel>? AuditEvents { get; set; }

    [JsonPropertyName("bulkActions")]
    public List<CloudPCBulkActionModel>? BulkActions { get; set; }

    [JsonPropertyName("cloudPCs")]
    public List<CloudPCModel>? CloudPCs { get; set; }

    [JsonPropertyName("crossCloudGovernmentOrganizationMapping")]
    public CloudPCCrossCloudGovernmentOrganizationMappingModel? CrossCloudGovernmentOrganizationMapping { get; set; }

    [JsonPropertyName("deviceImages")]
    public List<CloudPCDeviceImageModel>? DeviceImages { get; set; }

    [JsonPropertyName("externalPartnerSettings")]
    public List<CloudPCExternalPartnerSettingModel>? ExternalPartnerSettings { get; set; }

    [JsonPropertyName("frontLineServicePlans")]
    public List<CloudPCFrontLineServicePlanModel>? FrontLineServicePlans { get; set; }

    [JsonPropertyName("galleryImages")]
    public List<CloudPCGalleryImageModel>? GalleryImages { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("onPremisesConnections")]
    public List<CloudPCOnPremisesConnectionModel>? OnPremisesConnections { get; set; }

    [JsonPropertyName("organizationSettings")]
    public CloudPCOrganizationSettingsModel? OrganizationSettings { get; set; }

    [JsonPropertyName("provisioningPolicies")]
    public List<CloudPCProvisioningPolicyModel>? ProvisioningPolicies { get; set; }

    [JsonPropertyName("reports")]
    public CloudPCReportsModel? Reports { get; set; }

    [JsonPropertyName("servicePlans")]
    public List<CloudPCServicePlanModel>? ServicePlans { get; set; }

    [JsonPropertyName("sharedUseServicePlans")]
    public List<CloudPCSharedUseServicePlanModel>? SharedUseServicePlans { get; set; }

    [JsonPropertyName("snapshots")]
    public List<CloudPCSnapshotModel>? Snapshots { get; set; }

    [JsonPropertyName("supportedRegions")]
    public List<CloudPCSupportedRegionModel>? SupportedRegions { get; set; }

    [JsonPropertyName("userSettings")]
    public List<CloudPCUserSettingModel>? UserSettings { get; set; }
}
