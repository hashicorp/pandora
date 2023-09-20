// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class DocumentSetModel
{
    [JsonPropertyName("allowedContentTypes")]
    public List<ContentTypeInfoModel>? AllowedContentTypes { get; set; }

    [JsonPropertyName("defaultContents")]
    public List<DocumentSetContentModel>? DefaultContents { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("propagateWelcomePageChanges")]
    public bool? PropagateWelcomePageChanges { get; set; }

    [JsonPropertyName("sharedColumns")]
    public List<ColumnDefinitionModel>? SharedColumns { get; set; }

    [JsonPropertyName("shouldPrefixNameToFile")]
    public bool? ShouldPrefixNameToFile { get; set; }

    [JsonPropertyName("welcomePageColumns")]
    public List<ColumnDefinitionModel>? WelcomePageColumns { get; set; }

    [JsonPropertyName("welcomePageUrl")]
    public string? WelcomePageUrl { get; set; }
}
