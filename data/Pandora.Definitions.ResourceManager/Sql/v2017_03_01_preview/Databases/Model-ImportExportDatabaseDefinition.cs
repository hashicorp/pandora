using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Sql.v2017_03_01_preview.Databases;


internal class ImportExportDatabaseDefinitionModel
{
    [JsonPropertyName("administratorLogin")]
    [Required]
    public string AdministratorLogin { get; set; }

    [JsonPropertyName("administratorLoginPassword")]
    [Required]
    public string AdministratorLoginPassword { get; set; }

    [JsonPropertyName("authenticationType")]
    public string? AuthenticationType { get; set; }

    [JsonPropertyName("databaseName")]
    public string? DatabaseName { get; set; }

    [JsonPropertyName("edition")]
    public string? Edition { get; set; }

    [JsonPropertyName("maxSizeBytes")]
    public string? MaxSizeBytes { get; set; }

    [JsonPropertyName("serviceObjectiveName")]
    public string? ServiceObjectiveName { get; set; }

    [JsonPropertyName("storageKey")]
    [Required]
    public string StorageKey { get; set; }

    [JsonPropertyName("storageKeyType")]
    [Required]
    public string StorageKeyType { get; set; }

    [JsonPropertyName("storageUri")]
    [Required]
    public string StorageUri { get; set; }
}
