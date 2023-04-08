using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.HDInsight.v2021_06_01.Applications;


internal class ApplicationPropertiesModel
{
    [JsonPropertyName("applicationState")]
    public string? ApplicationState { get; set; }

    [JsonPropertyName("applicationType")]
    public string? ApplicationType { get; set; }

    [JsonPropertyName("computeProfile")]
    public ComputeProfileModel? ComputeProfile { get; set; }

    [JsonPropertyName("createdDate")]
    public string? CreatedDate { get; set; }

    [JsonPropertyName("errors")]
    public List<ErrorsModel>? Errors { get; set; }

    [JsonPropertyName("httpsEndpoints")]
    public List<ApplicationGetHTTPSEndpointModel>? HTTPSEndpoints { get; set; }

    [JsonPropertyName("installScriptActions")]
    public List<RuntimeScriptActionModel>? InstallScriptActions { get; set; }

    [JsonPropertyName("marketplaceIdentifier")]
    public string? MarketplaceIdentifier { get; set; }

    [JsonPropertyName("privateLinkConfigurations")]
    public List<PrivateLinkConfigurationModel>? PrivateLinkConfigurations { get; set; }

    [JsonPropertyName("provisioningState")]
    public string? ProvisioningState { get; set; }

    [JsonPropertyName("sshEndpoints")]
    public List<ApplicationGetEndpointModel>? SshEndpoints { get; set; }

    [JsonPropertyName("uninstallScriptActions")]
    public List<RuntimeScriptActionModel>? UninstallScriptActions { get; set; }
}
