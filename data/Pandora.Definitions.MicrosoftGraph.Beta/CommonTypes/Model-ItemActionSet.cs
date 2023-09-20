// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class ItemActionSetModel
{
    [JsonPropertyName("comment")]
    public CommentActionModel? Comment { get; set; }

    [JsonPropertyName("create")]
    public CreateActionModel? Create { get; set; }

    [JsonPropertyName("delete")]
    public DeleteActionModel? Delete { get; set; }

    [JsonPropertyName("edit")]
    public EditActionModel? Edit { get; set; }

    [JsonPropertyName("mention")]
    public MentionActionModel? Mention { get; set; }

    [JsonPropertyName("move")]
    public MoveActionModel? Move { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("rename")]
    public RenameActionModel? Rename { get; set; }

    [JsonPropertyName("restore")]
    public RestoreActionModel? Restore { get; set; }

    [JsonPropertyName("share")]
    public ShareActionModel? Share { get; set; }

    [JsonPropertyName("version")]
    public VersionActionModel? Version { get; set; }
}
