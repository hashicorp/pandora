using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Sql.v2022_11_01_preview.ManagedDatabaseSecurityEvents;


internal class SecurityEventPropertiesModel
{
    [JsonPropertyName("applicationName")]
    public string? ApplicationName { get; set; }

    [JsonPropertyName("clientIp")]
    public string? ClientIP { get; set; }

    [JsonPropertyName("database")]
    public string? Database { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("eventTime")]
    public DateTime? EventTime { get; set; }

    [JsonPropertyName("principalName")]
    public string? PrincipalName { get; set; }

    [JsonPropertyName("securityEventSqlInjectionAdditionalProperties")]
    public SecurityEventSqlInjectionAdditionalPropertiesModel? SecurityEventSqlInjectionAdditionalProperties { get; set; }

    [JsonPropertyName("securityEventType")]
    public SecurityEventTypeConstant? SecurityEventType { get; set; }

    [JsonPropertyName("server")]
    public string? Server { get; set; }

    [JsonPropertyName("subscription")]
    public string? Subscription { get; set; }
}
