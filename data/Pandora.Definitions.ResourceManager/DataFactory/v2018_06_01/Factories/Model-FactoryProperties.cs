using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataFactory.v2018_06_01.Factories;


internal class FactoryPropertiesModel
{
    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("createTime")]
    public DateTime? CreateTime { get; set; }

    [JsonPropertyName("encryption")]
    public EncryptionConfigurationModel? Encryption { get; set; }

    [JsonPropertyName("globalParameters")]
    public Dictionary<string, GlobalParameterSpecificationModel>? GlobalParameters { get; set; }

    [JsonPropertyName("provisioningState")]
    public string? ProvisioningState { get; set; }

    [JsonPropertyName("publicNetworkAccess")]
    public PublicNetworkAccessConstant? PublicNetworkAccess { get; set; }

    [JsonPropertyName("purviewConfiguration")]
    public PurviewConfigurationModel? PurviewConfiguration { get; set; }

    [JsonPropertyName("repoConfiguration")]
    public FactoryRepoConfigurationModel? RepoConfiguration { get; set; }

    [JsonPropertyName("version")]
    public string? Version { get; set; }
}
