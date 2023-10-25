using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Sql.v2021_11_01.ManagedDatabaseSecurityEvents;


internal class SecurityEventSqlInjectionAdditionalPropertiesModel
{
    [JsonPropertyName("errorCode")]
    public int? ErrorCode { get; set; }

    [JsonPropertyName("errorMessage")]
    public string? ErrorMessage { get; set; }

    [JsonPropertyName("errorSeverity")]
    public int? ErrorSeverity { get; set; }

    [JsonPropertyName("statement")]
    public string? Statement { get; set; }

    [JsonPropertyName("statementHighlightLength")]
    public int? StatementHighlightLength { get; set; }

    [JsonPropertyName("statementHighlightOffset")]
    public int? StatementHighlightOffset { get; set; }

    [JsonPropertyName("threatId")]
    public string? ThreatId { get; set; }
}
