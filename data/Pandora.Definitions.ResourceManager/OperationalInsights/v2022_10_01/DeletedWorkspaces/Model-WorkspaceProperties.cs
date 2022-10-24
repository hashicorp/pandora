using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.OperationalInsights.v2022_10_01.DeletedWorkspaces;


internal class WorkspacePropertiesModel
{
    [JsonPropertyName("createdDate")]
    public string? CreatedDate { get; set; }

    [JsonPropertyName("customerId")]
    public string? CustomerId { get; set; }

    [JsonPropertyName("defaultDataCollectionRuleResourceId")]
    public string? DefaultDataCollectionRuleResourceId { get; set; }

    [JsonPropertyName("features")]
    public WorkspaceFeaturesModel? Features { get; set; }

    [JsonPropertyName("forceCmkForQuery")]
    public bool? ForceCmkForQuery { get; set; }

    [JsonPropertyName("modifiedDate")]
    public string? ModifiedDate { get; set; }

    [JsonPropertyName("privateLinkScopedResources")]
    public List<PrivateLinkScopedResourceModel>? PrivateLinkScopedResources { get; set; }

    [JsonPropertyName("provisioningState")]
    public WorkspaceEntityStatusConstant? ProvisioningState { get; set; }

    [JsonPropertyName("publicNetworkAccessForIngestion")]
    public PublicNetworkAccessTypeConstant? PublicNetworkAccessForIngestion { get; set; }

    [JsonPropertyName("publicNetworkAccessForQuery")]
    public PublicNetworkAccessTypeConstant? PublicNetworkAccessForQuery { get; set; }

    [JsonPropertyName("retentionInDays")]
    public int? RetentionInDays { get; set; }

    [JsonPropertyName("sku")]
    public WorkspaceSkuModel? Sku { get; set; }

    [JsonPropertyName("workspaceCapping")]
    public WorkspaceCappingModel? WorkspaceCapping { get; set; }
}
