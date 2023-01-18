using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Logic.v2019_05_01.IntegrationAccountAssemblies;


internal class AssemblyPropertiesModel
{
    [JsonPropertyName("assemblyCulture")]
    public string? AssemblyCulture { get; set; }

    [JsonPropertyName("assemblyName")]
    [Required]
    public string AssemblyName { get; set; }

    [JsonPropertyName("assemblyPublicKeyToken")]
    public string? AssemblyPublicKeyToken { get; set; }

    [JsonPropertyName("assemblyVersion")]
    public string? AssemblyVersion { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("changedTime")]
    public DateTime? ChangedTime { get; set; }

    [JsonPropertyName("content")]
    public object? Content { get; set; }

    [JsonPropertyName("contentLink")]
    public ContentLinkModel? ContentLink { get; set; }

    [JsonPropertyName("contentType")]
    public string? ContentType { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("createdTime")]
    public DateTime? CreatedTime { get; set; }

    [JsonPropertyName("metadata")]
    public object? Metadata { get; set; }
}
