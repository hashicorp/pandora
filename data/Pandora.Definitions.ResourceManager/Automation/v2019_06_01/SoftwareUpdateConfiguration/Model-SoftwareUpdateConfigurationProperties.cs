using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Automation.v2019_06_01.SoftwareUpdateConfiguration;


internal class SoftwareUpdateConfigurationPropertiesModel
{
    [JsonPropertyName("createdBy")]
    public string? CreatedBy { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("creationTime")]
    public DateTime? CreationTime { get; set; }

    [JsonPropertyName("error")]
    public ErrorResponseModel? Error { get; set; }

    [JsonPropertyName("lastModifiedBy")]
    public string? LastModifiedBy { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastModifiedTime")]
    public DateTime? LastModifiedTime { get; set; }

    [JsonPropertyName("provisioningState")]
    public string? ProvisioningState { get; set; }

    [JsonPropertyName("scheduleInfo")]
    [Required]
    public SUCSchedulePropertiesModel ScheduleInfo { get; set; }

    [JsonPropertyName("tasks")]
    public SoftwareUpdateConfigurationTasksModel? Tasks { get; set; }

    [JsonPropertyName("updateConfiguration")]
    [Required]
    public UpdateConfigurationModel UpdateConfiguration { get; set; }
}
