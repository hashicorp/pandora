using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.StorageSync.v2020_03_01.CloudEndpointResource;


internal class CloudEndpointPropertiesModel
{
    [JsonPropertyName("azureFileShareName")]
    public string? AzureFileShareName { get; set; }

    [JsonPropertyName("backupEnabled")]
    public string? BackupEnabled { get; set; }

    [JsonPropertyName("friendlyName")]
    public string? FriendlyName { get; set; }

    [JsonPropertyName("lastOperationName")]
    public string? LastOperationName { get; set; }

    [JsonPropertyName("lastWorkflowId")]
    public string? LastWorkflowId { get; set; }

    [JsonPropertyName("partnershipId")]
    public string? PartnershipId { get; set; }

    [JsonPropertyName("provisioningState")]
    public string? ProvisioningState { get; set; }

    [JsonPropertyName("storageAccountResourceId")]
    public string? StorageAccountResourceId { get; set; }

    [JsonPropertyName("storageAccountTenantId")]
    public string? StorageAccountTenantId { get; set; }
}
