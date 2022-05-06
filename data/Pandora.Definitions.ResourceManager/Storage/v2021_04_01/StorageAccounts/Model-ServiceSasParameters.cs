using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Storage.v2021_04_01.StorageAccounts;


internal class ServiceSasParametersModel
{
    [JsonPropertyName("canonicalizedResource")]
    [Required]
    public string CanonicalizedResource { get; set; }

    [JsonPropertyName("endPk")]
    public string? EndPk { get; set; }

    [JsonPropertyName("endRk")]
    public string? EndRk { get; set; }

    [JsonPropertyName("keyToSign")]
    public string? KeyToSign { get; set; }

    [JsonPropertyName("rscc")]
    public string? Rscc { get; set; }

    [JsonPropertyName("rscd")]
    public string? Rscd { get; set; }

    [JsonPropertyName("rsce")]
    public string? Rsce { get; set; }

    [JsonPropertyName("rscl")]
    public string? Rscl { get; set; }

    [JsonPropertyName("rsct")]
    public string? Rsct { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("signedExpiry")]
    public DateTime? SignedExpiry { get; set; }

    [JsonPropertyName("signedIdentifier")]
    public string? SignedIdentifier { get; set; }

    [JsonPropertyName("signedIp")]
    public string? SignedIp { get; set; }

    [JsonPropertyName("signedPermission")]
    public PermissionsConstant? SignedPermission { get; set; }

    [JsonPropertyName("signedProtocol")]
    public HttpProtocolConstant? SignedProtocol { get; set; }

    [JsonPropertyName("signedResource")]
    public SignedResourceConstant? SignedResource { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("signedStart")]
    public DateTime? SignedStart { get; set; }

    [JsonPropertyName("startPk")]
    public string? StartPk { get; set; }

    [JsonPropertyName("startRk")]
    public string? StartRk { get; set; }
}
