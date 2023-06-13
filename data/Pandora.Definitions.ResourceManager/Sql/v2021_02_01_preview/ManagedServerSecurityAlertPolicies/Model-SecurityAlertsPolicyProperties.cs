using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Sql.v2021_02_01_preview.ManagedServerSecurityAlertPolicies;


internal class SecurityAlertsPolicyPropertiesModel
{
    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("creationTime")]
    public DateTime? CreationTime { get; set; }

    [JsonPropertyName("disabledAlerts")]
    public List<string>? DisabledAlerts { get; set; }

    [JsonPropertyName("emailAccountAdmins")]
    public bool? EmailAccountAdmins { get; set; }

    [JsonPropertyName("emailAddresses")]
    public List<string>? EmailAddresses { get; set; }

    [JsonPropertyName("retentionDays")]
    public int? RetentionDays { get; set; }

    [JsonPropertyName("state")]
    [Required]
    public SecurityAlertsPolicyStateConstant State { get; set; }

    [JsonPropertyName("storageAccountAccessKey")]
    public string? StorageAccountAccessKey { get; set; }

    [JsonPropertyName("storageEndpoint")]
    public string? StorageEndpoint { get; set; }
}
