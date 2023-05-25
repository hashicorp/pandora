using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Sql.v2022_11_01_preview.DatabaseExtensions;


internal class DatabaseExtensionsPropertiesModel
{
    [JsonPropertyName("administratorLogin")]
    public string? AdministratorLogin { get; set; }

    [JsonPropertyName("administratorLoginPassword")]
    public string? AdministratorLoginPassword { get; set; }

    [JsonPropertyName("authenticationType")]
    public string? AuthenticationType { get; set; }

    [JsonPropertyName("databaseEdition")]
    public string? DatabaseEdition { get; set; }

    [JsonPropertyName("maxSizeBytes")]
    public string? MaxSizeBytes { get; set; }

    [JsonPropertyName("networkIsolation")]
    public NetworkIsolationSettingsModel? NetworkIsolation { get; set; }

    [JsonPropertyName("operationMode")]
    [Required]
    public OperationModeConstant OperationMode { get; set; }

    [JsonPropertyName("serviceObjectiveName")]
    public string? ServiceObjectiveName { get; set; }

    [JsonPropertyName("storageKey")]
    [Required]
    public string StorageKey { get; set; }

    [JsonPropertyName("storageKeyType")]
    [Required]
    public StorageKeyTypeConstant StorageKeyType { get; set; }

    [JsonPropertyName("storageUri")]
    [Required]
    public string StorageUri { get; set; }
}
