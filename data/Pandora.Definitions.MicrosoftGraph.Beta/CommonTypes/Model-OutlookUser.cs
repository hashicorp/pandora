// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class OutlookUserModel
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("masterCategories")]
    public List<OutlookCategoryModel>? MasterCategories { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("taskFolders")]
    public List<OutlookTaskFolderModel>? TaskFolders { get; set; }

    [JsonPropertyName("taskGroups")]
    public List<OutlookTaskGroupModel>? TaskGroups { get; set; }

    [JsonPropertyName("tasks")]
    public List<OutlookTaskModel>? Tasks { get; set; }
}
