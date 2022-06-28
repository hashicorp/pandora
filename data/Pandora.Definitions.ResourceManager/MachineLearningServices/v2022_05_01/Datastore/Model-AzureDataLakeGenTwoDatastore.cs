using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2022_05_01.Datastore;

[ValueForType("AzureDataLakeGen2")]
internal class AzureDataLakeGenTwoDatastoreModel : DatastoreModel
{
    [JsonPropertyName("accountName")]
    [Required]
    public string AccountName { get; set; }

    [JsonPropertyName("endpoint")]
    public string? Endpoint { get; set; }

    [JsonPropertyName("filesystem")]
    [Required]
    public string Filesystem { get; set; }

    [JsonPropertyName("protocol")]
    public string? Protocol { get; set; }

    [JsonPropertyName("serviceDataAccessAuthIdentity")]
    public ServiceDataAccessAuthIdentityConstant? ServiceDataAccessAuthIdentity { get; set; }
}
