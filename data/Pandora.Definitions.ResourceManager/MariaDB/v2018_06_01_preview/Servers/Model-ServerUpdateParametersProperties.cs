using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MariaDB.v2018_06_01_preview.Servers;


internal class ServerUpdateParametersPropertiesModel
{
    [JsonPropertyName("administratorLoginPassword")]
    public string? AdministratorLoginPassword { get; set; }

    [JsonPropertyName("minimalTlsVersion")]
    public MinimalTlsVersionEnumConstant? MinimalTlsVersion { get; set; }

    [JsonPropertyName("replicationRole")]
    public string? ReplicationRole { get; set; }

    [JsonPropertyName("sslEnforcement")]
    public SslEnforcementEnumConstant? SslEnforcement { get; set; }

    [JsonPropertyName("storageProfile")]
    public StorageProfileModel? StorageProfile { get; set; }

    [JsonPropertyName("version")]
    public ServerVersionConstant? Version { get; set; }
}
