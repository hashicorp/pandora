using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.AlertsManagement.v2019_05_05_preview.SmartGroups;


internal class SmartGroupModificationItemModel
{
    [JsonPropertyName("comments")]
    public string? Comments { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("modificationEvent")]
    public SmartGroupModificationEventConstant? ModificationEvent { get; set; }

    [JsonPropertyName("modifiedAt")]
    public string? ModifiedAt { get; set; }

    [JsonPropertyName("modifiedBy")]
    public string? ModifiedBy { get; set; }

    [JsonPropertyName("newValue")]
    public string? NewValue { get; set; }

    [JsonPropertyName("oldValue")]
    public string? OldValue { get; set; }
}
