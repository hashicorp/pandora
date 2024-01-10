using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.PostgreSql.v2023_06_01_preview.Migrations;


internal class DbLevelValidationStatusModel
{
    [JsonPropertyName("databaseName")]
    public string? DatabaseName { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("endedOn")]
    public DateTime? EndedOn { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("startedOn")]
    public DateTime? StartedOn { get; set; }

    [JsonPropertyName("summary")]
    public List<ValidationSummaryItemModel>? Summary { get; set; }
}
