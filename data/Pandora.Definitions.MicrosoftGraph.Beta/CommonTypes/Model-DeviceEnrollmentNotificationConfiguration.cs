// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class DeviceEnrollmentNotificationConfigurationModel
{
    [JsonPropertyName("assignments")]
    public List<EnrollmentConfigurationAssignmentModel>? Assignments { get; set; }

    [JsonPropertyName("brandingOptions")]
    public EnrollmentNotificationBrandingOptionsConstant? BrandingOptions { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("defaultLocale")]
    public string? DefaultLocale { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("deviceEnrollmentConfigurationType")]
    public DeviceEnrollmentConfigurationTypeConstant? DeviceEnrollmentConfigurationType { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("lastModifiedDateTime")]
    public DateTime? LastModifiedDateTime { get; set; }

    [JsonPropertyName("notificationMessageTemplateId")]
    public string? NotificationMessageTemplateId { get; set; }

    [JsonPropertyName("notificationTemplates")]
    public List<string>? NotificationTemplates { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("platformType")]
    public EnrollmentRestrictionPlatformTypeConstant? PlatformType { get; set; }

    [JsonPropertyName("priority")]
    public int? Priority { get; set; }

    [JsonPropertyName("roleScopeTagIds")]
    public List<string>? RoleScopeTagIds { get; set; }

    [JsonPropertyName("templateType")]
    public EnrollmentNotificationTemplateTypeConstant? TemplateType { get; set; }

    [JsonPropertyName("version")]
    public int? Version { get; set; }
}
