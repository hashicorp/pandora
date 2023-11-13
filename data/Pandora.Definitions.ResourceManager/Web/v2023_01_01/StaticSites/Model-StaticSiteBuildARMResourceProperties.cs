using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Web.v2023_01_01.StaticSites;


internal class StaticSiteBuildARMResourcePropertiesModel
{
    [JsonPropertyName("buildId")]
    public string? BuildId { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("createdTimeUtc")]
    public DateTime? CreatedTimeUtc { get; set; }

    [JsonPropertyName("databaseConnections")]
    public List<DatabaseConnectionOverviewModel>? DatabaseConnections { get; set; }

    [JsonPropertyName("hostname")]
    public string? Hostname { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastUpdatedOn")]
    public DateTime? LastUpdatedOn { get; set; }

    [JsonPropertyName("linkedBackends")]
    public List<StaticSiteLinkedBackendModel>? LinkedBackends { get; set; }

    [JsonPropertyName("pullRequestTitle")]
    public string? PullRequestTitle { get; set; }

    [JsonPropertyName("sourceBranch")]
    public string? SourceBranch { get; set; }

    [JsonPropertyName("status")]
    public BuildStatusConstant? Status { get; set; }

    [JsonPropertyName("userProvidedFunctionApps")]
    public List<StaticSiteUserProvidedFunctionAppModel>? UserProvidedFunctionApps { get; set; }
}
