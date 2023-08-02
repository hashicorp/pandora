using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Web.v2022_09_01.StaticSites;


internal class StaticSiteModel
{
    [JsonPropertyName("allowConfigFileUpdates")]
    public bool? AllowConfigFileUpdates { get; set; }

    [JsonPropertyName("branch")]
    public string? Branch { get; set; }

    [JsonPropertyName("buildProperties")]
    public StaticSiteBuildPropertiesModel? BuildProperties { get; set; }

    [JsonPropertyName("contentDistributionEndpoint")]
    public string? ContentDistributionEndpoint { get; set; }

    [JsonPropertyName("customDomains")]
    public List<string>? CustomDomains { get; set; }

    [JsonPropertyName("databaseConnections")]
    public List<DatabaseConnectionOverviewModel>? DatabaseConnections { get; set; }

    [JsonPropertyName("defaultHostname")]
    public string? DefaultHostname { get; set; }

    [JsonPropertyName("enterpriseGradeCdnStatus")]
    public EnterpriseGradeCdnStatusConstant? EnterpriseGradeCdnStatus { get; set; }

    [JsonPropertyName("keyVaultReferenceIdentity")]
    public string? KeyVaultReferenceIdentity { get; set; }

    [JsonPropertyName("linkedBackends")]
    public List<StaticSiteLinkedBackendModel>? LinkedBackends { get; set; }

    [JsonPropertyName("privateEndpointConnections")]
    public List<ResponseMessageEnvelopeRemotePrivateEndpointConnectionModel>? PrivateEndpointConnections { get; set; }

    [JsonPropertyName("provider")]
    public string? Provider { get; set; }

    [JsonPropertyName("publicNetworkAccess")]
    public string? PublicNetworkAccess { get; set; }

    [JsonPropertyName("repositoryToken")]
    public string? RepositoryToken { get; set; }

    [JsonPropertyName("repositoryUrl")]
    public string? RepositoryUrl { get; set; }

    [JsonPropertyName("stagingEnvironmentPolicy")]
    public StagingEnvironmentPolicyConstant? StagingEnvironmentPolicy { get; set; }

    [JsonPropertyName("templateProperties")]
    public StaticSiteTemplateOptionsModel? TemplateProperties { get; set; }

    [JsonPropertyName("userProvidedFunctionApps")]
    public List<StaticSiteUserProvidedFunctionAppModel>? UserProvidedFunctionApps { get; set; }
}
