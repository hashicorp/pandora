// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class AdminWindowsUpdatesModel
{
    [JsonPropertyName("catalog")]
    public CatalogModel? Catalog { get; set; }

    [JsonPropertyName("deploymentAudiences")]
    public List<DeploymentAudienceModel>? DeploymentAudiences { get; set; }

    [JsonPropertyName("deployments")]
    public List<DeploymentModel>? Deployments { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("resourceConnections")]
    public List<ResourceConnectionModel>? ResourceConnections { get; set; }

    [JsonPropertyName("updatableAssets")]
    public List<UpdatableAssetModel>? UpdatableAssets { get; set; }

    [JsonPropertyName("updatePolicies")]
    public List<UpdatePolicyModel>? UpdatePolicies { get; set; }
}
