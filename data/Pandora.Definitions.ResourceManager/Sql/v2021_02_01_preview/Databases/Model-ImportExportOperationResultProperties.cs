using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Sql.v2021_02_01_preview.Databases;


internal class ImportExportOperationResultPropertiesModel
{
    [JsonPropertyName("blobUri")]
    public string? BlobUri { get; set; }

    [JsonPropertyName("databaseName")]
    public string? DatabaseName { get; set; }

    [JsonPropertyName("errorMessage")]
    public string? ErrorMessage { get; set; }

    [JsonPropertyName("lastModifiedTime")]
    public string? LastModifiedTime { get; set; }

    [JsonPropertyName("privateEndpointConnections")]
    public List<PrivateEndpointConnectionRequestStatusModel>? PrivateEndpointConnections { get; set; }

    [JsonPropertyName("queuedTime")]
    public string? QueuedTime { get; set; }

    [JsonPropertyName("requestId")]
    public string? RequestId { get; set; }

    [JsonPropertyName("requestType")]
    public string? RequestType { get; set; }

    [JsonPropertyName("serverName")]
    public string? ServerName { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }
}
