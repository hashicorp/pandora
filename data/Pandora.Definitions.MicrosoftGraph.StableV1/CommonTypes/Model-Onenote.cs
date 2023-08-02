// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class OnenoteModel
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("notebooks")]
    public List<NotebookModel>? Notebooks { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("operations")]
    public List<OnenoteOperationModel>? Operations { get; set; }

    [JsonPropertyName("pages")]
    public List<OnenotePageModel>? Pages { get; set; }

    [JsonPropertyName("resources")]
    public List<OnenoteResourceModel>? Resources { get; set; }

    [JsonPropertyName("sectionGroups")]
    public List<SectionGroupModel>? SectionGroups { get; set; }

    [JsonPropertyName("sections")]
    public List<OnenoteSectionModel>? Sections { get; set; }
}
