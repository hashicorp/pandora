using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.PostgreSql.v2017_12_01.Servers;


internal abstract class ServerPropertiesForCreateModel
{
    [JsonPropertyName("createMode")]
    [ProvidesTypeHint]
    [Required]
    public CreateModeConstant CreateMode { get; set; }

    [JsonPropertyName("infrastructureEncryption")]
    public InfrastructureEncryptionConstant? InfrastructureEncryption { get; set; }

    [JsonPropertyName("minimalTlsVersion")]
    public MinimalTlsVersionEnumConstant? MinimalTlsVersion { get; set; }

    [JsonPropertyName("publicNetworkAccess")]
    public PublicNetworkAccessEnumConstant? PublicNetworkAccess { get; set; }

    [JsonPropertyName("sslEnforcement")]
    public SslEnforcementEnumConstant? SslEnforcement { get; set; }

    [JsonPropertyName("storageProfile")]
    public StorageProfileModel? StorageProfile { get; set; }

    [JsonPropertyName("version")]
    public ServerVersionConstant? Version { get; set; }
}
