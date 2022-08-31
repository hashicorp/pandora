using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.CostManagement.v2021_10_01.Alerts;


internal class AlertPropertiesModel
{
    [JsonPropertyName("closeTime")]
    public string? CloseTime { get; set; }

    [JsonPropertyName("costEntityId")]
    public string? CostEntityId { get; set; }

    [JsonPropertyName("creationTime")]
    public string? CreationTime { get; set; }

    [JsonPropertyName("definition")]
    public AlertPropertiesDefinitionModel? Definition { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("details")]
    public AlertPropertiesDetailsModel? Details { get; set; }

    [JsonPropertyName("modificationTime")]
    public string? ModificationTime { get; set; }

    [JsonPropertyName("source")]
    public AlertSourceConstant? Source { get; set; }

    [JsonPropertyName("status")]
    public AlertStatusConstant? Status { get; set; }

    [JsonPropertyName("statusModificationTime")]
    public string? StatusModificationTime { get; set; }

    [JsonPropertyName("statusModificationUserName")]
    public string? StatusModificationUserName { get; set; }
}
