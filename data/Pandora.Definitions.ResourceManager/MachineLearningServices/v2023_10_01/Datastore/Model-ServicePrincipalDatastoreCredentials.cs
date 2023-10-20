using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_10_01.Datastore;

[ValueForType("ServicePrincipal")]
internal class ServicePrincipalDatastoreCredentialsModel : DatastoreCredentialsModel
{
    [JsonPropertyName("authorityUrl")]
    public string? AuthorityUrl { get; set; }

    [JsonPropertyName("clientId")]
    [Required]
    public string ClientId { get; set; }

    [JsonPropertyName("resourceUrl")]
    public string? ResourceUrl { get; set; }

    [JsonPropertyName("secrets")]
    [Required]
    public ServicePrincipalDatastoreSecretsModel Secrets { get; set; }

    [JsonPropertyName("tenantId")]
    [Required]
    public string TenantId { get; set; }
}
