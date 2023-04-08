using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ManagedApplications.v2021_07_01.Applications;


internal class ApplicationPropertiesModel
{
    [JsonPropertyName("applicationDefinitionId")]
    public string? ApplicationDefinitionId { get; set; }

    [JsonPropertyName("artifacts")]
    public List<ApplicationArtifactModel>? Artifacts { get; set; }

    [JsonPropertyName("authorizations")]
    public List<ApplicationAuthorizationModel>? Authorizations { get; set; }

    [JsonPropertyName("billingDetails")]
    public ApplicationBillingDetailsDefinitionModel? BillingDetails { get; set; }

    [JsonPropertyName("createdBy")]
    public ApplicationClientDetailsModel? CreatedBy { get; set; }

    [JsonPropertyName("customerSupport")]
    public ApplicationPackageContactModel? CustomerSupport { get; set; }

    [JsonPropertyName("jitAccessPolicy")]
    public ApplicationJitAccessPolicyModel? JitAccessPolicy { get; set; }

    [JsonPropertyName("managedResourceGroupId")]
    public string? ManagedResourceGroupId { get; set; }

    [JsonPropertyName("managementMode")]
    public ApplicationManagementModeConstant? ManagementMode { get; set; }

    [JsonPropertyName("outputs")]
    public object? Outputs { get; set; }

    [JsonPropertyName("parameters")]
    public object? Parameters { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("publisherTenantId")]
    public string? PublisherTenantId { get; set; }

    [JsonPropertyName("supportUrls")]
    public ApplicationPackageSupportUrlsModel? SupportUrls { get; set; }

    [JsonPropertyName("updatedBy")]
    public ApplicationClientDetailsModel? UpdatedBy { get; set; }
}
