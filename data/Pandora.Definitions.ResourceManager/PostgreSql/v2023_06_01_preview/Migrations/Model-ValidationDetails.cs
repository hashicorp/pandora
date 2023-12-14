using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.PostgreSql.v2023_06_01_preview.Migrations;


internal class ValidationDetailsModel
{
    [JsonPropertyName("dbLevelValidationDetails")]
    public List<DbLevelValidationStatusModel>? DbLevelValidationDetails { get; set; }

    [JsonPropertyName("serverLevelValidationDetails")]
    public List<ValidationSummaryItemModel>? ServerLevelValidationDetails { get; set; }

    [JsonPropertyName("status")]
    public ValidationStateConstant? Status { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("validationEndTimeInUtc")]
    public DateTime? ValidationEndTimeInUtc { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("validationStartTimeInUtc")]
    public DateTime? ValidationStartTimeInUtc { get; set; }
}
