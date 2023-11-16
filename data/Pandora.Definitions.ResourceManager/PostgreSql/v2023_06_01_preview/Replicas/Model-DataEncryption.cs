using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.PostgreSql.v2023_06_01_preview.Replicas;


internal class DataEncryptionModel
{
    [JsonPropertyName("geoBackupEncryptionKeyStatus")]
    public KeyStatusEnumConstant? GeoBackupEncryptionKeyStatus { get; set; }

    [JsonPropertyName("geoBackupKeyURI")]
    public string? GeoBackupKeyURI { get; set; }

    [JsonPropertyName("geoBackupUserAssignedIdentityId")]
    public string? GeoBackupUserAssignedIdentityId { get; set; }

    [JsonPropertyName("primaryEncryptionKeyStatus")]
    public KeyStatusEnumConstant? PrimaryEncryptionKeyStatus { get; set; }

    [JsonPropertyName("primaryKeyURI")]
    public string? PrimaryKeyURI { get; set; }

    [JsonPropertyName("primaryUserAssignedIdentityId")]
    public string? PrimaryUserAssignedIdentityId { get; set; }

    [JsonPropertyName("type")]
    public ArmServerKeyTypeConstant? Type { get; set; }
}
