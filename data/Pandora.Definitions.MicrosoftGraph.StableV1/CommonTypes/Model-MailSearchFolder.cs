// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class MailSearchFolderModel
{
    [JsonPropertyName("childFolderCount")]
    public int? ChildFolderCount { get; set; }

    [JsonPropertyName("childFolders")]
    public List<MailFolderModel>? ChildFolders { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("filterQuery")]
    public string? FilterQuery { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("includeNestedFolders")]
    public bool? IncludeNestedFolders { get; set; }

    [JsonPropertyName("isHidden")]
    public bool? IsHidden { get; set; }

    [JsonPropertyName("isSupported")]
    public bool? IsSupported { get; set; }

    [JsonPropertyName("messageRules")]
    public List<MessageRuleModel>? MessageRules { get; set; }

    [JsonPropertyName("messages")]
    public List<MessageModel>? Messages { get; set; }

    [JsonPropertyName("multiValueExtendedProperties")]
    public List<MultiValueLegacyExtendedPropertyModel>? MultiValueExtendedProperties { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("parentFolderId")]
    public string? ParentFolderId { get; set; }

    [JsonPropertyName("singleValueExtendedProperties")]
    public List<SingleValueLegacyExtendedPropertyModel>? SingleValueExtendedProperties { get; set; }

    [JsonPropertyName("sourceFolderIds")]
    public List<string>? SourceFolderIds { get; set; }

    [JsonPropertyName("totalItemCount")]
    public int? TotalItemCount { get; set; }

    [JsonPropertyName("unreadItemCount")]
    public int? UnreadItemCount { get; set; }
}
