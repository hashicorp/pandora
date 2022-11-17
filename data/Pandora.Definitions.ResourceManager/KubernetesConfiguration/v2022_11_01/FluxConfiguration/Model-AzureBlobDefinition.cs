using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.KubernetesConfiguration.v2022_11_01.FluxConfiguration;


internal class AzureBlobDefinitionModel
{
    [JsonPropertyName("accountKey")]
    public string? AccountKey { get; set; }

    [JsonPropertyName("containerName")]
    public string? ContainerName { get; set; }

    [JsonPropertyName("localAuthRef")]
    public string? LocalAuthRef { get; set; }

    [JsonPropertyName("managedIdentity")]
    public ManagedIdentityDefinitionModel? ManagedIdentity { get; set; }

    [JsonPropertyName("sasToken")]
    public string? SasToken { get; set; }

    [JsonPropertyName("servicePrincipal")]
    public ServicePrincipalDefinitionModel? ServicePrincipal { get; set; }

    [JsonPropertyName("syncIntervalInSeconds")]
    public int? SyncIntervalInSeconds { get; set; }

    [JsonPropertyName("timeoutInSeconds")]
    public int? TimeoutInSeconds { get; set; }

    [JsonPropertyName("url")]
    public string? Url { get; set; }
}
