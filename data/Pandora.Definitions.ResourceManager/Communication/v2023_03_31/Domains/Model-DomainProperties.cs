using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Communication.v2023_03_31.Domains;


internal class DomainPropertiesModel
{
    [JsonPropertyName("dataLocation")]
    public string? DataLocation { get; set; }

    [JsonPropertyName("domainManagement")]
    [Required]
    public DomainManagementConstant DomainManagement { get; set; }

    [JsonPropertyName("fromSenderDomain")]
    public string? FromSenderDomain { get; set; }

    [JsonPropertyName("mailFromSenderDomain")]
    public string? MailFromSenderDomain { get; set; }

    [JsonPropertyName("provisioningState")]
    public DomainsProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("userEngagementTracking")]
    public UserEngagementTrackingConstant? UserEngagementTracking { get; set; }

    [JsonPropertyName("verificationRecords")]
    public DomainPropertiesVerificationRecordsModel? VerificationRecords { get; set; }

    [JsonPropertyName("verificationStates")]
    public DomainPropertiesVerificationStatesModel? VerificationStates { get; set; }
}
