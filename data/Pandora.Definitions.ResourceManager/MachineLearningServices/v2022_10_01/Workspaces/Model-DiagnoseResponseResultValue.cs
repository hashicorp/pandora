using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2022_10_01.Workspaces;


internal class DiagnoseResponseResultValueModel
{
    [JsonPropertyName("applicationInsightsResults")]
    public List<DiagnoseResultModel>? ApplicationInsightsResults { get; set; }

    [JsonPropertyName("containerRegistryResults")]
    public List<DiagnoseResultModel>? ContainerRegistryResults { get; set; }

    [JsonPropertyName("dnsResolutionResults")]
    public List<DiagnoseResultModel>? DnsResolutionResults { get; set; }

    [JsonPropertyName("keyVaultResults")]
    public List<DiagnoseResultModel>? KeyVaultResults { get; set; }

    [JsonPropertyName("networkSecurityRuleResults")]
    public List<DiagnoseResultModel>? NetworkSecurityRuleResults { get; set; }

    [JsonPropertyName("otherResults")]
    public List<DiagnoseResultModel>? OtherResults { get; set; }

    [JsonPropertyName("resourceLockResults")]
    public List<DiagnoseResultModel>? ResourceLockResults { get; set; }

    [JsonPropertyName("storageAccountResults")]
    public List<DiagnoseResultModel>? StorageAccountResults { get; set; }

    [JsonPropertyName("userDefinedRouteResults")]
    public List<DiagnoseResultModel>? UserDefinedRouteResults { get; set; }
}
